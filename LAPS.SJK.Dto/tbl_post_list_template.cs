
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_post_list_template : IDataMapper<tbl_post_list_template>
    {
        #region tbl_post_list_template Properties
        public Int32 id { get; set; }
        public string template_name { get; set; }
        public string remark { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public Int32? is_deleted { get; set; }
        #endregion    
        public tbl_post_list_template Map(System.Data.IDataReader reader)
        {
            tbl_post_list_template obj = new tbl_post_list_template();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.template_name = reader["template_name"] == DBNull.Value ? null : reader["template_name"].ToString();
            obj.remark = reader["remark"] == DBNull.Value ? null : reader["remark"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.is_deleted = reader["is_deleted"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["is_deleted"]);
            return obj;
        }
    }
}