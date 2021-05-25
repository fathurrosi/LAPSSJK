
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_Combo_Detail : IDataMapper<tbl_Combo_Detail>
    {
        #region tbl_Combo_Detail Properties
        public string name { get; set; }
        public string parent { get; set; }
        public string header { get; set; }
        public Int32? sequence { get; set; }
        public Int32 id { get; set; }
        #endregion    
        public tbl_Combo_Detail Map(System.Data.IDataReader reader)
        {
            tbl_Combo_Detail obj = new tbl_Combo_Detail();   
            obj.name = reader["name"] == DBNull.Value ? null : reader["name"].ToString();
            obj.parent = reader["parent"] == DBNull.Value ? null : reader["parent"].ToString();
            obj.header = reader["header"] == DBNull.Value ? null : reader["header"].ToString();
            obj.sequence = reader["sequence"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["sequence"]);
            obj.id = Convert.ToInt32(reader["id"]);
            return obj;
        }
    }
}