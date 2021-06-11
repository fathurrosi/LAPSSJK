
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_category : IDataMapper<tbl_category>
    {
        #region tbl_category Properties
        public Int64 cat_id { get; set; }
        public string name { get; set; }
        public string slug { get; set; }
        public Int64? term_group { get; set; }
        #endregion    
        public tbl_category Map(System.Data.IDataReader reader)
        {
            tbl_category obj = new tbl_category();   
            obj.cat_id = Convert.ToInt64(reader["cat_id"]);
            obj.name = reader["name"] == DBNull.Value ? null : reader["name"].ToString();
            obj.slug = reader["slug"] == DBNull.Value ? null : reader["slug"].ToString();
            obj.term_group = reader["term_group"] == DBNull.Value ? (Int64?) null : Convert.ToInt64(reader["term_group"]);
            return obj;
        }
    }
}