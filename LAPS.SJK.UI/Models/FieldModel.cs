using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAPS.SJK.UI.Models
{
    public class FieldModel : Dto.tbl_post_list_field
    {
        public FieldModel()
        { }
        public FieldModel(Dto.tbl_post_list_field item)
        {
            this.id = item.id;
            this.id_template = item.id_template;
            this.column_name = item.column_name;
            this.column_alias = item.column_alias;
            this.column_seq = item.column_seq;
            this.column_data_type = item.column_data_type;
            this.max_lenth = item.max_lenth;
            this.default_value = item.default_value;
            this.is_mandatory = item.is_mandatory.HasValue ? item.is_mandatory.Value : false;
        }

        [Display(Name = "Template")]
        public new Int32? id_template { get; set; }

        [Display(Name = "Nama Kolom")]
        public new string column_name { get; set; }

        [Display(Name = "Alias")]
        public new string column_alias { get; set; }

        [Display(Name = "Urutan")]
        public new Int32? column_seq { get; set; }

        [Display(Name = "Tipe Data")]
        public new Int32? column_data_type { get; set; }

        [Display(Name = "Max Length")]
        public new Int32? max_lenth { get; set; }

        [Display(Name = "Default Value")]
        public new string default_value { get; set; }

        [Display(Name = "Mandatory?")]
        public new bool is_mandatory { get; set; }

        public string template_name { get; set; }
        public IEnumerable<SelectListItem> TemplateList { get; set; }
        public IEnumerable<SelectListItem> DataTypeList { get; set; }
    }
}