
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_menu_x]
    /// </summary>    
    public partial class tbl_menu_xItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_menu_x]
        /// </summary>        
        public static tbl_menu_x Insert(tbl_menu_x obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_menu_x]([ID], [Name], [Description], [Icon], [Url], [ParentID], [Sequence], [Deleted], [MenuType], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate]) 
VALUES      (@ID, @Name, @Description, @Icon, @Url, @ParentID, @Sequence, @Deleted, @MenuType, @CreatedDate, @CreatedBy, @ModifiedBy, @ModifiedDate)

SET @Err = @@Error

SELECT  ID, Name, Description, Icon, Url, ParentID, Sequence, Deleted, MenuType, CreatedDate, CreatedBy, ModifiedBy, ModifiedDate
FROM    [tbl_menu_x]
WHERE   [ID]  = @ID";
            context.AddParameter("@ID", obj.ID);
            context.AddParameter("@Name", string.Format("{0}", obj.Name));
            context.AddParameter("@Description", string.Format("{0}", obj.Description));
            context.AddParameter("@Icon", string.Format("{0}", obj.Icon));
            context.AddParameter("@Url", string.Format("{0}", obj.Url));
            context.AddParameter("@ParentID", obj.ParentID);
            context.AddParameter("@Sequence", obj.Sequence);
            context.AddParameter("@Deleted", obj.Deleted);
            context.AddParameter("@MenuType", string.Format("{0}", obj.MenuType));
            context.AddParameter("@CreatedDate", obj.CreatedDate);
            context.AddParameter("@CreatedBy", string.Format("{0}", obj.CreatedBy));
            context.AddParameter("@ModifiedBy", string.Format("{0}", obj.ModifiedBy));
            context.AddParameter("@ModifiedDate", obj.ModifiedDate);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_menu_x>(context, new tbl_menu_x()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_menu_x]
        /// </summary>        
        public static tbl_menu_x Update(tbl_menu_x obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_menu_x]
SET         [Name] = @Name,
            [Description] = @Description,
            [Icon] = @Icon,
            [Url] = @Url,
            [ParentID] = @ParentID,
            [Sequence] = @Sequence,
            [Deleted] = @Deleted,
            [MenuType] = @MenuType,
            [CreatedDate] = @CreatedDate,
            [CreatedBy] = @CreatedBy,
            [ModifiedBy] = @ModifiedBy,
            [ModifiedDate] = @ModifiedDate
WHERE       [ID]  = @ID

SET @Err = @@Error

SELECT  ID, Name, Description, Icon, Url, ParentID, Sequence, Deleted, MenuType, CreatedDate, CreatedBy, ModifiedBy, ModifiedDate 
FROM    [tbl_menu_x]
WHERE   [ID]  = @ID";
            context.AddParameter("@Name", string.Format("{0}", obj.Name));
            context.AddParameter("@Description", string.Format("{0}", obj.Description));
            context.AddParameter("@Icon", string.Format("{0}", obj.Icon));
            context.AddParameter("@Url", string.Format("{0}", obj.Url));
            context.AddParameter("@ParentID", obj.ParentID);
            context.AddParameter("@Sequence", obj.Sequence);
            context.AddParameter("@Deleted", obj.Deleted);
            context.AddParameter("@MenuType", string.Format("{0}", obj.MenuType));
            context.AddParameter("@CreatedDate", obj.CreatedDate);
            context.AddParameter("@CreatedBy", string.Format("{0}", obj.CreatedBy));
            context.AddParameter("@ModifiedBy", string.Format("{0}", obj.ModifiedBy));
            context.AddParameter("@ModifiedDate", obj.ModifiedDate);
            context.AddParameter("@ID", obj.ID);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_menu_x>(context, new tbl_menu_x()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_menu_x]
        /// </summary>        
        public static int Delete(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_menu_x 
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
        /// Get Total records from [tbl_menu_x]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_menu_x";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_menu_x]
        /// </summary>        
        public static List<tbl_menu_x> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT ID, Name, Description, Icon, Url, ParentID, Sequence, Deleted, MenuType, CreatedDate, CreatedBy, ModifiedBy, ModifiedDate FROM tbl_menu_x";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_menu_x>(context, new tbl_menu_x());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_menu_x]
        /// </summary>        
        public static List<tbl_menu_x> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_menu_x] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_menu_x].[ID] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_menu_x].*
                FROM    [tbl_menu_x]
            )

            SELECT      [Paging_tbl_menu_x].*
            FROM        [Paging_tbl_menu_x]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_menu_x>(context, new tbl_menu_x());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_menu_x] by Primary Key
        /// </summary>        
        public static tbl_menu_x GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT ID, Name, Description, Icon, Url, ParentID, Sequence, Deleted, MenuType, CreatedDate, CreatedBy, ModifiedBy, ModifiedDate FROM tbl_menu_x
            WHERE [ID]  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_menu_x>(context, new tbl_menu_x()).FirstOrDefault();
        }

        #endregion

    }
}