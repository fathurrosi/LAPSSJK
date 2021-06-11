
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_post_detail]
    /// </summary>    
    public partial class tbl_post_detailItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_post_detail]
        /// </summary>        
        public static tbl_post_detail Insert(tbl_post_detail obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_post_detail]([post_id], [post_type], [post_order]) 
VALUES      (@post_id, @post_type, @post_order)

SET @Err = @@Error

DECLARE @_post_detail_id Int
SELECT @_post_detail_id = SCOPE_IDENTITY()

SELECT  post_detail_id, post_id, post_type, post_order
FROM    [tbl_post_detail]
WHERE   [post_detail_id]  = @_post_detail_id";
            context.AddParameter("@post_id", obj.post_id);
            context.AddParameter("@post_type", string.Format("{0}", obj.post_type));
            context.AddParameter("@post_order", obj.post_order);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_detail>(context, new tbl_post_detail()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_post_detail]
        /// </summary>        
        public static tbl_post_detail Update(tbl_post_detail obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_post_detail]
SET         [post_id] = @post_id,
            [post_type] = @post_type,
            [post_order] = @post_order
WHERE       [post_detail_id]  = @post_detail_id

SET @Err = @@Error

SELECT  post_detail_id, post_id, post_type, post_order 
FROM    [tbl_post_detail]
WHERE   [post_detail_id]  = @post_detail_id";
            context.AddParameter("@post_id", obj.post_id);
            context.AddParameter("@post_type", string.Format("{0}", obj.post_type));
            context.AddParameter("@post_order", obj.post_order);
            context.AddParameter("@post_detail_id", obj.post_detail_id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_detail>(context, new tbl_post_detail()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_post_detail]
        /// </summary>        
        public static int Delete(Int32 post_detail_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_post_detail 
WHERE   [post_detail_id]  = @post_detail_id";
            context.AddParameter("@post_detail_id", post_detail_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_post_detail]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_post_detail";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_post_detail]
        /// </summary>        
        public static List<tbl_post_detail> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT post_detail_id, post_id, post_type, post_order FROM tbl_post_detail";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_detail>(context, new tbl_post_detail());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_post_detail]
        /// </summary>        
        public static List<tbl_post_detail> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_post_detail] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_post_detail].[post_detail_id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_post_detail].*
                FROM    [tbl_post_detail]
            )

            SELECT      [Paging_tbl_post_detail].*
            FROM        [Paging_tbl_post_detail]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_post_detail>(context, new tbl_post_detail());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_post_detail] by Primary Key
        /// </summary>        
        public static tbl_post_detail GetByPK(Int32 post_detail_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT post_detail_id, post_id, post_type, post_order FROM tbl_post_detail
            WHERE [post_detail_id]  = @post_detail_id";
            context.AddParameter("@post_detail_id", post_detail_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_detail>(context, new tbl_post_detail()).FirstOrDefault();
        }

        #endregion

    }
}