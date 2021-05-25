
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Menu]
    /// </summary>    
    public partial class tbl_MenuItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Menu]
        /// </summary>        
        public static tbl_Menu Insert(tbl_Menu obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Menu]([ID], [Name], [Description], [Icon], [Url], [ParentID], [Sequence], [Deleted], [MenuType], [CreatedDate], [CreatedBy], [ModifiedBy], [ModifiedDate]) 
VALUES      (@ID, @Name, @Description, @Icon, @Url, @ParentID, @Sequence, @Deleted, @MenuType, @CreatedDate, @CreatedBy, @ModifiedBy, @ModifiedDate)

SET @Err = @@Error

SELECT  ID, Name, Description, Icon, Url, ParentID, Sequence, Deleted, MenuType, CreatedDate, CreatedBy, ModifiedBy, ModifiedDate
FROM    [tbl_Menu]
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
            return DBUtil.ExecuteMapper<tbl_Menu>(context, new tbl_Menu()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Menu]
        /// </summary>        
        public static tbl_Menu Update(tbl_Menu obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Menu]
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
FROM    [tbl_Menu]
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
            return DBUtil.ExecuteMapper<tbl_Menu>(context, new tbl_Menu()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Menu]
        /// </summary>        
        public static int Delete(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Menu 
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
        /// Get Total records from [tbl_Menu]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Menu";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Menu]
        /// </summary>        
        public static List<tbl_Menu> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT ID, Name, Description, Icon, Url, ParentID, Sequence, Deleted, MenuType, CreatedDate, CreatedBy, ModifiedBy, ModifiedDate FROM tbl_Menu";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Menu>(context, new tbl_Menu());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Menu]
        /// </summary>        
        public static List<tbl_Menu> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Menu] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Menu].[ID] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Menu].*
                FROM    [tbl_Menu]
            )

            SELECT      [Paging_tbl_Menu].*
            FROM        [Paging_tbl_Menu]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Menu>(context, new tbl_Menu());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Menu] by Primary Key
        /// </summary>        
        public static tbl_Menu GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT ID, Name, Description, Icon, Url, ParentID, Sequence, Deleted, MenuType, CreatedDate, CreatedBy, ModifiedBy, ModifiedDate FROM tbl_Menu
            WHERE [ID]  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Menu>(context, new tbl_Menu()).FirstOrDefault();
        }

        #endregion

    }
}