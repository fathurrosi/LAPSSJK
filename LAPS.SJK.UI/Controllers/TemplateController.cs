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

namespace LAPS.SJK.UI.Areas.Admin.Controllers
{
    public class TemplateController : Controller
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
            TemplateModel model = new TemplateModel();
            tbl_post_list_template item = tbl_post_list_templateItem.GetByPK(id);
            if (item != null)
            {
                model = new TemplateModel(item);
                model.fields = tbl_post_list_fieldItem.GetByid_template(item.id);
            }
            return View(model);
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
        public ActionResult Preview(int id)
        {
            TemplateModel model = new TemplateModel();
            tbl_post_list_template item = tbl_post_list_templateItem.GetByPK(id);
            if (item != null)
            {
                model = new TemplateModel(item);
                model.fields = tbl_post_list_fieldItem.GetByid_template(item.id);
            }
            return View(model);
        }


        // GET: Default/Edit/5
        public ActionResult EditColumn(int id)
        {

            FieldModel model = new FieldModel();
            tbl_post_list_field item = tbl_post_list_fieldItem.GetByPK(id);
            if (item != null)
            {
                tbl_post_list_template templateItem = tbl_post_list_templateItem.GetByPK(item.id_template.Value);
                model = new FieldModel(item);
                model.template_name = templateItem.template_name;
            }
            List<SelectListItem> types = new List<SelectListItem>();
            List<tbl_combo_detail> dataTypeList = tbl_combo_detailItem.GetByHeader("DataType");
            dataTypeList.ForEach(t => { types.Add(new SelectListItem() { Value = t.id.ToString(), Text = t.name }); });
            model.DataTypeList = types;


            return View(model);
        }

        [HttpPost]
        public ActionResult EditColumn(FieldModel model)
        {
            tbl_post_list_field result = null;
            tbl_post_list_field item = tbl_post_list_fieldItem.GetByPK(model.id);
            if (item != null)
            {
                item.id = model.id;
                item.id_template = model.id_template;
                item.column_name = string.Format("{0}", model.column_name).Replace(" ", "_");
                item.column_alias = model.column_name;
                item.column_seq = model.column_seq;
                item.column_data_type = model.column_data_type;
                item.max_lenth = model.max_lenth;
                item.default_value = model.default_value;
                item.is_mandatory = model.is_mandatory;
                item.is_deleted = model.is_deleted;
                item.edited = DateTime.Now;
                item.editor = Utilities.Username;

                result = tbl_post_list_fieldItem.Update(item);
            }
            else
            {
                item = new tbl_post_list_field();
                item.created = DateTime.Now;
                item.creator = Utilities.Username;
                item.id = model.id;
                item.id_template = model.id_template;
                item.column_name = string.Format("{0}", model.column_name).Replace(" ", "_");
                item.column_alias = model.column_name;
                item.column_seq = model.column_seq;
                item.column_data_type = model.column_data_type;
                item.max_lenth = model.max_lenth;
                item.default_value = model.default_value;
                item.is_mandatory = model.is_mandatory;
                item.is_deleted = model.is_deleted;

                result = tbl_post_list_fieldItem.Insert(item);
            }

            if (result == null)
            {
                ModelState.AddModelError("", "Ups, Data tidak dapat tersimpan!");
                return View();
            }


            return RedirectToAction("Edit", new { id = model.id_template });
        }


        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult AddColumn(int tid)
        {
            FieldModel model = new FieldModel();
            model.id_template = tid;
            tbl_post_list_template templateItem = tbl_post_list_templateItem.GetByPK(tid);
            model.template_name = templateItem.template_name;

            List<SelectListItem> types = new List<SelectListItem>();
            List<tbl_combo_detail> dataTypeList = tbl_combo_detailItem.GetByHeader("DataType");
            dataTypeList.ForEach(t => { types.Add(new SelectListItem() { Value = t.id.ToString(), Text = t.name }); });
            model.DataTypeList = types;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddColumn(FieldModel model)
        {
            tbl_post_list_field result = null;

            tbl_post_list_field item = new tbl_post_list_field();

            item = new tbl_post_list_field();
            item.created = DateTime.Now;
            item.creator = Utilities.Username;
            item.id = model.id;
            item.id_template = model.id_template;
            item.column_name = string.Format("{0}", model.column_name).Replace(" ", "_");
            item.column_alias = model.column_name;
            item.column_seq = model.column_seq;
            item.column_data_type = model.column_data_type;
            item.max_lenth = model.max_lenth;
            item.default_value = model.default_value;
            item.is_mandatory = model.is_mandatory;
            item.is_deleted = 0;
            item.id_template = model.id_template;
            result = tbl_post_list_fieldItem.Insert(item);

            if (result == null)
            {
                ModelState.AddModelError("", "Ups, Data tidak dapat tersimpan!");
                return View();
            }

            return RedirectToAction("Edit", new { id = model.id_template });
        }


        public ActionResult DeleteColumn(int id)
        {
            tbl_post_list_field item = tbl_post_list_fieldItem.GetByPK(id);
            if (item == null) ModelState.AddModelError("", "Data tidak ditemukan!");
            else
            {
                item.is_deleted = 1;
                tbl_post_list_fieldItem.Update(item);
            }
            return RedirectToAction("Edit", new { id = item.id_template });
        }
    }
}
