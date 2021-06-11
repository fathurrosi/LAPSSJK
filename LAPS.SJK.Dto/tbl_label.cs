
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_label : IDataMapper<tbl_label>
    {
        #region tbl_label Properties
        public string c_flag { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        #endregion    
        public tbl_label Map(System.Data.IDataReader reader)
        {
            tbl_label obj = new tbl_label();   
            obj.c_flag = string.Format("{0}",reader["c_flag"]);
            obj.name = string.Format("{0}",reader["name"]);
            obj.value = reader["value"] == DBNull.Value ? null : reader["value"].ToString();
            return obj;
        }
    }
}