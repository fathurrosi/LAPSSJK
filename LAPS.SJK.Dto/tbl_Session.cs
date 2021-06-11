
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_session : IDataMapper<tbl_session>
    {
        #region tbl_session Properties
        public Guid id { get; set; }
        public string name { get; set; }
        public DateTime? updated { get; set; }
        public string updatedBy { get; set; }
        #endregion    
        public tbl_session Map(System.Data.IDataReader reader)
        {
            tbl_session obj = new tbl_session();   
            obj.id = new Guid(reader["id"].ToString());
            obj.name = reader["name"] == DBNull.Value ? null : reader["name"].ToString();
            obj.updated = reader["updated"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["updated"]);
            obj.updatedBy = reader["updatedBy"] == DBNull.Value ? null : reader["updatedBy"].ToString();
            return obj;
        }
    }
}