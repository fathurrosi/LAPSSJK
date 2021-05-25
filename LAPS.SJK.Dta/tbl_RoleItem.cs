
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Role]
    /// </summary>    
    public partial class tbl_RoleItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Role]
        /// </summary>        
        public static tbl_Role Insert(tbl_Role obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Role]([Name], [Description], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) 
VALUES      (@Name, @Description, @CreatedDate, @CreatedBy, @ModifiedDate, @ModifiedBy)

SET @Err = @@Error

DECLARE @_ID Int
SELECT @_ID = SCOPE_IDENTITY()

SELECT  ID, Name, Description, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy
FROM    [tbl_Role]
WHERE   [ID]  = @_ID";
            context.AddParameter("@Name", string.Format("{0}", obj.Name));
            context.AddParameter("@Description", string.Format("{0}", obj.Description));
            context.AddParameter("@CreatedDate", obj.CreatedDate);
            context.AddParameter("@CreatedBy", string.Format("{0}", obj.CreatedBy));
            context.AddParameter("@ModifiedDate", obj.ModifiedDate);
            context.AddParameter("@ModifiedBy", string.Format("{0}", obj.ModifiedBy));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Role>(context, new tbl_Role()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Role]
        /// </summary>        
        public static tbl_Role Update(tbl_Role obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Role]
SET         [Name] = @Name,
            [Description] = @Description,
            [CreatedDate] = @CreatedDate,
            [CreatedBy] = @CreatedBy,
            [ModifiedDate] = @ModifiedDate,
            [ModifiedBy] = @ModifiedBy
WHERE       [ID]  = @ID

SET @Err = @@Error

SELECT  ID, Name, Description, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy 
FROM    [tbl_Role]
WHERE   [ID]  = @ID";
            context.AddParameter("@Name", string.Format("{0}", obj.Name));
            context.AddParameter("@Description", string.Format("{0}", obj.Description));
            context.AddParameter("@CreatedDate", obj.CreatedDate);
            context.AddParameter("@CreatedBy", string.Format("{0}", obj.CreatedBy));
            context.AddParameter("@ModifiedDate", obj.ModifiedDate);
            context.AddParameter("@ModifiedBy", string.Format("{0}", obj.ModifiedBy));
            context.AddParameter("@ID", obj.ID);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Role>(context, new tbl_Role()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Role]
        /// </summary>        
        public static int Delete(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Role 
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
        /// Get Total records from [tbl_Role]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Role";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Role]
        /// </summary>        
        public static List<tbl_Role> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT ID, Name, Description, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy FROM tbl_Role";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Role>(context, new tbl_Role());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Role]
        /// </summary>        
        public static List<tbl_Role> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Role] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Role].[ID] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Role].*
                FROM    [tbl_Role]
            )

            SELECT      [Paging_tbl_Role].*
            FROM        [Paging_tbl_Role]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Role>(context, new tbl_Role());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Role] by Primary Key
        /// </summary>        
        public static tbl_Role GetByPK(Int32 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT ID, Name, Description, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy FROM tbl_Role
            WHERE [ID]  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Role>(context, new tbl_Role()).FirstOrDefault();
        }

        #endregion

    }
}