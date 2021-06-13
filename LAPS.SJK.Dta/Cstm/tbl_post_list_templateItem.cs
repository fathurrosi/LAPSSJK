using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    public partial class tbl_post_list_templateItem
    {    /// <summary>
         /// Get All records from TABLE [tbl_post_list_template]
         /// </summary>        
        public static List<tbl_post_list_template> GetAllActive()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, template_name, remark, created, creator, is_deleted FROM tbl_post_list_template where is_deleted <>  1 ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_list_template>(context, new tbl_post_list_template());
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_post_list_template]
        /// </summary>        
        public static int SetAsDeleted(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"Update tbl_post_list_template set is_deleted= 1
WHERE   [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
    }
}
