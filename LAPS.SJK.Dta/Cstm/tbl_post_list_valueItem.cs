using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    public partial class tbl_post_list_valueItem
    {
        public static int GetMaxRowIndex(Int32 id_template)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"Select max(row_index) as row_index  FROM tbl_post_list_value 
WHERE   [id_template] = @id_template";
            context.AddParameter("@id_template", id_template);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);

            int result = 0;
            int.TryParse(string.Format("{0}", obj), out result);

            return result + 1;
        }

        public static bool Insert(List<tbl_post_list_value> list)
        {
            bool result = true;
            IDBHelper context = new DBHelper();
            context.BeginTransaction();
            try
            {
                list.ForEach(obj =>
                {
                    context.Clear();
                    string sqlQuery = @"
INSERT INTO [tbl_post_list_value]([row_index], [id_template], [id_field], [value_field]) 
VALUES      (@row_index, @id_template, @id_field, @value_field)
";
                    context.AddParameter("@row_index", obj.row_index);
                    context.AddParameter("@id_template", obj.id_template);
                    context.AddParameter("@id_field", obj.id_field);
                    context.AddParameter("@value_field", string.Format("{0}", obj.value_field));
                    context.CommandText = sqlQuery;
                    context.CommandType = System.Data.CommandType.Text;
                    DBUtil.ExecuteNonQuery(context);
                });
                context.CommitTransaction();
            }
            catch (Exception ex)
            {
                context.RollbackTransaction();
                result = false;
            }

            return result;
        }


        public static bool Delete(int id_template, int row_index)
        {
            bool result = true;
            IDBHelper context = new DBHelper();
            try
            {
                string sqlQuery = @"

Delete from [tbl_post_list_value]
where   row_index   =   @row_index 
and     id_template =   @id_template
";
                context.AddParameter("@row_index", row_index);
                context.AddParameter("@id_template", id_template);
                context.CommandText = sqlQuery;
                context.CommandType = System.Data.CommandType.Text;
                DBUtil.ExecuteNonQuery(context);


            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }


        public static bool Update(List<tbl_post_list_value> list)
        {
            bool result = true;
            IDBHelper context = new DBHelper();
            context.BeginTransaction();
            try
            {
                long row_index = list.Select(t => t.row_index).FirstOrDefault();
                long id_template = list.Select(t => t.id_template).FirstOrDefault();
                string sqlQuery = @"

Delete from [tbl_post_list_value]
where   row_index   =   @row_index 
and     id_template =   @id_template
";
                context.AddParameter("@row_index", row_index);
                context.AddParameter("@id_template", id_template);
                context.CommandText = sqlQuery;
                context.CommandType = System.Data.CommandType.Text;
                DBUtil.ExecuteNonQuery(context);


                list.ForEach(obj =>
                {
                    context.Clear();
                    sqlQuery = @"

INSERT INTO [tbl_post_list_value]([row_index], [id_template], [id_field], [value_field]) 
VALUES      (@row_index, @id_template, @id_field, @value_field)
";
                    context.AddParameter("@row_index", obj.row_index);
                    context.AddParameter("@id_template", obj.id_template);
                    context.AddParameter("@id_field", obj.id_field);
                    context.AddParameter("@value_field", string.Format("{0}", obj.value_field));
                    context.CommandText = sqlQuery;
                    context.CommandType = System.Data.CommandType.Text;
                    DBUtil.ExecuteNonQuery(context);
                });
                context.CommitTransaction();
            }
            catch (Exception ex)
            {
                context.RollbackTransaction();
                result = false;
            }

            return result;
        }
    }
}
