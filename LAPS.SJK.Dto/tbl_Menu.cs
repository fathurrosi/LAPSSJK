
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
        public string menu_text { get; set; }
        public Int32? menu_type { get; set; }
        public Int32? need_login { get; set; }
        public Int32? parentid { get; set; }
        public Int32? orderid { get; set; }
        public string url { get; set; }
        #endregion    
        public tbl_menu Map(System.Data.IDataReader reader)
        {
            tbl_menu obj = new tbl_menu();   
            obj.menu_id = Convert.ToInt32(reader["menu_id"]);
            obj.menu_name = reader["menu_name"] == DBNull.Value ? null : reader["menu_name"].ToString();
            obj.menu_text = reader["menu_text"] == DBNull.Value ? null : reader["menu_text"].ToString();
            obj.menu_type = reader["menu_type"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["menu_type"]);
            obj.need_login = reader["need_login"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["need_login"]);
            obj.parentid = reader["parentid"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["parentid"]);
            obj.orderid = reader["orderid"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["orderid"]);
            obj.url = reader["url"] == DBNull.Value ? null : reader["url"].ToString();
            return obj;
        }
    }
}