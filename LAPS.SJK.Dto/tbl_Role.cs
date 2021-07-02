
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
        public Int32? is_deleted { get; set; }
        public DateTime? created { get; set; }
        public string creator { get; set; }
        public DateTime? edited { get; set; }
        public string editor { get; set; }
        #endregion    
        public tbl_role Map(System.Data.IDataReader reader)
        {
            tbl_role obj = new tbl_role();   
            obj.ID = Convert.ToInt32(reader["ID"]);
            obj.Name = reader["Name"] == DBNull.Value ? null : reader["Name"].ToString();
            obj.Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString();
            obj.is_deleted = reader["is_deleted"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["is_deleted"]);
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.creator = reader["creator"] == DBNull.Value ? null : reader["creator"].ToString();
            obj.edited = reader["edited"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["edited"]);
            obj.editor = reader["editor"] == DBNull.Value ? null : reader["editor"].ToString();
            return obj;
        }
    }
}