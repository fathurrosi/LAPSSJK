
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_user_role : IDataMapper<tbl_user_role>
    {
        #region tbl_user_role Properties
        public Int32 ID { get; set; }
        public string Username { get; set; }
        public Int32? RoleID { get; set; }
        #endregion    
        public tbl_user_role Map(System.Data.IDataReader reader)
        {
            tbl_user_role obj = new tbl_user_role();   
            obj.ID = Convert.ToInt32(reader["ID"]);
            obj.Username = reader["Username"] == DBNull.Value ? null : reader["Username"].ToString();
            obj.RoleID = reader["RoleID"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["RoleID"]);
            return obj;
        }
    }
}