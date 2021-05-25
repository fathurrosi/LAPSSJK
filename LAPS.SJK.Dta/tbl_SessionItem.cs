
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Session]
    /// </summary>    
    public partial class tbl_SessionItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Session]
        /// </summary>        
        public static tbl_Session Insert(tbl_Session obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Session]([id], [name], [updatedBy]) 
VALUES      (@id, @name, @updatedBy)

SET @Err = @@Error

SELECT  id, name, updated, updatedBy
FROM    [tbl_Session]
WHERE   [id]  = @id";
            context.AddParameter("@id", obj.id);
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@updatedBy", string.Format("{0}", obj.updatedBy));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Session>(context, new tbl_Session()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Session]
        /// </summary>        
        public static tbl_Session Update(tbl_Session obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Session]
SET         [name] = @name,
            [updated] = @updated,
            [updatedBy] = @updatedBy
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, name, updated, updatedBy 
FROM    [tbl_Session]
WHERE   [id]  = @id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@updated", obj.updated);
            context.AddParameter("@updatedBy", string.Format("{0}", obj.updatedBy));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Session>(context, new tbl_Session()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Session]
        /// </summary>        
        public static int Delete(Guid id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Session 
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
        /// Get Total records from [tbl_Session]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Session";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Session]
        /// </summary>        
        public static List<tbl_Session> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, name, updated, updatedBy FROM tbl_Session";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Session>(context, new tbl_Session());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Session]
        /// </summary>        
        public static List<tbl_Session> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Session] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Session].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Session].*
                FROM    [tbl_Session]
            )

            SELECT      [Paging_tbl_Session].*
            FROM        [Paging_tbl_Session]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Session>(context, new tbl_Session());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Session] by Primary Key
        /// </summary>        
        public static tbl_Session GetByPK(Guid id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, name, updated, updatedBy FROM tbl_Session
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Session>(context, new tbl_Session()).FirstOrDefault();
        }

        #endregion

    }
}