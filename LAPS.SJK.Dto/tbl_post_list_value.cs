
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_post_list_value : IDataMapper<tbl_post_list_value>
    {
        #region tbl_post_list_value Properties
        public Int64 row_index { get; set; }
        public Int32 id_template { get; set; }
        public Int32 id_field { get; set; }
        public string value_field { get; set; }
        #endregion    
        public tbl_post_list_value Map(System.Data.IDataReader reader)
        {
            tbl_post_list_value obj = new tbl_post_list_value();   
            obj.row_index = Convert.ToInt64(reader["row_index"]);
            obj.id_template = Convert.ToInt32(reader["id_template"]);
            obj.id_field = Convert.ToInt32(reader["id_field"]);
            obj.value_field = reader["value_field"] == DBNull.Value ? null : reader["value_field"].ToString();
            return obj;
        }
    }
}