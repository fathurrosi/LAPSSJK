
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_session]
    /// </summary>    
    public partial class tbl_sessionItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_session]
        /// </summary>        
        public static tbl_session Insert(tbl_session obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_session]([id], [name], [updated], [updatedBy]) 
VALUES      (@id, @name, @updated, @updatedBy)

SET @Err = @@Error

SELECT  id, name, updated, updatedBy
FROM    [tbl_session]
WHERE   [id]  = @id";
            context.AddParameter("@id", obj.id);
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updatedBy", string.Format("{0}", obj.updatedBy));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_session>(context, new tbl_session()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_session]
        /// </summary>        
        public static tbl_session Update(tbl_session obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_session]
SET         [name] = @name,
            [updated] = @updated,
            [updatedBy] = @updatedBy
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, name, updated, updatedBy 
FROM    [tbl_session]
WHERE   [id]  = @id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updatedBy", string.Format("{0}", obj.updatedBy));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_session>(context, new tbl_session()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_session]
        /// </summary>        
        public static int Delete(Guid id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_session 
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
        /// Get Total records from [tbl_session]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_session ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_session]
        /// </summary>        
        public static List<tbl_session> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, name, updated, updatedBy FROM tbl_session ";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_session>(context, new tbl_session());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_session]
        /// </summary>        
        public static List<tbl_session> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_session] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_session].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_session].*
                FROM    [tbl_session]
                
            )

            SELECT      [Paging_tbl_session].*
            FROM        [Paging_tbl_session]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_session>(context, new tbl_session());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_session] by Primary Key
        /// </summary>        
        public static tbl_session GetByPK(Guid id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, name, updated, updatedBy FROM tbl_session
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_session>(context, new tbl_session()).FirstOrDefault();
        }

        #endregion

    }
}