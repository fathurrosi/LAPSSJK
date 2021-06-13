using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LAPS.SJK.Dta;
using LAPS.SJK.Dto;
using LAPS.SJK.Logic;
using LAPS.SJK.Logic.Enum;
using LAPS.SJK.UI.Models;

namespace LAPS.SJK.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            List<tbl_post_list_template> list = tbl_post_list_templateItem.GetAllActive();
            return View(list);
        }
        public ActionResult Forgot()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel user)
        {
            if (ModelState.IsValid)
            {

                string usernname = user.Username;
                string password = Security.MD5Hash(user.Password.Trim());
                #region Login

                Log.Info(string.Format("User :{0}-{1} try to log in", usernname, password));

                Dto.Cstm.tbl_user Item = tbl_userItem.GetUser(usernname);
                if (Item != null && Item.Password == password &&
                    Item.Roles.Where(t => string.Format("{0}", t.Name).ToLower() == string.Format("{0}", UserType.Administrator).ToLower()).Count() > 0)
                {
                    tbl_userItem.UpdateLogin(user.Username, "", "");
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index");
                }

                #endregion
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }

        public ActionResult Delete(int id)
        {
            tbl_post_list_template item = tbl_post_list_templateItem.GetByPK(id);
            if (item == null) ModelState.AddModelError("", "Data tidak ditemukan!");
            else
            {
                tbl_post_list_templateItem.SetAsDeleted(id);
            }
            return RedirectToAction("Index");
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            tbl_post_list_template item = tbl_post_list_templateItem.GetByPK(id);

            return View(new TemplateModel(item));
        }

        [HttpPost]
        public ActionResult Edit(TemplateModel model)
        {
            tbl_post_list_template result = null;
            tbl_post_list_template item = tbl_post_list_templateItem.GetByPK(model.id);
            if (item != null)
            {
                item.template_name = model.template_name;
                item.remark = model.remark;
                result = tbl_post_list_templateItem.Update(item);
            }
            else
            {
                item = new tbl_post_list_template();
                item.created = DateTime.Now;
                item.creator = Utilities.Username;
                item.template_name = model.template_name;
                item.remark = model.remark;
                result = tbl_post_list_templateItem.Insert(item);
            }

            if (result == null)
            {
                ModelState.AddModelError("", "Ups, Data tidak dapat tersimpan!");
                return View();
            }


            return RedirectToAction("Index");
        }


        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TemplateModel model)
        {
            tbl_post_list_template result = null;

            tbl_post_list_template item = new tbl_post_list_template();
            item.created = DateTime.Now;
            item.creator = Utilities.Username;
            item.template_name = model.template_name;
            item.remark = model.remark;
            item.is_deleted = 0;
            result = tbl_post_list_templateItem.Insert(item);

            if (result == null)
            {
                ModelState.AddModelError("", "Ups, Data tidak dapat tersimpan!");
                return View();
            }


            return RedirectToAction("Index");
        }
    }
}
