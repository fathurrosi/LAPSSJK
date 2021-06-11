
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_privilege]
    /// </summary>    
    public partial class tbl_privilegeItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_privilege]
        /// </summary>        
        public static tbl_privilege Insert(tbl_privilege obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_privilege]([MenuID], [RoleID], [AllowCreate], [AllowRead], [AllowUpdate], [AllowDelete], [AllowPrint]) 
VALUES      (@MenuID, @RoleID, @AllowCreate, @AllowRead, @AllowUpdate, @AllowDelete, @AllowPrint)

SET @Err = @@Error

SELECT  MenuID, RoleID, AllowCreate, AllowRead, AllowUpdate, AllowDelete, AllowPrint
FROM    [tbl_privilege]
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
            return DBUtil.ExecuteMapper<tbl_privilege>(context, new tbl_privilege()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_privilege]
        /// </summary>        
        public static tbl_privilege Update(tbl_privilege obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_privilege]
SET         [AllowCreate] = @AllowCreate,
            [AllowRead] = @AllowRead,
            [AllowUpdate] = @AllowUpdate,
            [AllowDelete] = @AllowDelete,
            [AllowPrint] = @AllowPrint
WHERE       [RoleID]  = @RoleID
            AND [MenuID] = @MenuID

SET @Err = @@Error

SELECT  MenuID, RoleID, AllowCreate, AllowRead, AllowUpdate, AllowDelete, AllowPrint 
FROM    [tbl_privilege]
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
            return DBUtil.ExecuteMapper<tbl_privilege>(context, new tbl_privilege()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_privilege]
        /// </summary>        
        public static int Delete(Int32 RoleID, Int32 MenuID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_privilege 
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
        /// Get Total records from [tbl_privilege]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_privilege";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_privilege]
        /// </summary>        
        public static List<tbl_privilege> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT MenuID, RoleID, AllowCreate, AllowRead, AllowUpdate, AllowDelete, AllowPrint FROM tbl_privilege";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_privilege>(context, new tbl_privilege());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_privilege]
        /// </summary>        
        public static List<tbl_privilege> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_privilege] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_privilege].[RoleID], [tbl_privilege].[MenuID] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_privilege].*
                FROM    [tbl_privilege]
            )

            SELECT      [Paging_tbl_privilege].*
            FROM        [Paging_tbl_privilege]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_privilege>(context, new tbl_privilege());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_privilege] by Primary Key
        /// </summary>        
        public static tbl_privilege GetByPK(Int32 RoleID, Int32 MenuID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT MenuID, RoleID, AllowCreate, AllowRead, AllowUpdate, AllowDelete, AllowPrint FROM tbl_privilege
            WHERE [RoleID]  = @RoleID, AND [MenuID] = @MenuID";
            context.AddParameter("@RoleID", RoleID);
            context.AddParameter("@MenuID", MenuID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_privilege>(context, new tbl_privilege()).FirstOrDefault();
        }

        /// <summary>
        /// Get All records of TABLE [tbl_privilege] by TABLE [tbl_menu_x]
        /// </summary>
        public static List<tbl_privilege> GetByMenuID(Int32 MenuID)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
SELECT  MenuID, RoleID, AllowCreate, AllowRead, AllowUpdate, AllowDelete, AllowPrint
FROM    [tbl_privilege]
WHERE   [MenuID] = @MenuID";

            context.AddParameter("@MenuID", MenuID);
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_privilege>(context, new tbl_privilege());
        }

        /// <summary>
        /// Get All records of TABLE [tbl_privilege] by TABLE [tbl_menu_x] (with Paging)
        /// </summary>
        public static List<tbl_privilege> GetByMenuID(Int32 MenuID, int PageSize, int PageIndex)
        {
            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
WITH [Paging_tbl_privilege] AS
(
    SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_privilege].[RoleID], [tbl_privilege].[MenuID]) AS PAGING_ROW_NUMBER,
            [tbl_privilege].*
    FROM    [tbl_privilege]
    WHERE   [MenuID] = @MenuID
)

SELECT      [Paging_tbl_privilege].*
FROM        [Paging_tbl_privilege]
WHERE		PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow";

            context.AddParameter("@MenuID", MenuID);
            return DBUtil.ExecuteMapper<tbl_privilege>(context, new tbl_privilege());
        }

        /// <summary>
        /// Get All records of TABLE [tbl_privilege] by TABLE [tbl_role]
        /// </summary>
        public static List<tbl_privilege> GetByRoleID(Int32 RoleID)
        {
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
SELECT  MenuID, RoleID, AllowCreate, AllowRead, AllowUpdate, AllowDelete, AllowPrint
FROM    [tbl_privilege]
WHERE   [RoleID] = @RoleID";

            context.AddParameter("@RoleID", RoleID);
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_privilege>(context, new tbl_privilege());
        }

        /// <summary>
        /// Get All records of TABLE [tbl_privilege] by TABLE [tbl_role] (with Paging)
        /// </summary>
        public static List<tbl_privilege> GetByRoleID(Int32 RoleID, int PageSize, int PageIndex)
        {
            long FirstRow = ((long)PageIndex * (long)PageSize) + 1;
            long LastRow = ((long)PageIndex * (long)PageSize) + PageSize;
            
            IDBHelper context = new DBHelper();
            context.CommandType = System.Data.CommandType.Text;
            string sqlQuery =@"
WITH [Paging_tbl_privilege] AS
(
    SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_privilege].[RoleID], [tbl_privilege].[MenuID]) AS PAGING_ROW_NUMBER,
            [tbl_privilege].*
    FROM    [tbl_privilege]
    WHERE   [RoleID] = @RoleID
)

SELECT      [Paging_tbl_privilege].*
FROM        [Paging_tbl_privilege]
WHERE		PAGING_ROW_NUMBER BETWEEN @FirstRow AND @LastRow";

            context.AddParameter("@RoleID", RoleID);
            return DBUtil.ExecuteMapper<tbl_privilege>(context, new tbl_privilege());
        }

        #endregion

    }
}