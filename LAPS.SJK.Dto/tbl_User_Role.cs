
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_User_Role : IDataMapper<tbl_User_Role>
    {
        #region tbl_User_Role Properties
        public Int32 ID { get; set; }
        public string Username { get; set; }
        public Int32? RoleID { get; set; }
        #endregion    
        public tbl_User_Role Map(System.Data.IDataReader reader)
        {
            tbl_User_Role obj = new tbl_User_Role();   
            obj.ID = Convert.ToInt32(reader["ID"]);
            obj.Username = reader["Username"] == DBNull.Value ? null : reader["Username"].ToString();
            obj.RoleID = reader["RoleID"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["RoleID"]);
            return obj;
        }
    }
}