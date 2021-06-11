using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAPS.SJK.UI.Controllers
{
    public class AboutController : Controller
    {
        
        // GET: About
        public ActionResult TentangKami()
        {
            return View();
        }

        public ActionResult Pendirian()
        {
            return View();
        }


        public ActionResult Struktur()
        {
            return View();
        }


        public ActionResult Keanggotaan()
        {
            return View();
        }

        public ActionResult Pengawas()
        {
            return View();
        }


        public ActionResult Pengurus()
        {
            return View();
        }


        public ActionResult Komite()
        {
            return View();
        }


//        /About/Pendirian
///About/Struktur
///About/Kenggotaan
///About/Pengawas
///About/Pengurus
///About/Komite

        // GET: About
        public ActionResult Index()
        {
            return View();
        }

        // GET: About/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: About/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: About/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: About/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: About/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: About/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: About/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
