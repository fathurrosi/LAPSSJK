
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_post : IDataMapper<tbl_post>
    {
        #region tbl_post Properties
        public Int32 post_id { get; set; }
        public string name { get; set; }
        public Int32? cat_id { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public tbl_post Map(System.Data.IDataReader reader)
        {
            tbl_post obj = new tbl_post();   
            obj.post_id = Convert.ToInt32(reader["post_id"]);
            obj.name = string.Format("{0}",reader["name"]);
            obj.cat_id = reader["cat_id"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["cat_id"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}