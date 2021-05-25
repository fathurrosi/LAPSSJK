using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using LAPS.SJK.Dto;

namespace LAPS.SJK.Logic.Handler
{
    public class ImageHandler : IHttpHandler
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            HttpResponse response = context.Response;
            HttpRequest request = context.Request;

            string FileID = request["FileID"];

            try
            {
                //if (string.IsNullOrEmpty(FileID))
                //    response.Redirect("~/_layouts/HCIS/Images/noImageAvailable300.gif");
                //tbl_Files file = tbl_FilesItem.GetByID(FileID);
                //if (file != null)
                //{
                //    string fileName = file.FileName;
                //    string[] exts = fileName.Split(new string[] { "." }, StringSplitOptions.RemoveEmptyEntries);
                //    string ext = string.Empty;
                //    if (exts.Length > 0)
                //        ext = exts.Last();


                //    response.ContentType = ext;
                //    int Length = file.FileBinary.Length;
                //    response.AddHeader("Content-Length", Length.ToString());
                //    response.AddHeader("Content-Disposition", String.Format("filename={0}", file.FileName));
                //    response.OutputStream.Write(file.FileBinary, 0, Length);

                //    response.Flush();
                //}
                //else
                //    response.Redirect("~/_layouts/HCIS/Images/default-male.jpg");
            }
            catch (Exception ex)
            {
                response.Redirect(ex.Message);
            }
        }

        #endregion
    }
}
