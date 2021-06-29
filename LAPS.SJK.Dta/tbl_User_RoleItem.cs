
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_user_role]
    /// </summary>    
    public partial class tbl_user_roleItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_user_role]
        /// </summary>        
        public static tbl_user_role Insert(tbl_user_role obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_user_role]([Username], [RoleID]) 
VALUES      (@Username, @RoleID)

SET @Err = @@Error

DECLARE @_ID Int
SELECT @_ID = SCOPE_IDENTITY()

SELECT  ID, Username, RoleID
FROM    [tbl_user_role]
WHERE   [ID]  = @_ID";
            context.AddParameter("@Username", string.Format("{0}", obj.Username));
            context.AddParameter("@RoleID", obj.RoleID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_user_role]
        /// </summary>        
        public static tbl_user_role Update(tbl_user_role obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_user_role]
SET         [Username] = @Username,
            [RoleID] = @RoleID
WHERE       [ID]  = @ID

SET @Err = @@Error

SELECT  ID, Username, RoleID 
FROM    [tbl_user_role]
WHERE   [ID]  = @ID";
            context.AddParameter("@Username", string.Format("{0}", obj.Username));
            context.AddParameter("@RoleID", obj.RoleID);
            context.AddParameter("@ID", obj.ID);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_user_role]
        /// </summary>        
        public static int Delete(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_user_role 
WHERE   [ID]  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_user_role]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_user_role ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_user_role]
        /// </summary>        
        public static List<tbl_user_role> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT ID, Username, RoleID FROM tbl_user_role ";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_user_role]
        /// </summary>        
        public static List<tbl_user_role> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_user_role] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_user_role].[ID] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_user_role].*
                FROM    [tbl_user_role]
                
            )

            SELECT      [Paging_tbl_user_role].*
            FROM        [Paging_tbl_user_role]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_user_role] by Primary Key
        /// </summary>        
        public static tbl_user_role GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT ID, Username, RoleID FROM tbl_user_role
            WHERE [ID]  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role()).FirstOrDefault();
        }

        /// <summary>
        /// Get All records of TABLE [tbl_user_role] by TABLE [tbl_user]
        /// </summary>
        public static List<tbl_user_role> GetByUsername(string Username)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
SELECT  ID, Username, RoleID
FROM    [tbl_user_role]
WHERE   [Username] = @Username";

            context.AddParameter("@Username", Username);
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role());
        }

        /// <summary>
        /// Get All records of TABLE [tbl_user_role] by TABLE [tbl_user] (with Paging)
        /// </summary>
        public static List<tbl_user_role> GetByUsername(string Username, int PageSize, int PageIndex)
        {
            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
WITH [Paging_tbl_user_role] AS
(
    SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_user_role].[ID]) AS PAGING_ROW_NUMBER,
            [tbl_user_role].*
    FROM    [tbl_user_role]
    WHERE   [Username] = @Username
)

SELECT      [Paging_tbl_user_role].*
FROM        [Paging_tbl_user_role]
WHERE		PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow";

            context.AddParameter("@Username", Username);
            return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role());
        }

        /// <summary>
        /// Get All records of TABLE [tbl_user_role] by TABLE [tbl_role]
        /// </summary>
        public static List<tbl_user_role> GetByRoleID(Int32? RoleID)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
SELECT  ID, Username, RoleID
FROM    [tbl_user_role]
WHERE   [RoleID] = @RoleID";

            context.AddParameter("@RoleID", RoleID);
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role());
        }

        /// <summary>
        /// Get All records of TABLE [tbl_user_role] by TABLE [tbl_role] (with Paging)
        /// </summary>
        public static List<tbl_user_role> GetByRoleID(Int32? RoleID, int PageSize, int PageIndex)
        {
            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
WITH [Paging_tbl_user_role] AS
(
    SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_user_role].[ID]) AS PAGING_ROW_NUMBER,
            [tbl_user_role].*
    FROM    [tbl_user_role]
    WHERE   [RoleID] = @RoleID
)

SELECT      [Paging_tbl_user_role].*
FROM        [Paging_tbl_user_role]
WHERE		PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow";

            context.AddParameter("@RoleID", RoleID);
            return DBUtil.ExecuteMapper<tbl_user_role>(context, new tbl_user_role());
        }

        #endregion

    }
}