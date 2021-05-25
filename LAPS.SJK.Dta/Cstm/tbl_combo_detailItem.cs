using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    public partial class tbl_Combo_DetailItem
    {
        public static List<tbl_Combo_Detail> GetByHeader(string header)
        {
            List<tbl_Combo_Detail> result = GetAll().Where(t => t.header == header).ToList();
            result = result.OrderBy(t => t.sequence).ToList();

            //result.Insert(0, new tbl_Combo_Detail() { name="Jenis Dokumen" });
            return result;
        }


        //public static List<tbl_Combo_Detail> GetImgPosition()
        //{
        //    List<tbl_Combo_Detail> result = new List<tbl_Combo_Detail>();
        //    result.Add(new tbl_Combo_Detail() { id = 1, name = "Sebelah Kiri" });
        //    result.Add(new tbl_Combo_Detail() { id = 2, name = "Sebelah Kanan" });
        //    return result;
        //}


        public static List<tbl_Combo_Detail> GetTipeKanlender()
        {
            List<tbl_Combo_Detail> result = GetAll().Where(t => t.header == "Tipe Kalender").ToList();
            return result;
        }

        public static List<tbl_Combo_Detail> GetCollateral_Corporate_Category()
        {
            List<tbl_Combo_Detail> result = GetAll().Where(t => t.header == "Collateral_Corporate_Category").ToList();
            return result;
        }
    }
}
