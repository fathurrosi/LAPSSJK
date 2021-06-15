using LAPS.SJK.Dta;
using LAPS.SJK.Dto;
using LAPS.SJK.Dto.Cstm;
using LAPS.SJK.Logic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAPS.SJK.UI.Controllers
{
    public class PageController : Controller
    {
        // GET: Page

        public ActionResult Content_Blog(string id)
        {
            int idx = 0;
            List<tbl_page_content_result> objContentTextResult = new List<tbl_page_content_result>(); tbl_page_content_result obj = new tbl_page_content_result();
            DataTable dt = new DataTable();
            Int32.TryParse(id, out idx);
            if (idx == 0) { return RedirectToAction("Index", "Default"); }

            List<tbl_page_content> objContent = tbl_page_contentItem.getByMenuID(idx);
            foreach (tbl_page_content o in objContent)
            {
                if (o.post_type.ToUpper() == "TEXT" || o.post_type.ToUpper() == "PDFVIEW")
                {
                    obj = tbl_page_contentItem.getContentTextByDetailID(o.post_detail_id);
                    objContentTextResult.Add(obj);
                }
                else if (o.post_type.ToUpper() == "TABLE")
                {
                    dt = tbl_page_contentItem.getContentTableByDetailID(o.post_detail_id);
                    obj = GenerateTableHTML.generatePageTableData(dt, o.post_order, o.post_type);
                    objContentTextResult.Add(obj);
                }
                else if (o.post_type.ToUpper() == "PDFLIST")
                {

                }


            }


            var tupleModel = new Tuple<tbl_menu, List<tbl_page_content_result>>(tbl_menuItem.GetByPK(idx), objContentTextResult);
            return View(tupleModel);
        }

        public ActionResult Content_News(string id)
        {
            return View();
        }

        public ActionResult Content_List_Image1(string id)
        {
            return View();
        }

        public ActionResult Content_List_Image2(string id)
        {
            return View();
        }

    }
}