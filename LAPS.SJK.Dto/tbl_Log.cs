
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_Log : IDataMapper<tbl_Log>
    {
        #region tbl_Log Properties
        public DateTime? LogDate { get; set; }
        public string IPAddress { get; set; }
        public string LogType { get; set; }
        public string LongMessage { get; set; }
        public string ShortMessage { get; set; }
        public string Username { get; set; }
        public string MechineName { get; set; }
        public Int64 ID { get; set; }
        #endregion    
        public tbl_Log Map(System.Data.IDataReader reader)
        {
            tbl_Log obj = new tbl_Log();   
            obj.LogDate = reader["LogDate"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["LogDate"]);
            obj.IPAddress = reader["IPAddress"] == DBNull.Value ? null : reader["IPAddress"].ToString();
            obj.LogType = reader["LogType"] == DBNull.Value ? null : reader["LogType"].ToString();
            obj.LongMessage = reader["LongMessage"] == DBNull.Value ? null : reader["LongMessage"].ToString();
            obj.ShortMessage = reader["ShortMessage"] == DBNull.Value ? null : reader["ShortMessage"].ToString();
            obj.Username = reader["Username"] == DBNull.Value ? null : reader["Username"].ToString();
            obj.MechineName = reader["MechineName"] == DBNull.Value ? null : reader["MechineName"].ToString();
            obj.ID = Convert.ToInt64(reader["ID"]);
            return obj;
        }
    }
}