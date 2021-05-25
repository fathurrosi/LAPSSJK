
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_File : IDataMapper<tbl_File>
    {
        #region tbl_File Properties
        public string file_id { get; set; }
        public string ref_name { get; set; }
        public string ref_id { get; set; }
        public string file_type { get; set; }
        public string file_path { get; set; }
        public string file_name { get; set; }
        public string file_ext { get; set; }
        public byte[] file_blob { get; set; }
        public DateTime? created { get; set; }
        public string created_by { get; set; }
        #endregion    
        public tbl_File Map(System.Data.IDataReader reader)
        {
            tbl_File obj = new tbl_File();   
            obj.file_id = string.Format("{0}",reader["file_id"]);
            obj.ref_name = reader["ref_name"] == DBNull.Value ? null : reader["ref_name"].ToString();
            obj.ref_id = reader["ref_id"] == DBNull.Value ? null : reader["ref_id"].ToString();
            obj.file_type = reader["file_type"] == DBNull.Value ? null : reader["file_type"].ToString();
            obj.file_path = reader["file_path"] == DBNull.Value ? null : reader["file_path"].ToString();
            obj.file_name = reader["file_name"] == DBNull.Value ? null : reader["file_name"].ToString();
            obj.file_ext = reader["file_ext"] == DBNull.Value ? null : reader["file_ext"].ToString();
            obj.file_blob = reader["file_blob"] == DBNull.Value ? (byte[]) null : (byte[]) reader["file_blob"];
            obj.created = reader["created"] == DBNull.Value ? (DateTime?) null : Convert.ToDateTime(reader["created"]);
            obj.created_by = reader["created_by"] == DBNull.Value ? null : reader["created_by"].ToString();
            return obj;
        }
    }
}