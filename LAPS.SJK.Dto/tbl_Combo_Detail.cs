
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_combo_detail : IDataMapper<tbl_combo_detail>
    {
        #region tbl_combo_detail Properties
        public string name { get; set; }
        public string note { get; set; }
        public string parent { get; set; }
        public string header { get; set; }
        public Int32? sequence { get; set; }
        public Int32 id { get; set; }
        #endregion    
        public tbl_combo_detail Map(System.Data.IDataReader reader)
        {
            tbl_combo_detail obj = new tbl_combo_detail();   
            obj.name = reader["name"] == DBNull.Value ? null : reader["name"].ToString();
            obj.note = reader["note"] == DBNull.Value ? null : reader["note"].ToString();
            obj.parent = reader["parent"] == DBNull.Value ? null : reader["parent"].ToString();
            obj.header = reader["header"] == DBNull.Value ? null : reader["header"].ToString();
            obj.sequence = reader["sequence"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["sequence"]);
            obj.id = Convert.ToInt32(reader["id"]);
            return obj;
        }
    }
}