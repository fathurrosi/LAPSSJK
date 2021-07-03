using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LAPS.SJK.Dto;

namespace LAPS.SJK.UI.Models
{
    public class FieldValueModel
    {
        /// <summary>
        /// template id
        /// </summary>
        public int id { get; set; }
        public int row_index { get; set; }
        public HttpPostedFileBase posted_file { get; set; }
        public List<tbl_post_list_value> values { get; set; }
        public List<tbl_post_list_field> field { get; set; }
    }
}