using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAPS.SJK.Dto.Cstm
{
   public class tbl_page_content_result : IDataMapper<tbl_page_content_result>
    {
        public Int32? post_order { get; set; }
        public string post_type { get; set; }
        public string content_text { get; set; }
        public tbl_page_content_result Map(System.Data.IDataReader reader)
        {
            tbl_page_content_result obj = new tbl_page_content_result();

            obj.post_order = reader["post_order"] == DBNull.Value ? (Int32?)null : Convert.ToInt32(reader["post_order"]);
            obj.post_type = reader["post_type"] == DBNull.Value ? null : reader["post_type"].ToString();
            obj.content_text = reader["content_text"] == DBNull.Value ? null : reader["content_text"].ToString();

            return obj;
        }
    }
}
