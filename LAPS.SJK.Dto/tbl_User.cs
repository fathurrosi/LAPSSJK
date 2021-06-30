
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_user : IDataMapper<tbl_user>
    {
        #region tbl_user Properties
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? LastLogin { get; set; }
        public Int32? IsLogin { get; set; }
        public string IPAddress { get; set; }
        public string MachineName { get; set; }
        public Int32? is_deleted { get; set; }
        public string FullName { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public tbl_user Map(System.Data.IDataReader reader)
        {
            tbl_user obj = new tbl_user();   
            obj.Username = string.Format("{0}",reader["Username"]);
            obj.Password = reader["Password"] == DBNull.Value ? null : reader["Password"].ToString();
            obj.LastLogin = reader["LastLogin"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["LastLogin"]);
            obj.IsLogin = reader["IsLogin"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["IsLogin"]);
            obj.IPAddress = reader["IPAddress"] == DBNull.Value ? null : reader["IPAddress"].ToString();
            obj.MachineName = reader["MachineName"] == DBNull.Value ? null : reader["MachineName"].ToString();
            obj.is_deleted = reader["is_deleted"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["is_deleted"]);
            obj.FullName = reader["FullName"] == DBNull.Value ? null : reader["FullName"].ToString();
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}