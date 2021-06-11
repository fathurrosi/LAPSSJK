using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace LAPS.SJK.Dto.Cstm
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
        public Int32? IsActive { get; set; }
        public string FullName { get; set; }

        public List<tbl_role> Roles { get; set; }
        #endregion    
        public tbl_user Map(System.Data.IDataReader reader)
        {
            tbl_user obj = new tbl_user();
            obj.Username = string.Format("{0}", reader["Username"]);
            obj.Password = reader["Password"] == DBNull.Value ? null : reader["Password"].ToString();
            obj.LastLogin = reader["LastLogin"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["LastLogin"]);
            obj.IsLogin = reader["IsLogin"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["IsLogin"]);
            obj.IPAddress = reader["IPAddress"] == DBNull.Value ? null : reader["IPAddress"].ToString();
            obj.MachineName = reader["MachineName"] == DBNull.Value ? null : reader["MachineName"].ToString();
            obj.IsActive = reader["IsActive"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["IsActive"]);
            obj.FullName = reader["FullName"] == DBNull.Value ? null : reader["FullName"].ToString();
            return obj;
        }
    }
}
