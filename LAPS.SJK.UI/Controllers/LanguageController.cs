using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAPS.SJK.UI.Controllers
{
    public class LanguageController : BaseController
    {
        // GET: Language
        public ActionResult Index()
        {
            return View();
        }


        //public ActionResult Change(String LanguageAbbrevation)
        //{
        //    if (LanguageAbbrevation != null)
        //    {
        //        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
        //        Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);
        //    }
        //    HttpCookie cookie = new HttpCookie("Language");
        //    cookie.Value = LanguageAbbrevation;
        //    Response.Cookies.Add(cookie);

        //    return View("Index");
        //}
    }
}