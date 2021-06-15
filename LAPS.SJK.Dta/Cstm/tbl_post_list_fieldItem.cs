using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    public partial class tbl_post_list_fieldItem
    {
        public static tbl_post_list_field GetByid_template_and_name(Int32? id_template, string column_name)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery = @"
SELECT top 1  id, id_template, column_name, column_alias, column_seq, column_data_type, max_lenth, default_value, is_mandatory, is_deleted, creator, created, edited, editor
FROM    [tbl_post_list_field]
WHERE   [id_template] = @id_template and column_name =@column_name";

            context.AddParameter("@id_template", id_template);
            context.AddParameter("@column_name", column_name);
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_post_list_field>(context, new tbl_post_list_field()).FirstOrDefault();
        }

        public static tbl_post_list_field GetByid_template_and_name(Int32 id,  Int32? id_template, string column_name)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery = @"
SELECT top 1  id, id_template, column_name, column_alias, column_seq, column_data_type, max_lenth, default_value, is_mandatory, is_deleted, creator, created, edited, editor
FROM    [tbl_post_list_field]
WHERE   [id_template] = @id_template and column_name =@column_name and id <> @id";

            context.AddParameter("@id_template", id_template);
            context.AddParameter("@column_name", column_name);
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_post_list_field>(context, new tbl_post_list_field()).FirstOrDefault();
        }
    }
}
