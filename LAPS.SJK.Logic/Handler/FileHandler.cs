using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using LAPS.SJK.Dto;

namespace LAPS.SJK.Logic.Handler
{
    public enum FileTypes
    {
        Image,
        Document,
    }
    public class FileHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        //public static int UpdateTable(tbl_files file)
        //{
        //    string username = Utilities.Username;
        //    int result = -1;
        //    int id = 0;
        //    int.TryParse(file.ReferenceID, out id);
        //    DateTime range1 = DateTime.Now.AddSeconds(-3);
        //    DateTime range2 = DateTime.Now.AddSeconds(3);

        //    if (file.ReferenceTable == ReferenceTable.tbl_informasi_berkala.ToString())
        //    {
        //        tbl_informasi_berkala item = tbl_informasi_berkalaItem.GetByID(id);
        //        item.lastDownloadBy = username;
        //        item.downloaded += 1;
        //        if (!(range1 <= item.lastDownloadDate && item.lastDownloadDate <= range2))
        //            result = tbl_informasi_berkalaItem.UpdateDownload(item);
        //    }
        //    else if (file.ReferenceTable == ReferenceTable.tbl_laporan.ToString())
        //    {
        //        tbl_laporan item = tbl_laporanItem.GetByID(id);
        //        item.downloaded += 1;
        //        item.lastDownloadBy = username;
        //        if (!(range1 <= item.lastDownloadDate && item.lastDownloadDate <= range2))
        //            result = tbl_laporanItem.UpdateDownload(item);
        //    }
        //    else if (file.ReferenceTable == ReferenceTable.tbl_regulasi.ToString())
        //    {
        //        tbl_regulasi item = tbl_regulasiItem.GetByID(id);
        //        item.downloaded += 1;
        //        item.lastDownloadBy = username;
        //        if (!(range1 <= item.lastDownloadDate && item.lastDownloadDate <= range2))
        //            result = tbl_regulasiItem.UpdateDownload(item);
        //    }

        //    return result;
        //}

        public void ProcessRequest(HttpContext context)
        {
            //    HttpResponse response = context.Response;
            //    HttpRequest request = context.Request;

            //    string FileID = request["FileID"];
            //    try
            //    {

            //        tbl_files file = tbl_filesItem.GetByID(FileID);

            //        if (file != null)
            //        {
            //            string fileName = file.FileName;
            //            string[] exts = fileName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
            //            string ext = string.Empty;
            //            if (exts.Length > 0)
            //                ext = exts.Last();

            //            int Length = file.FileBinary.Length;
            //            if (!string.IsNullOrEmpty(ext) && ext.ToLower().Equals("pdf"))
            //            {
            //                response.AddHeader("Accept-Ranges", "bytes");
            //                response.AddHeader("Accept-Header", Length.ToString());
            //                response.AddHeader("Cache-Control", "public");
            //                response.AddHeader("Cache-Control", "must-revalidate");
            //                response.AddHeader("Pragma", "public");
            //                response.AddHeader("expires", "0");
            //                response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", file.FileName));
            //                response.ContentType = "application/octet-stream";
            //                response.BufferOutput = true;
            //                response.BinaryWrite(file.FileBinary);
            //                response.Flush();
            //            }
            //            else
            //            {
            //                response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", file.FileName));
            //                response.ContentType = ext;
            //                response.BufferOutput = true;
            //                response.BinaryWrite(file.FileBinary);
            //                response.Flush();
            //            }

            //            UpdateTable(file);
            //        }
            //        else
            //        {
            //            //response.StatusCode = 404;
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //response.StatusCode = 404;
            //        Log.Error(ex);
            //    }

            //    response.End();
        }


    }
}
