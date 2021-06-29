
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_post_content_text]
    /// </summary>    
    public partial class tbl_post_content_textItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_post_content_text]
        /// </summary>        
        public static tbl_post_content_text Insert(tbl_post_content_text obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_post_content_text]([id_post_text], [post_detail_id], [content_text]) 
VALUES      (@id_post_text, @post_detail_id, @content_text)

SET @Err = @@Error

SELECT  id_post_text, post_detail_id, content_text
FROM    [tbl_post_content_text]
WHERE   [id_post_text]  = @id_post_text";
            context.AddParameter("@id_post_text", obj.id_post_text);
            context.AddParameter("@post_detail_id", obj.post_detail_id);
            context.AddParameter("@content_text", string.Format("{0}", obj.content_text));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_content_text>(context, new tbl_post_content_text()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_post_content_text]
        /// </summary>        
        public static tbl_post_content_text Update(tbl_post_content_text obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_post_content_text]
SET         [post_detail_id] = @post_detail_id,
            [content_text] = @content_text
WHERE       [id_post_text]  = @id_post_text

SET @Err = @@Error

SELECT  id_post_text, post_detail_id, content_text 
FROM    [tbl_post_content_text]
WHERE   [id_post_text]  = @id_post_text";
            context.AddParameter("@post_detail_id", obj.post_detail_id);
            context.AddParameter("@content_text", string.Format("{0}", obj.content_text));
            context.AddParameter("@id_post_text", obj.id_post_text);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_content_text>(context, new tbl_post_content_text()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_post_content_text]
        /// </summary>        
        public static int Delete(Int32 id_post_text)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_post_content_text 
WHERE   [id_post_text]  = @id_post_text";
            context.AddParameter("@id_post_text", id_post_text);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_post_content_text]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_post_content_text ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_post_content_text]
        /// </summary>        
        public static List<tbl_post_content_text> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id_post_text, post_detail_id, content_text FROM tbl_post_content_text ";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_content_text>(context, new tbl_post_content_text());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_post_content_text]
        /// </summary>        
        public static List<tbl_post_content_text> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_post_content_text] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_post_content_text].[id_post_text] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_post_content_text].*
                FROM    [tbl_post_content_text]
                
            )

            SELECT      [Paging_tbl_post_content_text].*
            FROM        [Paging_tbl_post_content_text]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_post_content_text>(context, new tbl_post_content_text());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_post_content_text] by Primary Key
        /// </summary>        
        public static tbl_post_content_text GetByPK(Int32 id_post_text)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id_post_text, post_detail_id, content_text FROM tbl_post_content_text
            WHERE [id_post_text]  = @id_post_text";
            context.AddParameter("@id_post_text", id_post_text);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_content_text>(context, new tbl_post_content_text()).FirstOrDefault();
        }

        /// <summary>
        /// Get All records of TABLE [tbl_post_content_text] by TABLE [tbl_post_detail]
        /// </summary>
        public static List<tbl_post_content_text> GetBypost_detail_id(Int32? post_detail_id)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
SELECT  id_post_text, post_detail_id, content_text
FROM    [tbl_post_content_text]
WHERE   [post_detail_id] = @post_detail_id";

            context.AddParameter("@post_detail_id", post_detail_id);
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_post_content_text>(context, new tbl_post_content_text());
        }

        /// <summary>
        /// Get All records of TABLE [tbl_post_content_text] by TABLE [tbl_post_detail] (with Paging)
        /// </summary>
        public static List<tbl_post_content_text> GetBypost_detail_id(Int32? post_detail_id, int PageSize, int PageIndex)
        {
            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
WITH [Paging_tbl_post_content_text] AS
(
    SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_post_content_text].[id_post_text]) AS PAGING_ROW_NUMBER,
            [tbl_post_content_text].*
    FROM    [tbl_post_content_text]
    WHERE   [post_detail_id] = @post_detail_id
)

SELECT      [Paging_tbl_post_content_text].*
FROM        [Paging_tbl_post_content_text]
WHERE		PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow";

            context.AddParameter("@post_detail_id", post_detail_id);
            return DBUtil.ExecuteMapper<tbl_post_content_text>(context, new tbl_post_content_text());
        }

        #endregion

    }
}