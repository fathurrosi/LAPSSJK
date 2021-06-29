
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_role : IDataMapper<tbl_role>
    {
        #region tbl_role Properties
        public Int32 ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Int32? is_deleted { get; set; }
        #endregion    
        public tbl_role Map(System.Data.IDataReader reader)
        {
            tbl_role obj = new tbl_role();   
            obj.ID = Convert.ToInt32(reader["ID"]);
            obj.Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString();
            obj.Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString();
            obj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["CreatedDate"]);
            obj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? null : reader["CreatedBy"].ToString();
            obj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["ModifiedDate"]);
            obj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? null : reader["ModifiedBy"].ToString();
            obj.is_deleted = reader["is_deleted"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["is_deleted"]);
            return obj;
        }
    }
}