
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_post_content_text : IDataMapper<tbl_post_content_text>
    {
        #region tbl_post_content_text Properties
        public Int32 id_post_text { get; set; }
        public Int32? post_detail_id { get; set; }
        public string content_text { get; set; }
        #endregion    
        public tbl_post_content_text Map(System.Data.IDataReader reader)
        {
            tbl_post_content_text obj = new tbl_post_content_text();   
            obj.id_post_text = Convert.ToInt32(reader["id_post_text"]);
            obj.post_detail_id = reader["post_detail_id"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["post_detail_id"]);
            obj.content_text = reader["content_text"] == DBNull.Value ? null : reader["content_text"].ToString();
            return obj;
        }
    }
}