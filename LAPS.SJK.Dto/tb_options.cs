
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tb_options : IDataMapper<tb_options>
    {
        #region tb_options Properties
        public Int32 option_id { get; set; }
        public string option_name { get; set; }
        public string option_value { get; set; }
        public string autoload { get; set; }
        #endregion    
        public tb_options Map(System.Data.IDataReader reader)
        {
            tb_options obj = new tb_options();   
            obj.option_id = Convert.ToInt32(reader["option_id"]);
            obj.option_name = reader["option_name"] == DBNull.Value ? null : reader["option_name"].ToString();
            obj.option_value = reader["option_value"] == DBNull.Value ? null : reader["option_value"].ToString();
            obj.autoload = reader["autoload"] == DBNull.Value ? null : reader["autoload"].ToString();
            return obj;
        }
    }
}