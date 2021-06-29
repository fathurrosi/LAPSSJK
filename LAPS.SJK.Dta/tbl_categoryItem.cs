
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_category]
    /// </summary>    
    public partial class tbl_categoryItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_category]
        /// </summary>        
        public static tbl_category Insert(tbl_category obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_category]([name], [slug], [term_group]) 
VALUES      (@name, @slug, @term_group)

SET @Err = @@Error

DECLARE @_cat_id BigInt
SELECT @_cat_id = SCOPE_IDENTITY()

SELECT  cat_id, name, slug, term_group
FROM    [tbl_category]
WHERE   [cat_id]  = @_cat_id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@slug", string.Format("{0}", obj.slug));
            context.AddParameter("@term_group", obj.term_group);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_category>(context, new tbl_category()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_category]
        /// </summary>        
        public static tbl_category Update(tbl_category obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_category]
SET         [name] = @name,
            [slug] = @slug,
            [term_group] = @term_group
WHERE       [cat_id]  = @cat_id

SET @Err = @@Error

SELECT  cat_id, name, slug, term_group 
FROM    [tbl_category]
WHERE   [cat_id]  = @cat_id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@slug", string.Format("{0}", obj.slug));
            context.AddParameter("@term_group", obj.term_group);
            context.AddParameter("@cat_id", obj.cat_id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_category>(context, new tbl_category()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_category]
        /// </summary>        
        public static int Delete(Int64 cat_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_category 
WHERE   [cat_id]  = @cat_id";
            context.AddParameter("@cat_id", cat_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_category]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_category ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_category]
        /// </summary>        
        public static List<tbl_category> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT cat_id, name, slug, term_group FROM tbl_category ";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_category>(context, new tbl_category());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_category]
        /// </summary>        
        public static List<tbl_category> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_category] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_category].[cat_id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_category].*
                FROM    [tbl_category]
                
            )

            SELECT      [Paging_tbl_category].*
            FROM        [Paging_tbl_category]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_category>(context, new tbl_category());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_category] by Primary Key
        /// </summary>        
        public static tbl_category GetByPK(Int64 cat_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT cat_id, name, slug, term_group FROM tbl_category
            WHERE [cat_id]  = @cat_id";
            context.AddParameter("@cat_id", cat_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_category>(context, new tbl_category()).FirstOrDefault();
        }

        #endregion

    }
}