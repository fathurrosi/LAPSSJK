
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_menu : IDataMapper<tbl_menu>
    {
        #region tbl_menu Properties
        public Int32 menu_id { get; set; }
        public string menu_name { get; set; }
        public Int32? on_lock { get; set; }
        public Int32? parentid { get; set; }
        public Int32? orderid { get; set; }
        public string url { get; set; }
        #endregion    
        public tbl_menu Map(System.Data.IDataReader reader)
        {
            tbl_menu obj = new tbl_menu();   
            obj.menu_id = Convert.ToInt32(reader["menu_id"]);
            obj.menu_name = reader["menu_name"] == DBNull.Value ? null : reader["menu_name"].ToString();
            obj.on_lock = reader["on_lock"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["on_lock"]);
            obj.parentid = reader["parentid"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["parentid"]);
            obj.orderid = reader["orderid"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["orderid"]);
            obj.url = reader["url"] == DBNull.Value ? null : reader["url"].ToString();
            return obj;
        }
    }
}