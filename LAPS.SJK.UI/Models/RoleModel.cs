using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAPS.SJK.UI.Models
{
    public class RoleModel : Dto.tbl_role
    {
        public RoleModel()
        { }
        public RoleModel(Dto.tbl_role item)
        {
            this.ID = item.ID;
            this.Name = item.Name;
            this.Description = item.Description;
            this.created= item.created;
            this.creator= item.creator;
            this.edited= item.edited;
            this.editor= item.editor;

        }

        [Display(Name = "Nama")]
        public new string Name { get; set; }

        [Display(Name = "Keterangan")]
        public new string Description { get; set; }
    }
}