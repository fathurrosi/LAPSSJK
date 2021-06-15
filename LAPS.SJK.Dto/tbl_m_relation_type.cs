
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_m_relation_type : IDataMapper<tbl_m_relation_type>
    {
        #region tbl_m_relation_type Properties
        public string type_name { get; set; }
        public string type_description { get; set; }
        #endregion    
        public tbl_m_relation_type Map(System.Data.IDataReader reader)
        {
            tbl_m_relation_type obj = new tbl_m_relation_type();   
            obj.type_name = string.Format("{0}",reader["type_name"]);
            obj.type_description = reader["type_description"] == DBNull.Value ? null : reader["type_description"].ToString();
            return obj;
        }
    }
}