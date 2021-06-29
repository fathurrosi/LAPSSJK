
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_post_list_field : IDataMapper<tbl_post_list_field>
    {
        #region tbl_post_list_field Properties
        public Int32 id { get; set; }
        public Int32? id_template { get; set; }
        public string column_name { get; set; }
        public string column_alias { get; set; }
        public Int32? column_seq { get; set; }
        public Int32? column_data_type { get; set; }
        public Int32? max_lenth { get; set; }
        public string default_value { get; set; }
        public bool? is_mandatory { get; set; }
        public Int32? is_deleted { get; set; }
        public string creator { get; set; }
        public DateTime? created { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public tbl_post_list_field Map(System.Data.IDataReader reader)
        {
            tbl_post_list_field obj = new tbl_post_list_field();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.id_template = reader["id_template"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["id_template"]);
            obj.column_name = reader["column_name"] == DBNull.Value ? null : reader["column_name"].ToString();
            obj.column_alias = reader["column_alias"] == DBNull.Value ? null : reader["column_alias"].ToString();
            obj.column_seq = reader["column_seq"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["column_seq"]);
            obj.column_data_type = reader["column_data_type"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["column_data_type"]);
            obj.max_lenth = reader["max_lenth"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["max_lenth"]);
            obj.default_value = reader["default_value"] == DBNull.Value ? null : reader["default_value"].ToString();
            obj.is_mandatory = reader["is_mandatory"] == DBNull.Value ? (bool?) null  : Convert.ToBoolean(reader["is_mandatory"]);
            obj.is_deleted = reader["is_deleted"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["is_deleted"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}