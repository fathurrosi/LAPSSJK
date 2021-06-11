
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_post_detail : IDataMapper<tbl_post_detail>
    {
        #region tbl_post_detail Properties
        public Int32 post_detail_id { get; set; }
        public Int32? post_id { get; set; }
        public string post_type { get; set; }
        public Int32? post_order { get; set; }
        #endregion    
        public tbl_post_detail Map(System.Data.IDataReader reader)
        {
            tbl_post_detail obj = new tbl_post_detail();   
            obj.post_detail_id = Convert.ToInt32(reader["post_detail_id"]);
            obj.post_id = reader["post_id"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["post_id"]);
            obj.post_type = reader["post_type"] == DBNull.Value ? null : reader["post_type"].ToString();
            obj.post_order = reader["post_order"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["post_order"]);
            return obj;
        }
    }
}