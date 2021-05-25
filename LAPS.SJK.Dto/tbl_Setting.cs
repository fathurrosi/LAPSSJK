
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_Setting : IDataMapper<tbl_Setting>
    {
        #region tbl_Setting Properties
        public Int32 id { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string description { get; set; }
        #endregion    
        public tbl_Setting Map(System.Data.IDataReader reader)
        {
            tbl_Setting obj = new tbl_Setting();   
            obj.id = Convert.ToInt32(reader["id"]);
            obj.name = reader["name"] == DBNull.Value ? null : reader["name"].ToString();
            obj.value = reader["value"] == DBNull.Value ? null : reader["value"].ToString();
            obj.description = reader["description"] == DBNull.Value ? null : reader["description"].ToString();
            return obj;
        }
    }
}