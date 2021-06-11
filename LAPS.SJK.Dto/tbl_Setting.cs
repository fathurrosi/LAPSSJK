
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_setting : IDataMapper<tbl_setting>
    {
        #region tbl_setting Properties
        public Int32 id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string description { get; set; }
        #endregion    
        public tbl_setting Map(System.Data.IDataReader reader)
        {
            tbl_setting obj = new tbl_setting();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.name = reader["name"] == DBNull.Value ? null : reader["name"].ToString();
            obj.value = reader["value"] == DBNull.Value ? null : reader["value"].ToString();
            obj.description = reader["description"] == DBNull.Value ? null : reader["description"].ToString();
            return obj;
        }
    }
}