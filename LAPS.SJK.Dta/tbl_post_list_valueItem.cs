
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_post_list_value]
    /// </summary>    
    public partial class tbl_post_list_valueItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_post_list_value]
        /// </summary>        
        public static tbl_post_list_value Insert(tbl_post_list_value obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_post_list_value]([row_index], [id_template], [id_field], [value_field]) 
VALUES      (@row_index, @id_template, @id_field, @value_field)

SET @Err = @@Error

SELECT  row_index, id_template, id_field, value_field
FROM    [tbl_post_list_value]
WHERE   [id_field]  = @id_field
            AND [row_index] = @row_index
            AND [id_template] = @id_template";
            context.AddParameter("@row_index", obj.row_index);
            context.AddParameter("@id_template", obj.id_template);
            context.AddParameter("@id_field", obj.id_field);
            context.AddParameter("@value_field", string.Format("{0}", obj.value_field));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_list_value>(context, new tbl_post_list_value()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_post_list_value]
        /// </summary>        
        public static tbl_post_list_value Update(tbl_post_list_value obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_post_list_value]
SET         [value_field] = @value_field
WHERE       [id_field]  = @id_field
            AND [row_index] = @row_index
            AND [id_template] = @id_template

SET @Err = @@Error

SELECT  row_index, id_template, id_field, value_field 
FROM    [tbl_post_list_value]
WHERE   [id_field]  = @id_field
        AND [row_index] = @row_index
        AND [id_template] = @id_template";
            context.AddParameter("@value_field", string.Format("{0}", obj.value_field));
            context.AddParameter("@id_field", obj.id_field);
            context.AddParameter("@row_index", obj.row_index);
            context.AddParameter("@id_template", obj.id_template);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_list_value>(context, new tbl_post_list_value()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_post_list_value]
        /// </summary>        
        public static int Delete(Int32 id_field, Int64 row_index, Int32 id_template)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_post_list_value 
WHERE   [id_field]  = @id_field
        AND [row_index] = @row_index
        AND [id_template] = @id_template";
            context.AddParameter("@id_field", id_field);
            context.AddParameter("@row_index", row_index);
            context.AddParameter("@id_template", id_template);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_post_list_value]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_post_list_value ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_post_list_value]
        /// </summary>        
        public static List<tbl_post_list_value> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT row_index, id_template, id_field, value_field FROM tbl_post_list_value ";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_list_value>(context, new tbl_post_list_value());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_post_list_value]
        /// </summary>        
        public static List<tbl_post_list_value> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_post_list_value] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_post_list_value].[id_field], [tbl_post_list_value].[row_index], [tbl_post_list_value].[id_template] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_post_list_value].*
                FROM    [tbl_post_list_value]
                
            )

            SELECT      [Paging_tbl_post_list_value].*
            FROM        [Paging_tbl_post_list_value]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_post_list_value>(context, new tbl_post_list_value());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_post_list_value] by Primary Key
        /// </summary>        
        public static tbl_post_list_value GetByPK(Int32 id_field, Int64 row_index, Int32 id_template)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT row_index, id_template, id_field, value_field FROM tbl_post_list_value
            WHERE [id_field]  = @id_field AND [row_index] = @row_index AND [id_template] = @id_template";
            context.AddParameter("@id_field", id_field);
            context.AddParameter("@row_index", row_index);
            context.AddParameter("@id_template", id_template);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_list_value>(context, new tbl_post_list_value()).FirstOrDefault();
        }

        /// <summary>
        /// Get All records of TABLE [tbl_post_list_value] by TABLE [tbl_post_list_template]
        /// </summary>
        public static List<tbl_post_list_value> GetByid_template(Int32 id_template)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
SELECT  row_index, id_template, id_field, value_field
FROM    [tbl_post_list_value]
WHERE   [id_template] = @id_template";

            context.AddParameter("@id_template", id_template);
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_post_list_value>(context, new tbl_post_list_value());
        }

        /// <summary>
        /// Get All records of TABLE [tbl_post_list_value] by TABLE [tbl_post_list_template] (with Paging)
        /// </summary>
        public static List<tbl_post_list_value> GetByid_template(Int32 id_template, int PageSize, int PageIndex)
        {
            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
WITH [Paging_tbl_post_list_value] AS
(
    SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_post_list_value].[id_field], [tbl_post_list_value].[row_index], [tbl_post_list_value].[id_template]) AS PAGING_ROW_NUMBER,
            [tbl_post_list_value].*
    FROM    [tbl_post_list_value]
    WHERE   [id_template] = @id_template
)

SELECT      [Paging_tbl_post_list_value].*
FROM        [Paging_tbl_post_list_value]
WHERE		PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow";

            context.AddParameter("@id_template", id_template);
            return DBUtil.ExecuteMapper<tbl_post_list_value>(context, new tbl_post_list_value());
        }

        /// <summary>
        /// Get All records of TABLE [tbl_post_list_value] by TABLE [tbl_post_list_field]
        /// </summary>
        public static List<tbl_post_list_value> GetByid_field(Int32 id_field)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
SELECT  row_index, id_template, id_field, value_field
FROM    [tbl_post_list_value]
WHERE   [id_field] = @id_field";

            context.AddParameter("@id_field", id_field);
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_post_list_value>(context, new tbl_post_list_value());
        }

        /// <summary>
        /// Get All records of TABLE [tbl_post_list_value] by TABLE [tbl_post_list_field] (with Paging)
        /// </summary>
        public static List<tbl_post_list_value> GetByid_field(Int32 id_field, int PageSize, int PageIndex)
        {
            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
WITH [Paging_tbl_post_list_value] AS
(
    SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_post_list_value].[id_field], [tbl_post_list_value].[row_index], [tbl_post_list_value].[id_template]) AS PAGING_ROW_NUMBER,
            [tbl_post_list_value].*
    FROM    [tbl_post_list_value]
    WHERE   [id_field] = @id_field
)

SELECT      [Paging_tbl_post_list_value].*
FROM        [Paging_tbl_post_list_value]
WHERE		PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow";

            context.AddParameter("@id_field", id_field);
            return DBUtil.ExecuteMapper<tbl_post_list_value>(context, new tbl_post_list_value());
        }

        #endregion

    }
}