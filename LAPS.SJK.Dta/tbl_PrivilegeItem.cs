
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Privilege]
    /// </summary>    
    public partial class tbl_PrivilegeItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Privilege]
        /// </summary>        
        public static tbl_Privilege Insert(tbl_Privilege obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Privilege]([MenuID], [RoleID], [AllowCreate], [AllowRead], [AllowUpdate], [AllowDelete], [AllowPrint]) 
VALUES      (@MenuID, @RoleID, @AllowCreate, @AllowRead, @AllowUpdate, @AllowDelete, @AllowPrint)

SET @Err = @@Error

SELECT  MenuID, RoleID, AllowCreate, AllowRead, AllowUpdate, AllowDelete, AllowPrint
FROM    [tbl_Privilege]
WHERE   [RoleID]  = @RoleID
            AND [MenuID] = @MenuID";
            context.AddParameter("@MenuID", obj.MenuID);
            context.AddParameter("@RoleID", obj.RoleID);
            context.AddParameter("@AllowCreate", obj.AllowCreate);
            context.AddParameter("@AllowRead", obj.AllowRead);
            context.AddParameter("@AllowUpdate", obj.AllowUpdate);
            context.AddParameter("@AllowDelete", obj.AllowDelete);
            context.AddParameter("@AllowPrint", obj.AllowPrint);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Privilege>(context, new tbl_Privilege()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Privilege]
        /// </summary>        
        public static tbl_Privilege Update(tbl_Privilege obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Privilege]
SET         [AllowCreate] = @AllowCreate,
            [AllowRead] = @AllowRead,
            [AllowUpdate] = @AllowUpdate,
            [AllowDelete] = @AllowDelete,
            [AllowPrint] = @AllowPrint
WHERE       [RoleID]  = @RoleID
            AND [MenuID] = @MenuID

SET @Err = @@Error

SELECT  MenuID, RoleID, AllowCreate, AllowRead, AllowUpdate, AllowDelete, AllowPrint 
FROM    [tbl_Privilege]
WHERE   [RoleID]  = @RoleID
        AND [MenuID] = @MenuID";
            context.AddParameter("@AllowCreate", obj.AllowCreate);
            context.AddParameter("@AllowRead", obj.AllowRead);
            context.AddParameter("@AllowUpdate", obj.AllowUpdate);
            context.AddParameter("@AllowDelete", obj.AllowDelete);
            context.AddParameter("@AllowPrint", obj.AllowPrint);
            context.AddParameter("@RoleID", obj.RoleID);
            context.AddParameter("@MenuID", obj.MenuID);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Privilege>(context, new tbl_Privilege()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Privilege]
        /// </summary>        
        public static int Delete(Int32 RoleID, Int32 MenuID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Privilege 
WHERE   [RoleID]  = @RoleID
        AND [MenuID] = @MenuID";
            context.AddParameter("@RoleID", RoleID);
            context.AddParameter("@MenuID", MenuID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_Privilege]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Privilege";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Privilege]
        /// </summary>        
        public static List<tbl_Privilege> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT MenuID, RoleID, AllowCreate, AllowRead, AllowUpdate, AllowDelete, AllowPrint FROM tbl_Privilege";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Privilege>(context, new tbl_Privilege());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Privilege]
        /// </summary>        
        public static List<tbl_Privilege> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Privilege] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Privilege].[RoleID], [tbl_Privilege].[MenuID] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Privilege].*
                FROM    [tbl_Privilege]
            )

            SELECT      [Paging_tbl_Privilege].*
            FROM        [Paging_tbl_Privilege]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Privilege>(context, new tbl_Privilege());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Privilege] by Primary Key
        /// </summary>        
        public static tbl_Privilege GetByPK(Int32 RoleID, Int32 MenuID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT MenuID, RoleID, AllowCreate, AllowRead, AllowUpdate, AllowDelete, AllowPrint FROM tbl_Privilege
            WHERE [RoleID]  = @RoleID, AND [MenuID] = @MenuID";
            context.AddParameter("@RoleID", RoleID);
            context.AddParameter("@MenuID", MenuID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Privilege>(context, new tbl_Privilege()).FirstOrDefault();
        }

        /// <summary>
        /// Get All records of TABLE [tbl_Privilege] by TABLE [tbl_Menu]
        /// </summary>
        public static List<tbl_Privilege> GetByMenuID(Int32 MenuID)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
SELECT  MenuID, RoleID, AllowCreate, AllowRead, AllowUpdate, AllowDelete, AllowPrint
FROM    [tbl_Privilege]
WHERE   [MenuID] = @MenuID";

            context.AddParameter("@MenuID", MenuID);
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Privilege>(context, new tbl_Privilege());
        }

        /// <summary>
        /// Get All records of TABLE [tbl_Privilege] by TABLE [tbl_Menu] (with Paging)
        /// </summary>
        public static List<tbl_Privilege> GetByMenuID(Int32 MenuID, int PageSize, int PageIndex)
        {
            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
WITH [Paging_tbl_Privilege] AS
(
    SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Privilege].[RoleID], [tbl_Privilege].[MenuID]) AS PAGING_ROW_NUMBER,
            [tbl_Privilege].*
    FROM    [tbl_Privilege]
    WHERE   [MenuID] = @MenuID
)

SELECT      [Paging_tbl_Privilege].*
FROM        [Paging_tbl_Privilege]
WHERE		PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow";

            context.AddParameter("@MenuID", MenuID);
            return DBUtil.ExecuteMapper<tbl_Privilege>(context, new tbl_Privilege());
        }

        /// <summary>
        /// Get All records of TABLE [tbl_Privilege] by TABLE [tbl_Role]
        /// </summary>
        public static List<tbl_Privilege> GetByRoleID(Int32 RoleID)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
SELECT  MenuID, RoleID, AllowCreate, AllowRead, AllowUpdate, AllowDelete, AllowPrint
FROM    [tbl_Privilege]
WHERE   [RoleID] = @RoleID";

            context.AddParameter("@RoleID", RoleID);
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Privilege>(context, new tbl_Privilege());
        }

        /// <summary>
        /// Get All records of TABLE [tbl_Privilege] by TABLE [tbl_Role] (with Paging)
        /// </summary>
        public static List<tbl_Privilege> GetByRoleID(Int32 RoleID, int PageSize, int PageIndex)
        {
            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
WITH [Paging_tbl_Privilege] AS
(
    SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Privilege].[RoleID], [tbl_Privilege].[MenuID]) AS PAGING_ROW_NUMBER,
            [tbl_Privilege].*
    FROM    [tbl_Privilege]
    WHERE   [RoleID] = @RoleID
)

SELECT      [Paging_tbl_Privilege].*
FROM        [Paging_tbl_Privilege]
WHERE		PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow";

            context.AddParameter("@RoleID", RoleID);
            return DBUtil.ExecuteMapper<tbl_Privilege>(context, new tbl_Privilege());
        }

        #endregion

    }
}