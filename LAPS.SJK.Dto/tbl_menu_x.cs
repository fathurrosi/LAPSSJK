
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_menu_x : IDataMapper<tbl_menu_x>
    {
        #region tbl_menu_x Properties
        public Int32 ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public Int32? ParentID { get; set; }
        public Int32? Sequence { get; set; }
        public Int32? Deleted { get; set; }
        public string MenuType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        #endregion    
        public tbl_menu_x Map(System.Data.IDataReader reader)
        {
            tbl_menu_x obj = new tbl_menu_x();   
            obj.ID = Convert.ToInt32(reader["ID"]);
            obj.Name = string.Format("{0}",reader["Name"]);
            obj.Description = reader["Description"] == DBNull.Value ? null : reader["Description"].ToString();
            obj.Icon = reader["Icon"] == DBNull.Value ? null : reader["Icon"].ToString();
            obj.Url = reader["Url"] == DBNull.Value ? null : reader["Url"].ToString();
            obj.ParentID = reader["ParentID"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["ParentID"]);
            obj.Sequence = reader["Sequence"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Sequence"]);
            obj.Deleted = reader["Deleted"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["Deleted"]);
            obj.MenuType = reader["MenuType"] == DBNull.Value ? null : reader["MenuType"].ToString();
            obj.CreatedDate = reader["CreatedDate"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["CreatedDate"]);
            obj.CreatedBy = reader["CreatedBy"] == DBNull.Value ? null : reader["CreatedBy"].ToString();
            obj.ModifiedBy = reader["ModifiedBy"] == DBNull.Value ? null : reader["ModifiedBy"].ToString();
            obj.ModifiedDate = reader["ModifiedDate"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["ModifiedDate"]);
            return obj;
        }
    }
}