using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LAPS.SJK.Dta;
using LAPS.SJK.Dto;
using LAPS.SJK.Logic;
using LAPS.SJK.Logic.Enum;
using LAPS.SJK.UI.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace LAPS.SJK.UI.Areas.Admin.Controllers
{
    public class TemplateController : Controller
    {


        public ActionResult Index()
        {
            List<tbl_post_list_template> list = tbl_post_list_templateItem.GetAll();
            return View(list);
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
                model.values = tbl_post_list_valueItem.GetByid_template(item.id);
            }
            return View(model);
        }

        public ActionResult Upload(int id)
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
        public ActionResult Upload(int id, HttpPostedFileBase postedFile)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null && postedFile.ContentLength > (1024 * 1024 * 50))  // 50MB limit  
                {
                    ModelState.AddModelError("postedFile", "Your file is to large. Maximum size allowed is 50MB !");
                }

                else
                {
                    NPOI.HSSF.UserModel.HSSFWorkbook hSSFWorkbook = new NPOI.HSSF.UserModel.HSSFWorkbook(postedFile.InputStream);
                    NPOI.SS.UserModel.ISheet sheet = hSSFWorkbook.GetSheetAt(0);
                    for (int row = 1; row <= sheet.LastRowNum; row++)
                    {
                        var sheetRow = sheet.GetRow(row);
                        if (sheetRow != null)
                        {
                            string test = sheetRow.GetCell(0).StringCellValue;
                            //sheetRow.GetCell(1).StringCellValue;
                        }
                    }
                }
            }
            //return View(postedFile);  
            return Json("no files were selected !");
        }
        public ActionResult EditValue(int id, int row_index)
        {
            FieldValueModel model = new FieldValueModel();
            model.id = id;
            model.row_index = row_index;
            model.field = tbl_post_list_fieldItem.GetByid_template(id);
            model.values = tbl_post_list_valueItem.GetByid_template(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult EditValue(int id, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int max_row_index = tbl_post_list_valueItem.GetMaxRowIndex(id);
                List<tbl_post_list_value> values = new List<tbl_post_list_value>();
                foreach (string key in form.AllKeys)
                {
                    if (!key.StartsWith("__") && key.StartsWith("_"))
                    {
                        tbl_post_list_value value = new tbl_post_list_value();
                        value.value_field = form[key];

                        //string.Format("_{0}_{1}_{2}", field.id_template, field.id, value.row_index)
                        int id_template = 0;
                        int id_field = 0;
                        int row_index = 0;
                        string[] temps = key.Split('_');
                        int.TryParse(temps[1], out id_template);
                        int.TryParse(temps[2], out id_field);
                        int.TryParse(temps[3], out row_index);
                        value.id_template = id_template;
                        value.id_field = id_field;
                        value.row_index = row_index == 0 ? max_row_index : row_index;

                        values.Add(value);
                    }
                }

                tbl_post_list_valueItem.Update(values);
            }
            return RedirectToAction("Preview", new { id = id });
        }

        public ActionResult DeleteValue(int id, int row_index)
        {
            tbl_post_list_valueItem.Delete(id, row_index);
            return RedirectToAction("Preview", new { id = id });
        }
        public ActionResult AddValue(int id)
        {
            FieldValueModel model = new FieldValueModel();
            model.id = id;
            model.row_index = 0;
            model.field = tbl_post_list_fieldItem.GetByid_template(id);
            model.values = tbl_post_list_valueItem.GetByid_template(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult AddValue(int id, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                int max_row_index = tbl_post_list_valueItem.GetMaxRowIndex(id);
                List<tbl_post_list_value> values = new List<tbl_post_list_value>();
                foreach (string key in form.AllKeys)
                {
                    if (!key.StartsWith("__") && key.StartsWith("_"))
                    {
                        tbl_post_list_value value = new tbl_post_list_value();
                        value.value_field = form[key];

                        //string.Format("_{0}_{1}_{2}", field.id_template, field.id, value.row_index)
                        int id_template = 0;
                        int id_field = 0;
                        int row_index = 0;
                        string[] temps = key.Split('_');
                        int.TryParse(temps[1], out id_template);
                        int.TryParse(temps[2], out id_field);
                        int.TryParse(temps[3], out row_index);
                        value.id_template = id_template;
                        value.id_field = id_field;
                        value.row_index = row_index == 0 ? max_row_index : row_index;

                        values.Add(value);
                    }
                }

                tbl_post_list_valueItem.Insert(values);
            }
            return RedirectToAction("Preview", new { id = id });
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
