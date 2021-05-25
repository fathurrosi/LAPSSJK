
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_Privilege : IDataMapper<tbl_Privilege>
    {
        #region tbl_Privilege Properties
        public Int32 MenuID { get; set; }
        public Int32 RoleID { get; set; }
        public Int32? AllowCreate { get; set; }
        public Int32? AllowRead { get; set; }
        public Int32? AllowUpdate { get; set; }
        public Int32? AllowDelete { get; set; }
        public Int32? AllowPrint { get; set; }
        #endregion    
        public tbl_Privilege Map(System.Data.IDataReader reader)
        {
            tbl_Privilege obj = new tbl_Privilege();   
            obj.MenuID = Convert.ToInt32(reader["MenuID"]);
            obj.RoleID = Convert.ToInt32(reader["RoleID"]);
            obj.AllowCreate = reader["AllowCreate"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["AllowCreate"]);
            obj.AllowRead = reader["AllowRead"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["AllowRead"]);
            obj.AllowUpdate = reader["AllowUpdate"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["AllowUpdate"]);
            obj.AllowDelete = reader["AllowDelete"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["AllowDelete"]);
            obj.AllowPrint = reader["AllowPrint"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["AllowPrint"]);
            return obj;
        }
    }
}