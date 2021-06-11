using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    public partial class tbl_combo_detailItem
    {
        public static List<tbl_combo_detail> GetByHeader(string header)
        {
            List<tbl_combo_detail> result = GetAll().Where(t => t.header == header).ToList();
            result = result.OrderBy(t => t.sequence).ToList();

            //result.Insert(0, new tbl_combo_detail() { name="Jenis Dokumen" });
            return result;
        }


        //public static List<tbl_combo_detail> GetImgPosition()
        //{
        //    List<tbl_combo_detail> result = new List<tbl_combo_detail>();
        //    result.Add(new tbl_combo_detail() { id = 1, name = "Sebelah Kiri" });
        //    result.Add(new tbl_combo_detail() { id = 2, name = "Sebelah Kanan" });
        //    return result;
        //}


        public static List<tbl_combo_detail> GetTipeKanlender()
        {
            List<tbl_combo_detail> result = GetAll().Where(t => t.header == "Tipe Kalender").ToList();
            return result;
        }

        public static List<tbl_combo_detail> GetCollateral_Corporate_Category()
        {
            List<tbl_combo_detail> result = GetAll().Where(t => t.header == "Collateral_Corporate_Category").ToList();
            return result;
        }
    }
}
