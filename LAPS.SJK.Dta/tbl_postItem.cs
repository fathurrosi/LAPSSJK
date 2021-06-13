
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_post]
    /// </summary>    
    public partial class tbl_postItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_post]
        /// </summary>        
        public static tbl_post Insert(tbl_post obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_post]([name], [cat_id], [created], [creator], [edited], [editor]) 
VALUES      (@name, @cat_id, @created, @creator, @edited, @editor)

SET @Err = @@Error

DECLARE @_post_id Int
SELECT @_post_id = SCOPE_IDENTITY()

SELECT  post_id, name, cat_id, created, creator, edited, editor
FROM    [tbl_post]
WHERE   [post_id]  = @_post_id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@cat_id", obj.cat_id);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post>(context, new tbl_post()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_post]
        /// </summary>        
        public static tbl_post Update(tbl_post obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_post]
SET         [name] = @name,
            [cat_id] = @cat_id,
            [creator] = @creator,
            [edited] = @edited,
            [editor] = @editor
WHERE       [post_id]  = @post_id

SET @Err = @@Error

SELECT  post_id, name, cat_id, created, creator, edited, editor 
FROM    [tbl_post]
WHERE   [post_id]  = @post_id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@cat_id", obj.cat_id);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@post_id", obj.post_id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post>(context, new tbl_post()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_post]
        /// </summary>        
        public static int Delete(Int32 post_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_post 
WHERE   [post_id]  = @post_id";
            context.AddParameter("@post_id", post_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_post]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_post";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_post]
        /// </summary>        
        public static List<tbl_post> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT post_id, name, cat_id, created, creator, edited, editor FROM tbl_post";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post>(context, new tbl_post());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_post]
        /// </summary>        
        public static List<tbl_post> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_post] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_post].[post_id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_post].*
                FROM    [tbl_post]
            )

            SELECT      [Paging_tbl_post].*
            FROM        [Paging_tbl_post]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_post>(context, new tbl_post());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_post] by Primary Key
        /// </summary>        
        public static tbl_post GetByPK(Int32 post_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT post_id, name, cat_id, created, creator, edited, editor FROM tbl_post
            WHERE [post_id]  = @post_id";
            context.AddParameter("@post_id", post_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post>(context, new tbl_post()).FirstOrDefault();
        }

        #endregion

    }
}