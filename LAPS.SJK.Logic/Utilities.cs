using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web;
using LAPS.SJK.Logic.Enum;
using LAPS.SJK.Logic.Helper;
using LAPS.SJK.Dta;
using LAPS.SJK.Dto;
using System.Web.UI.WebControls;

namespace LAPS.SJK.Logic
{

    public class MonthHelper
    {
        public MonthHelper(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class SQL
    {
        public const string DATE_FORMART = "%Y-%m-%d";
    }

    public class Utilities
    {
        // Load all suffixes in an array  
        static readonly string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB", "PB" };
        public static string FormatSize(Int64 bytes)
        {
            int counter = 0;
            decimal number = (decimal)bytes;
            while (Math.Floor(number / 1024) >= 1)
            {
                number = number / 1024;
                counter++;
            }
            return string.Format("{0:n1}{1}", number, suffixes[counter]);
        }

        public static List<DataItem> GetDataSource<ObjectEnum>()
        {
            List<DataItem> results = new List<DataItem>();

            var enumerableType = typeof(ObjectEnum);

            if (enumerableType.IsEnum)
            {
                foreach (int value in System.Enum.GetValues(enumerableType))
                {
                    string name = System.Enum.GetName(enumerableType, value);
                    foreach (MemberInfo mInfo in enumerableType.GetMember(name))
                    {
                        DescriptionAttribute attribute = mInfo.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault() as DescriptionAttribute;
                        if (attribute != null)
                        {
                            string description = attribute.Description;
                            name = string.IsNullOrEmpty(description) ? name : description;
                            break;
                        }
                    }

                    results.Add(new DataItem(value.ToString(), name));
                }
            }

            return results;
        }


        public const string SESSION_FRONTEND_MENU = "_FRONTEND_MENU";
        public const string SESSION_BACKEND_MENU = "_BACKEND_MENU";
        public const string SESSION_TOP_MENU = "_TOP_MENU";
        public const string SESSION_TOP_BEFORE_MENU = "_TOP_BEFORE_MENU";

        public const string SESSION_ALL_MENU = "_ALL_MENU";

        public static List<tbl_Menu> GetALL_MENU()
        {
            List<tbl_Menu> list = new List<tbl_Menu>();
            object obj = SessionHelper.Get(SESSION_ALL_MENU);
            if (obj == null)
            {
                obj = tbl_MenuItem.GetAllActive();
                SessionHelper.Set(SESSION_ALL_MENU, obj);
            }

            list = obj as List<tbl_Menu>;

            return list;
        }


        public static List<tbl_Menu> GetFRONTEND_MENU()
        {
            //List<tbl_Menu> list = new List<tbl_Menu>();
            //object obj = SessionHelper.Get(SESSION_FRONTEND_MENU);
            //if (obj == null)
            //{
            //    obj = tbl_MenuItem.GetByType("FRONT");
            //    SessionHelper.Set(SESSION_FRONTEND_MENU, obj);
            //}

            //list = obj as List<tbl_Menu>;

            //return list;

            return tbl_MenuItem.GetByType("FRONT");
        }

        public static List<tbl_Menu> GetBACKEND_MENU()
        {
            //List<tbl_Menu> list = new List<tbl_Menu>();
            //object obj = SessionHelper.Get(SESSION_BACKEND_MENU);
            //if (obj == null)
            //{
            //    obj = tbl_MenuItem.GetByType("BACK");
            //    SessionHelper.Set(SESSION_BACKEND_MENU, obj);
            //}

            //list = obj as List<tbl_Menu>;

            //return list;

            return tbl_MenuItem.GetByType("BACK");
        }

        public static List<tbl_Menu> GetTOP_MENU()
        {
            //List<tbl_Menu> list = new List<tbl_Menu>();
            //object obj = SessionHelper.Get(SESSION_TOP_MENU);
            //if (obj == null)
            //{
            //    obj = tbl_MenuItem.GetByType("TOP");
            //    SessionHelper.Set(SESSION_TOP_MENU, obj);
            //}

            //list = obj as List<tbl_Menu>;

            //return list;

            return tbl_MenuItem.GetByType("TOP");
        }

        public static List<tbl_Menu> GetTOP_BEFORE_MENU()
        {
            //List<tbl_Menu> list = new List<tbl_Menu>();
            //object obj = SessionHelper.Get(SESSION_TOP_BEFORE_MENU);
            //if (obj == null)
            //{
            //    obj = tbl_MenuItem.GetByType("TOP_BEFORE");
            //    SessionHelper.Set(SESSION_TOP_BEFORE_MENU, obj);
            //}

            //list = obj as List<tbl_Menu>;

            //return list;

            return tbl_MenuItem.GetByType("TOP_BEFORE");
        }


        public static void ClearAllManus()
        {
            SessionHelper.Set(SESSION_FRONTEND_MENU, null);
            SessionHelper.Set(SESSION_BACKEND_MENU, null);
            SessionHelper.Set(SESSION_TOP_MENU, null);
        }



        //public static tbl_Menu GetMenuBackendByID(int menuID)
        //{
        //    List<tbl_Menu> list = new List<tbl_Menu>();
        //    object obj = SessionHelper.Get(SESSION_BACKEND_MENU);
        //    if (obj == null)
        //    {
        //        obj = tbl_MenuItem.GetAllActive().Where(t => t.MenuType == "BACK").ToList();
        //        SessionHelper.Set(SESSION_BACKEND_MENU, obj);
        //    }

        //    list = obj as List<tbl_Menu>;

        //    return list.Where(t => t.ID == menuID).FirstOrDefault();
        //}



        //public static tbl_Menu GetMenuFrontendByID(int menuID)
        //{
        //    List<tbl_Menu> list = new List<tbl_Menu>();
        //    object obj = SessionHelper.Get(SESSION_FRONTEND_MENU);
        //    if (obj == null)
        //    {
        //        obj = tbl_MenuItem.GetAllActive().Where(t => t.MenuType == "FRONT").ToList();
        //        SessionHelper.Set(SESSION_FRONTEND_MENU, obj);
        //    }

        //    list = obj as List<tbl_Menu>;

        //    return list.Where(t => t.ID == menuID).FirstOrDefault();
        //}

        public static string ExtToName(object file_ext)
        {
            if (string.Format("{0}", file_ext).Length > 0)
                return string.Format("{0}", file_ext).Replace(".", "").ToUpper();
            return string.Empty;
        }


        public static string ExtToImage(object file_ext)
        {
            if (string.Format("{0}", file_ext).Length > 0)
                return string.Format("~/Content/assets/media/files/{0}.svg", string.Format("{0}", file_ext).Replace(".", "").ToLower());

            return string.Empty;
        }

        public static string ObjImageToString(object obj)
        {
            if (obj == null) return "";
            byte[] file_blob = (byte[])obj;
            return "data:image/png;base64, " + Convert.ToBase64String(file_blob);
        }

        public static string ByteToString(byte[] file_blob)
        {

            ////           <img src=""data:image/png;base64, iVBORw0KGgoAAAANSUhEUgAAAAUA
            ////AAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO
            ////    9TXL0Y4OHwAAAABJRU5ErkJggg=="" alt=""..."" />
            if (file_blob == null) return "#";
            return "data:image/png;base64, " + Convert.ToBase64String(file_blob);
        }
        public static byte[] StreamToBytes(Stream input)
        {
            using (var ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }


        public static List<DataItem> GetLanguages()
        {
            List<DataItem> list = new List<DataItem>();
            list.Add(new DataItem("", "--Select--"));
            list.Add(new DataItem("IDN", "Indonesia"));
            list.Add(new DataItem("END", "English"));

            return list;
        }

        public static int GetTotalPage(int totalRecords, int pageSize)
        {
            double pageCount = (double)((decimal)totalRecords / Convert.ToDecimal(pageSize));
            return (int)Math.Ceiling(pageCount);

        }


        public static List<ListItem> PopulatePager(int recordCount, int currentPage, decimal pageSize, out string totalRecordInfo)
        {
            totalRecordInfo = "";

            List<ListItem> pages = new List<ListItem>();
            if (recordCount <= 0) return pages;
            int startIndex, endIndex;
            int pagerSpan = 5;

            //Calculate the Start and End Index of pages to be displayed.
            double dblPageCount = (double)((decimal)recordCount / Convert.ToDecimal(pageSize));
            int pageCount = (int)Math.Ceiling(dblPageCount);

            startIndex = currentPage > 1 && currentPage + pagerSpan - 1 < pagerSpan ? currentPage : 1;
            endIndex = pageCount > pagerSpan ? pagerSpan : pageCount;
            if (currentPage > pagerSpan % 2)
            {
                if (currentPage == 2)
                {
                    endIndex = 5;
                }
                else
                {
                    endIndex = currentPage + 2;
                }
            }
            else
            {
                endIndex = (pagerSpan - currentPage) + 1;
            }

            if (endIndex - (pagerSpan - 1) > startIndex)
            {
                startIndex = endIndex - (pagerSpan - 1);
            }

            if (endIndex > pageCount)
            {
                endIndex = pageCount;
                startIndex = ((endIndex - pagerSpan) + 1) > 0 ? (endIndex - pagerSpan) + 1 : 1;
            }

            //Add the First Page Button.
            if (currentPage > 1)
            {
                pages.Add(new ListItem("<i class=\"fa fa-angle-double-left kt-font-primary\"></i>", "1"));
            }

            //Add the Previous Button.
            if (currentPage > 1)
            {
                pages.Add(new ListItem("<i class=\"fa fa-angle-left kt-font-primary\"></i>", (currentPage - 1).ToString()));
            }

            for (int i = startIndex; i <= endIndex; i++)
            {
                pages.Add(new ListItem(i.ToString(), i.ToString(), i != currentPage));
            }

            //Add the Next Button.
            if (currentPage < pageCount)
            {
                pages.Add(new ListItem("<i class=\"fa fa-angle-right kt-font-primary\"></i>", (currentPage + 1).ToString()));
            }

            //Add the Last Button.
            if (currentPage != pageCount)
            {
                pages.Add(new ListItem("<i class=\"fa fa-angle-double-right kt-font-primary\"></i>", pageCount.ToString()));
            }

            totalRecordInfo = string.Format("Displaying {0} of {1} records", pageSize, recordCount);

            return pages;
        }

        public static string GetListItemClass(string text)
        {
            string result = "";
            switch (text)
            {
                case "<i class=\"fa fa-angle-double-left kt-font-primary\"></i>":
                    result = "kt-pagination__link--first";
                    break;
                case "<i class=\"fa fa-angle-left kt-font-primary\"></i>":
                    result = "kt-pagination__link--prev";
                    break;
                case "<i class=\"fa fa-angle-double-right kt-font-primary\"></i>":
                    result = "kt-pagination__link--last";
                    break;
                case "<i class=\"fa fa-angle-right kt-font-primary\"></i>":
                    result = "kt-pagination__link--next";
                    break;
                default: break;
            }

            return result;
        }

        public static string GetCurrentUsername()
        {
            string username = string.Format("{0}", UserType.Anonymous);
            try
            {
                if (HttpContext.Current != null
                    && HttpContext.Current.User != null
                    && HttpContext.Current.User.Identity != null
                    //&& HttpContext.Current.User.Identity.IsAuthenticated
                    )
                {
                    username = HttpContext.Current.User.Identity.Name;
                    return string.IsNullOrEmpty(username) ? string.Format("{0}", UserType.Anonymous) : username;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                username = string.Format("{0}", UserType.Anonymous);
            }

            return username;
        }

        public static string Username
        {
            get
            {
                string username = string.Format("{0}", UserType.Anonymous);
                try
                {
                    if (HttpContext.Current != null
                        && HttpContext.Current.User != null
                        && HttpContext.Current.User.Identity != null
                        //&& HttpContext.Current.User.Identity.IsAuthenticated
                        )
                    {
                        username = HttpContext.Current.User.Identity.Name;
                        return string.IsNullOrEmpty(username) ? string.Format("{0}", UserType.Anonymous) : username;
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(ex);
                    username = string.Format("{0}", UserType.Anonymous);
                }

                return username;
            }
        }

        public static bool IsUser
        {
            get
            {
                if (Username == string.Format("{0}", UserType.Anonymous)) return false;
                Dto.Cstm.tbl_User user = SessionHelper.GetUserLogin();
                if (user == null) return false;
                if (user.Roles == null) return false;
                if (user.Roles.Where(t => t.Name == string.Format("{0}", Enum.UserType.User)).Count() > 0) return true;
                else return false;
            }
        }
        public static bool IsLoggedin
        {
            get
            {
                if (Username == string.Format("{0}", UserType.Anonymous)) return false;
                else return true;
            }
        }

        public static string ToMonth(int month)
        {
            if (month <= 0 || month > 12) return "";
            string[] months = new string[] { "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember" };

            return months[month - 1];
        }

        public static List<MonthHelper> GetAllMonth()
        {
            string[] months = new string[] { "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember" };

            List<MonthHelper> list = new List<MonthHelper>();
            for (int i = 1; i <= months.Length; i++)
            {
                list.Add(new MonthHelper(i, months[i - 1]));
            }
            return list;
        }
        /// <summary>
        /// input format 10,000.32
        /// output format 10000,32
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static string ToString(decimal d)
        {
            return d.ToString(FORMAT_Money);
            //return sTemp.Replace(",", "");
        }

        public static string ToString(decimal d, string format)
        {
            return d.ToString(format);
            //return sTemp.Replace(",", "");
        }

        public static decimal ToDecimal(string p)
        {
            //string sTemp = p.Replace(",", ".");
            decimal dTemp = 0;
            decimal.TryParse(p, out dTemp);
            return dTemp;
        }

        public static string ToString(DateTime date)
        {

            return date == null ? "" : date.ToString(FORMAT_Date);
        }

        //public static bool IsValidNumberWithComma(object sender, char keyChar)
        //{
        //    if ((Keys)keyChar == Keys.Back)
        //        return true;
        //    else if (char.IsNumber(keyChar))
        //        return true;
        //    else if (string.Format("{0}", keyChar) == ".")
        //    {
        //        TextBox tb = (TextBox)sender;
        //        string[] temps = tb.Text.Split('.');
        //        //hanya boleh satu tanda titik
        //        if (temps.Length > 1) return false;
        //        return true;
        //    }

        //    return false;
        //}

        //public static bool IsValidNumber(char keyChar)
        //{
        //    if ((Keys)keyChar == Keys.Back)
        //        return true;
        //    else if (char.IsNumber(keyChar))
        //        return true;
        //    //else if (string.Format("{0}", keyChar) == ",") return true;

        //    return false;
        //}
        //public static DialogResult ShowInformation(string text)
        //{
        //    return MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}
        //public static DialogResult ShowValidation(string text)
        //{
        //    return MessageBox.Show(text, "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //}
        public const string FORMAT_Date = "dd MMM yyyy";
        public const string FORMAT_DateTime = "dd MMM yyyy HH:mm:ss";
        public const string FORMAT_DateTime_Flat = "yyyyMMddHHmmss";
        public const string FORMAT_Date_Flat = "ddMMyyyy";
        public const string FORMAT_Money = "N0";

        public static string FormatToMoney(decimal? money)
        {
            //id-ID

            return !money.HasValue ? 0.ToString() : string.Format("{0:N0}", money);
        }

        //public static bool IsSuperAdmin()
        //{
        //    List<tbl_role> roleList = Utilities.CurrentUser.Roles;
        //    return roleList.Where(t => string.Format("{0}", t.Name).Replace(" ", "").ToLower() == Config.GetSuperAdmin()).Count() > 0;
        //}

        //public static Image GetImage(Stream stream)
        //{
        //    return Image.FromStream(stream);
        //}

        //public static byte[] GetBytes(Image image)
        //{
        //    return (byte[])(new ImageConverter()).ConvertTo(image, typeof(byte[]));
        //}

        //public static byte[] StreamToBytes(Stream input)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        input.CopyTo(ms);
        //        return ms.ToArray();
        //    }
        //}

        //public static Image BytesToImage(byte[] bytes)
        //{
        //    if (bytes == null) return null;
        //    MemoryStream ms = new MemoryStream(bytes);
        //    return Image.FromStream(ms);
        //}

        //public static Bitmap Resize(byte[] bytes, Size size)
        //{
        //    int newWidth;
        //    int newHeight;
        //    Image img = BytesToImage(bytes);
        //    int originalWidth = img.Width;
        //    int originalHeight = img.Height;
        //    float percentWidth = (float)size.Width / (float)originalWidth;
        //    float percentHeight = (float)size.Height / (float)originalHeight;
        //    float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
        //    newWidth = (int)(originalWidth * percent);
        //    newHeight = (int)(originalHeight * percent);

        //    return new Bitmap(img, newWidth, newHeight);
        //}

        //public static Bitmap Resize(Stream stream, int width, int height)
        //{
        //    int newWidth;
        //    int newHeight;
        //    Image img = Image.FromStream(stream);
        //    int originalWidth = img.Width;
        //    int originalHeight = img.Height;
        //    float percentWidth = (float)width / (float)originalWidth;
        //    float percentHeight = (float)height / (float)originalHeight;
        //    float percent = percentHeight < percentWidth ? percentHeight : percentWidth;
        //    newWidth = (int)(originalWidth * percent);
        //    newHeight = (int)(originalHeight * percent);

        //    return new Bitmap(img, newWidth, newHeight);
        //}
        public static string CorrectFormat(string textValue)
        {
            //string[] temps = textValue.Split('.');
            //string temp = string.Empty;
            //if (temps.Length == 1)
            //    temp = temps[0];
            //else if (temps.Length > 1)
            //    temp = string.Format("{0},{1}", temps[0], Utilities.Crop(temps[1], 2));

            decimal decTemp = 0;
            decimal.TryParse(textValue, out decTemp);

            return ToString(decTemp);
        }

        public static string CorrectFormat(string textValue, string format)
        {
            //string[] temps = textValue.Split('.');
            //string temp = string.Empty;
            //if (temps.Length == 1)
            //    temp = temps[0];
            //else if (temps.Length > 1)
            //    temp = string.Format("{0},{1}", temps[0], Utilities.Crop(temps[1], 2));

            decimal decTemp = 0;
            decimal.TryParse(textValue, out decTemp);

            return ToString(decTemp, format);
        }


        public static string RawNumberFormat(string textValue)
        {
            //textValue = Regex.Replace(textValue, "^[0-9]", string.Empty);

            textValue = textValue.Replace(",", string.Empty);
            return textValue;
        }

        public static string StripHTML(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }
        public static string Crop(string text, int length)
        {
            if (text == null) text = string.Empty;
            text = StripHTML(text);
            if (text.Length > length)
            {
                text = text.Substring(0, length);
            }
            return text.Trim();
        }

        public static string GetComputerName()
        {
            string hostName = "HOST";
            try
            {
                var hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                hostName = hostEntry.HostName;
            }
            catch (Exception)
            {
            }

            return hostName;

        }

        public static string CurrentIPAddress
        {
            get
            {
                string UserHostAddress = "";
                try
                {
                    UserHostAddress = HttpContext.Current.Request.UserHostAddress;
                }
                catch (Exception)
                {

                }

                return UserHostAddress;

            }
        }
        public static string GetIpAddress()
        {
            string IpAddress = string.Empty;
            try
            {
                var hostEntry = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var item in hostEntry.AddressList)
                {
                    if (item.AddressFamily.ToString() == "InterNetwork")
                    {
                        IpAddress = item.ToString();
                        break;
                    }
                }
            }
            catch (Exception)
            {
            }

            return Utilities.Crop(IpAddress, 15);
        }

        
        public static byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }
    }
    public enum LogType
    {
        ERROR,
        WARNING,
        INFROMATION,
        UPDATE,
        INSERT,
        DELETE
    }
    public class Log
    {

        public static tbl_Log Error(Exception ex)
        {
            if (ex != null)
            {
                tbl_Log log = new tbl_Log();
                log.IPAddress = Utilities.GetIpAddress();
                log.LogDate = DateTime.Now;
                log.LogType = LogType.ERROR.ToString();
                log.ShortMessage = ex.Message;
                log.LongMessage = ex.ToString();
                log.Username = Utilities.Username;
                log.MechineName = Utilities.GetComputerName();

                return tbl_LogItem.Insert(log);
            }

            return new tbl_Log();
        }

        public static void Info(string message)
        {
            tbl_Log log = new tbl_Log();
            log.IPAddress = Utilities.GetIpAddress();
            log.LogDate = DateTime.Now;
            log.LogType = LogType.INFROMATION.ToString();
            log.ShortMessage = message;
            log.LongMessage = message;
            log.Username = Utilities.Username;
            log.MechineName = Utilities.GetComputerName();
            tbl_LogItem.Insert(log);
        }

        //public static void Warning(string message)
        //{
        //    //tbl_LogItem.Insert(Utilities.GetComputerName(), Utilities.GetIpAddress(), LogType.WARNING.ToString(), message, Utilities.Username);
        //}

        //public static void Delete(string message)
        //{
        //    //tbl_LogItem.Insert(Utilities.GetComputerName(), Utilities.GetIpAddress(), LogType.DELETE.ToString(), message, Utilities.Username);
        //}

        //public static int Insert(string message)
        //{
        //    return 1;
        //    //return tbl_LogItem.Insert(Utilities.GetComputerName(), Utilities.GetIpAddress(), LogType.INSERT.ToString(), message, Utilities.Username);
        //}

        //public static void Update(string message)
        //{
        //    //tbl_LogItem.Insert(Utilities.GetComputerName(), Utilities.GetIpAddress(), LogType.UPDATE.ToString(), message, Utilities.Username);
        //}


        //public static async void Write(string message)
        //{
        //    await tbl_LogItem.InsertAsync(Utilities.GetComputerName(), Utilities.GetIpAddress(), LogType.UPDATE.ToString(), message, "", Utilities.Username);
        //}
    }
}
