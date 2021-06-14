using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAPS.SJK.Dto.Cstm
{
    public class tbl_page_content : IDataMapper<tbl_page_content>
    {
        public Int32? menu_relations_id { get; set; }
        public Int32? menu_id { get; set; }
        public string relations_type { get; set; }
        public Int32? content_id { get; set; }
        public Int32? post_id { get; set; }
        public Int32? post_detail_id{ get; set; }
        public Int32? post_order { get; set; }
        public string post_type { get; set; }
        public string content_text { get; set; }
      //  public string content_img { get; set; }
        public tbl_page_content Map(System.Data.IDataReader reader)
        {
            tbl_page_content obj = new tbl_page_content();
            obj.menu_relations_id = reader["menu_relations_id"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["menu_relations_id"]);
            obj.menu_id = reader["menu_id"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["menu_id"]);
            obj.relations_type = reader["relations_type"] == DBNull.Value ? null : reader["relations_type"].ToString();
            obj.content_id = reader["content_id"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["content_id"]);
            obj.post_id = reader["post_id"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["post_id"]);
            obj.post_detail_id = reader["post_detail_id"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["post_detail_id"]);
            obj.post_order = reader["post_order"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["post_order"]);
            obj.post_type = reader["post_type"] == DBNull.Value ? null : reader["post_type"].ToString();
         //   obj.content_text = reader["content_text"] == DBNull.Value ? null : reader["content_text"].ToString();
         //   obj.content_img = reader["content_img"] == DBNull.Value ? null : reader["content_img"].ToString();
         
            return obj;
        }
    }
}
