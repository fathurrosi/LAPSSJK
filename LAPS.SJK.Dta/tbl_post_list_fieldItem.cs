
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_post_list_field]
    /// </summary>    
    public partial class tbl_post_list_fieldItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_post_list_field]
        /// </summary>        
        public static tbl_post_list_field Insert(tbl_post_list_field obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_post_list_field]([id_template], [column_name], [column_alias], [column_seq], [column_data_type], [max_lenth], [default_value], [is_mandatory], [is_deleted], [creator], [created]) 
VALUES      (@id_template, @column_name, @column_alias, @column_seq, @column_data_type, @max_lenth, @default_value, @is_mandatory, @is_deleted, @creator, @created)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, id_template, column_name, column_alias, column_seq, column_data_type, max_lenth, default_value, is_mandatory, is_deleted, creator, created, edited, editor
FROM    [tbl_post_list_field]
WHERE   [id]  = @_id";
            context.AddParameter("@id_template", obj.id_template);
            context.AddParameter("@column_name", string.Format("{0}", obj.column_name));
            context.AddParameter("@column_alias", string.Format("{0}", obj.column_alias));
            context.AddParameter("@column_seq", obj.column_seq);
            context.AddParameter("@column_data_type", obj.column_data_type);
            context.AddParameter("@max_lenth", obj.max_lenth);
            context.AddParameter("@default_value", string.Format("{0}", obj.default_value));
            context.AddParameter("@is_mandatory", obj.is_mandatory);
            context.AddParameter("@is_deleted", obj.is_deleted);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@created", obj.created);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_list_field>(context, new tbl_post_list_field()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_post_list_field]
        /// </summary>        
        public static tbl_post_list_field Update(tbl_post_list_field obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_post_list_field]
SET         [id_template] = @id_template,
            [column_name] = @column_name,
            [column_alias] = @column_alias,
            [column_seq] = @column_seq,
            [column_data_type] = @column_data_type,
            [max_lenth] = @max_lenth,
            [default_value] = @default_value,
            [is_mandatory] = @is_mandatory,
            [is_deleted] = @is_deleted,
            [edited] = @edited,
            [editor] = @editor
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, id_template, column_name, column_alias, column_seq, column_data_type, max_lenth, default_value, is_mandatory, is_deleted, creator, created, edited, editor 
FROM    [tbl_post_list_field]
WHERE   [id]  = @id";
            context.AddParameter("@id_template", obj.id_template);
            context.AddParameter("@column_name", string.Format("{0}", obj.column_name));
            context.AddParameter("@column_alias", string.Format("{0}", obj.column_alias));
            context.AddParameter("@column_seq", obj.column_seq);
            context.AddParameter("@column_data_type", obj.column_data_type);
            context.AddParameter("@max_lenth", obj.max_lenth);
            context.AddParameter("@default_value", string.Format("{0}", obj.default_value));
            context.AddParameter("@is_mandatory", obj.is_mandatory);
            context.AddParameter("@is_deleted", obj.is_deleted);
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_list_field>(context, new tbl_post_list_field()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_post_list_field]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"Update tbl_post_list_field Set is_deleted = 1 
WHERE   [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_post_list_field]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_post_list_field WHERE is_deleted <> 1 ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_post_list_field]
        /// </summary>        
        public static List<tbl_post_list_field> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, id_template, column_name, column_alias, column_seq, column_data_type, max_lenth, default_value, is_mandatory, is_deleted, creator, created, edited, editor FROM tbl_post_list_field WHERE is_deleted <> 1 ";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_list_field>(context, new tbl_post_list_field());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_post_list_field]
        /// </summary>        
        public static List<tbl_post_list_field> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_post_list_field] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_post_list_field].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_post_list_field].*
                FROM    [tbl_post_list_field]
                WHERE   is_deleted <> 1 
            )

            SELECT      [Paging_tbl_post_list_field].*
            FROM        [Paging_tbl_post_list_field]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_post_list_field>(context, new tbl_post_list_field());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_post_list_field] by Primary Key
        /// </summary>        
        public static tbl_post_list_field GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, id_template, column_name, column_alias, column_seq, column_data_type, max_lenth, default_value, is_mandatory, is_deleted, creator, created, edited, editor FROM tbl_post_list_field
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_list_field>(context, new tbl_post_list_field()).FirstOrDefault();
        }

        /// <summary>
        /// Get All records of TABLE [tbl_post_list_field] by TABLE [tbl_post_list_template]
        /// </summary>
        public static List<tbl_post_list_field> GetByid_template(Int32? id_template)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
SELECT  id, id_template, column_name, column_alias, column_seq, column_data_type, max_lenth, default_value, is_mandatory, is_deleted, creator, created, edited, editor
FROM    [tbl_post_list_field]
WHERE   [id_template] = @id_template";

            context.AddParameter("@id_template", id_template);
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_post_list_field>(context, new tbl_post_list_field());
        }

        /// <summary>
        /// Get All records of TABLE [tbl_post_list_field] by TABLE [tbl_post_list_template] (with Paging)
        /// </summary>
        public static List<tbl_post_list_field> GetByid_template(Int32? id_template, int PageSize, int PageIndex)
        {
            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
WITH [Paging_tbl_post_list_field] AS
(
    SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_post_list_field].[id]) AS PAGING_ROW_NUMBER,
            [tbl_post_list_field].*
    FROM    [tbl_post_list_field]
    WHERE   [id_template] = @id_template
)

SELECT      [Paging_tbl_post_list_field].*
FROM        [Paging_tbl_post_list_field]
WHERE		PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow";

            context.AddParameter("@id_template", id_template);
            return DBUtil.ExecuteMapper<tbl_post_list_field>(context, new tbl_post_list_field());
        }

        #endregion

    }
}