
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_role]
    /// </summary>    
    public partial class tbl_roleItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_role]
        /// </summary>        
        public static tbl_role Insert(tbl_role obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_role]([Name], [Description], [is_deleted], [created], [creator], [edited], [editor]) 
VALUES      (@Name, @Description, @is_deleted, @created, @creator, @edited, @editor)

SET @Err = @@Error

DECLARE @_ID Int
SELECT @_ID = SCOPE_IDENTITY()

SELECT  ID, Name, Description, is_deleted, created, creator, edited, editor
FROM    [tbl_role]
WHERE   [ID]  = @_ID";
            context.AddParameter("@Name", string.Format("{0}", obj.Name));
            context.AddParameter("@Description", string.Format("{0}", obj.Description));
            context.AddParameter("@is_deleted", obj.is_deleted);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_role>(context, new tbl_role()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_role]
        /// </summary>        
        public static tbl_role Update(tbl_role obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_role]
SET         [Name] = @Name,
            [Description] = @Description,
            [is_deleted] = @is_deleted,
            [creator] = @creator,
            [edited] = @edited,
            [editor] = @editor
WHERE       [ID]  = @ID

SET @Err = @@Error

SELECT  ID, Name, Description, is_deleted, created, creator, edited, editor 
FROM    [tbl_role]
WHERE   [ID]  = @ID";
            context.AddParameter("@Name", string.Format("{0}", obj.Name));
            context.AddParameter("@Description", string.Format("{0}", obj.Description));
            context.AddParameter("@is_deleted", obj.is_deleted);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@ID", obj.ID);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_role>(context, new tbl_role()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_role]
        /// </summary>        
        public static int Delete(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"Update tbl_role Set is_deleted = 1 
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
        /// Get Total records from [tbl_role]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_role WHERE is_deleted <> 1 ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_role]
        /// </summary>        
        public static List<tbl_role> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT ID, Name, Description, is_deleted, created, creator, edited, editor FROM tbl_role WHERE is_deleted <> 1 ";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_role>(context, new tbl_role());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_role]
        /// </summary>        
        public static List<tbl_role> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_role] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_role].[ID] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_role].*
                FROM    [tbl_role]
                WHERE   is_deleted <> 1 
            )

            SELECT      [Paging_tbl_role].*
            FROM        [Paging_tbl_role]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_role>(context, new tbl_role());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_role] by Primary Key
        /// </summary>        
        public static tbl_role GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT ID, Name, Description, is_deleted, created, creator, edited, editor FROM tbl_role
            WHERE [ID]  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_role>(context, new tbl_role()).FirstOrDefault();
        }

        #endregion

    }
}