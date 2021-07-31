using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LAPS.SJK.Dto;

namespace LAPS.SJK.UI.Models
{
    public class LanguageModel : Dto.tbl_label
    {
        public LanguageModel() { }
        public LanguageModel(Dto.tbl_label model)
        {
            if (model != null)
            {
                this.c_flag = model.c_flag;
                this.name = model.name;
                this.value = model.value;
            }
        }
        public List<tbl_label> List { get; set; }

        public string Selected { get; set; }
        public IEnumerable<SelectListItem> Options { get; set; }
    }
}