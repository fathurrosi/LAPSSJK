
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_Role : IDataMapper<tbl_Role>
    {
        #region tbl_Role Properties
        public Int32 ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        #endregion    
        public tbl_Role Map(System.Data.IDataReader reader)
        {
            tbl_Role obj = new tbl_Role();   
            obj.ID = Convert.ToInt32(reader["ID"]);
            obj.Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString();
            obj.Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString();
            obj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["CreatedDate"]);
            obj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? null : reader["CreatedBy"].ToString();
            obj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["ModifiedDate"]);
            obj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? null : reader["ModifiedBy"].ToString();
            return obj;
        }
    }
}