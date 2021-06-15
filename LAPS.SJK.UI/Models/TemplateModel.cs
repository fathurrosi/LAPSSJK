using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using LAPS.SJK.Dto;
using LAPS.SJK.UI.App_LocalResources;

namespace LAPS.SJK.UI.Models
{
    public class TemplateModel : tbl_post_list_template
    {
        public TemplateModel() { }
        public TemplateModel(tbl_post_list_template item)
        {
            this.id = item.id;
            this.template_name = item.template_name;
            this.remark = item.remark;
            this.created = item.created;
            this.creator = item.creator;
            this.is_deleted = item.is_deleted;
        }

        [Display(Name = "Nama Template")]
        public new string template_name { get; set; }

        [Display(Name = "Keterangan")]
        public new string remark { get; set; }

        public List<tbl_post_list_field> ColumnList { get; set; }
    }
}