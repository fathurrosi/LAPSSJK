
using System;
//using Thunder.Village.DataAccess;
using DataAccessLayer;
namespace LAPS.SJK.Dto
{
    public class tbl_menu_relations : IDataMapper<tbl_menu_relations>
    {
        #region tbl_menu_relations Properties
        public Int32 menu_relations_id { get; set; }
        public string relations_type { get; set; }
        public Int32? content_id { get; set; }
        #endregion    
        public tbl_menu_relations Map(System.Data.IDataReader reader)
        {
            tbl_menu_relations obj = new tbl_menu_relations();   
            obj.menu_relations_id = Convert.ToInt32(reader["menu_relations_id"]);
            obj.relations_type = reader["relations_type"] == DBNull.Value ? null : reader["relations_type"].ToString();
            obj.content_id = reader["content_id"] == DBNull.Value ? (Int32?) null : Convert.ToInt32(reader["content_id"]);
            return obj;
        }
    }
}