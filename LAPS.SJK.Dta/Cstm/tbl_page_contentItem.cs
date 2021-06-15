using DataAccessLayer;
using LAPS.SJK.Dto;
using LAPS.SJK.Dto.Cstm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAPS.SJK.Dta
{
    public partial class tbl_page_contentItem
    {
        public static List<tbl_page_content> getByMenuID(int menu_id)
        {
            IDBHelper context = new DBHelper();
            context.CommandText = @"SELECT [menu_relations_id]
                  ,[menu_id]
                  ,[relations_type]
                  ,[content_id]
				  ,c.post_id
				  ,c.post_detail_id
	              ,c.post_order
	              ,c.post_type	             
              FROM [dbo].[tbl_menu_relations] a 
              inner join [dbo].[tbl_post] b on a.content_id = b.post_id
              left outer join [dbo].[tbl_post_detail] c on b.post_id = c.post_id                  
              where a.menu_id= @id order by post_order";
            context.CommandType = CommandType.Text;
            context.AddParameter("@id", string.Format("{0}", menu_id));
            return DBUtil.ExecuteMapper<tbl_page_content>(context, new tbl_page_content()).ToList();

        }

        public static DataTable getContentTableByDetailID(int? post_detail_id)
        {
            IDBHelper context = new DBHelper();
            context.CommandText = @"sp_GetTable";
            context.CommandType = CommandType.StoredProcedure;
            context.AddParameter("@id_post_detail", string.Format("{0}", post_detail_id));
            DataSet ds = DBUtil.ExecuteDataSet(context);

            if (ds != null)
            {
                return ds.Tables[0];
            }

            return null;
        }

        public static tbl_page_content_result getContentTextByDetailID(int? post_detail_id)
        {
            IDBHelper context = new DBHelper();
            context.CommandText = @"SELECT [post_type]
            ,[post_order]
            ,[content_text]
            FROM  [dbo].[tbl_post_detail] a inner join [dbo].[tbl_post_content_text] b on a.post_detail_id = b.post_detail_id where a.post_detail_id= @id ";
            context.CommandType = CommandType.Text;
            context.AddParameter("@id", string.Format("{0}", post_detail_id));
            return DBUtil.ExecuteMapper<tbl_page_content_result>(context, new tbl_page_content_result()).FirstOrDefault();
        }



    }
}
