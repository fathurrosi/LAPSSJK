using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAPS.SJK.Dta;
using LAPS.SJK.Dto;
using LAPS.SJK.Logic;
using LAPS.SJK.UI.Models;

namespace LAPS.SJK.UI.Controllers
{
    public class LanguageController : BaseController
    {
        // GET: Language
        public ActionResult Index(LanguageModel model)
        {
            if (model == null) model = new Models.LanguageModel();
            List<tbl_combo_detail> langList = tbl_combo_detailItem.GetByHeader("Lang");

            List<SelectListItem> Options = new List<SelectListItem>();
            langList.ForEach(t => { Options.Add(new SelectListItem() { Value = t.name, Text = t.note }); });
            model.Options = Options;
            model.List = tbl_labelItem.GetAll().Where(t => t.c_flag == model.Selected || string.IsNullOrEmpty(model.Selected)).ToList();
            return View(model);
        }


        public ActionResult Edit(string name, string c_flag)
        {
            tbl_label item = Dta.tbl_labelItem.GetByPK(name, c_flag);
            return View(new LanguageModel(item));
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(string name, string c_flag, LanguageModel model)
        {
            try
            {
                tbl_label result = null;
                // TODO: Add update logic here
                tbl_label item = tbl_labelItem.GetByPK(name, c_flag);

                if (item != null)
                {
                    item.name = model.name;
                    item.c_flag = model.c_flag;
                    item.value = model.value;
                    item.edited = DateTime.Now;
                    item.editor = Utilities.Username;
                    result = tbl_labelItem.Update(item);
                    //update
                }
                else
                {
                    item = new tbl_label();
                    item.name = model.name;
                    item.c_flag = model.c_flag;
                    item.value = model.value;
                    item.created = DateTime.Now;
                    item.creator = Utilities.Username;
                    //item.is_deleted = 0;
                    result = tbl_labelItem.Insert(item);
                }

                if (result == null)
                {
                    ModelState.AddModelError("", "Ups, Data tidak dapat tersimpan!");
                    return View();
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string name, string c_flag)
        {
            // TODO: Add update logic here
            tbl_label item = tbl_labelItem.GetByPK(name, c_flag);
            int result = tbl_labelItem.Delete(name, c_flag);

            if (result == 0)
            {
                ModelState.AddModelError("", "Ups, Data tidak dapat tersimpan!");

            }
            return RedirectToAction("Index");
            //return View();
        }
        public ActionResult Add()
        {
            LanguageModel model = new LanguageModel();
            List<tbl_combo_detail> langList = tbl_combo_detailItem.GetByHeader("Lang");

            List<SelectListItem> Options = new List<SelectListItem>();
            langList.ForEach(t => { Options.Add(new SelectListItem() { Value = t.name, Text = t.note }); });
            model.Options = Options;
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(LanguageModel model)
        {
            try
            {
                List<tbl_combo_detail> langList = tbl_combo_detailItem.GetByHeader("Lang");

                List<SelectListItem> Options = new List<SelectListItem>();
                langList.ForEach(t => { Options.Add(new SelectListItem() { Value = t.name, Text = t.note }); });

                tbl_label result = null;
                // TODO: Add insert logic here
                tbl_label item = new tbl_label();
                item.name = model.name;
                item.c_flag = model.c_flag;
                item.value = model.value;
                item.created = DateTime.Now;
                item.creator = Utilities.Username;

                if (string.IsNullOrEmpty(item.c_flag))
                {

                    ModelState.AddModelError("", string.Format("Language is mandatory"));
                    model.Options = Options;
                    return View(model);
                }

                result = tbl_labelItem.GetByPK(model.name, model.c_flag);
                if (result != null)
                {
                    ModelState.AddModelError("", string.Format("{0} sudah ada.", model.name));
                    model.Options = Options;
                    return View(model);
                }

                result = tbl_labelItem.Insert(item);
                if (result == null)
                {
                    ModelState.AddModelError("", "Ups, Data tidak dapat tersimpan!");
                    model.Options = Options;
                    return View(model);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

    }
}