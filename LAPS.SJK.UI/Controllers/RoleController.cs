using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAPS.SJK.Dta;
using LAPS.SJK.Dto;
using LAPS.SJK.Logic;
using LAPS.SJK.UI.Models;

namespace LAPS.SJK.UI.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index()
        {
            List<RoleModel> result = new List<Models.RoleModel>();
            List<tbl_role> list = Dta.tbl_roleItem.GetAll();
            list.ForEach(t => { result.Add(new RoleModel(t)); });
            return View(result);
        }

        // GET: Role/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Add(RoleModel model)
        {
            try
            {
                tbl_role result = null;
                // TODO: Add insert logic here
                tbl_role item = new tbl_role();
                item.Name = model.Name;
                item.Description = model.Description;
                item.CreatedDate = DateTime.Now;
                item.CreatedBy = Utilities.Username;
                item.is_deleted = 0;

                result = tbl_roleItem.GetByName(model.Name);
                if (result != null)
                {
                    ModelState.AddModelError("", string.Format("{0} sudah ada.", model.Name));
                    return View();
                }

                result = tbl_roleItem.Insert(item);
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

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            tbl_role item = Dta.tbl_roleItem.GetByPK(id);
            return View(new RoleModel(item));
        }

        // POST: Role/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RoleModel model)
        {
            try
            {
                tbl_role result = null;
                // TODO: Add update logic here
                tbl_role item = tbl_roleItem.GetByPK(id);

                if (item != null)
                {
                    item.Name = model.Name;
                    item.Description = model.Description;
                    item.ModifiedDate = DateTime.Now;
                    item.ModifiedBy = Utilities.Username;
                    result = tbl_roleItem.Update(item);
                    //update
                }
                else
                {
                    item = new tbl_role();
                    item.Name = model.Name;
                    item.Description = model.Description;
                    item.CreatedDate = DateTime.Now;
                    item.CreatedBy = Utilities.Username;
                    item.is_deleted = 0;
                    result = tbl_roleItem.Insert(item);
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

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            // TODO: Add update logic here
            tbl_role item = tbl_roleItem.GetByPK(id);
            int result = tbl_roleItem.Delete(id);

            if (result > 0)
            {
                ModelState.AddModelError("", "Ups, Data tidak dapat tersimpan!");
                return View();
            }
            return RedirectToAction("Index");
            //return View();
        }

      
    }
}
