
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_user]
    /// </summary>    
    public partial class tbl_userItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_user]
        /// </summary>        
        public static tbl_user Insert(tbl_user obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_user]([Username], [Password], [LastLogin], [IsLogin], [IPAddress], [MachineName], [is_deleted], [FullName], [created], [creator], [edited], [editor]) 
VALUES      (@Username, @Password, @LastLogin, @IsLogin, @IPAddress, @MachineName, @is_deleted, @FullName, @created, @creator, @edited, @editor)

SET @Err = @@Error

SELECT  Username, Password, LastLogin, IsLogin, IPAddress, MachineName, is_deleted, FullName, created, creator, edited, editor
FROM    [tbl_user]
WHERE   [Username]  = @Username";
            context.AddParameter("@Username", string.Format("{0}", obj.Username));
            context.AddParameter("@Password", string.Format("{0}", obj.Password));
            context.AddParameter("@LastLogin", obj.LastLogin);
            context.AddParameter("@IsLogin", obj.IsLogin);
            context.AddParameter("@IPAddress", string.Format("{0}", obj.IPAddress));
            context.AddParameter("@MachineName", string.Format("{0}", obj.MachineName));
            context.AddParameter("@is_deleted", obj.is_deleted);
            context.AddParameter("@FullName", string.Format("{0}", obj.FullName));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_user>(context, new tbl_user()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_user]
        /// </summary>        
        public static tbl_user Update(tbl_user obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_user]
SET         [Password] = @Password,
            [LastLogin] = @LastLogin,
            [IsLogin] = @IsLogin,
            [IPAddress] = @IPAddress,
            [MachineName] = @MachineName,
            [is_deleted] = @is_deleted,
            [FullName] = @FullName,
            [creator] = @creator,
            [edited] = @edited,
            [editor] = @editor
WHERE       [Username]  = @Username

SET @Err = @@Error

SELECT  Username, Password, LastLogin, IsLogin, IPAddress, MachineName, is_deleted, FullName, created, creator, edited, editor 
FROM    [tbl_user]
WHERE   [Username]  = @Username";
            context.AddParameter("@Password", string.Format("{0}", obj.Password));
            context.AddParameter("@LastLogin", obj.LastLogin);
            context.AddParameter("@IsLogin", obj.IsLogin);
            context.AddParameter("@IPAddress", string.Format("{0}", obj.IPAddress));
            context.AddParameter("@MachineName", string.Format("{0}", obj.MachineName));
            context.AddParameter("@is_deleted", obj.is_deleted);
            context.AddParameter("@FullName", string.Format("{0}", obj.FullName));
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@edited", obj.edited);
            context.AddParameter("@editor", string.Format("{0}", obj.editor));
            context.AddParameter("@Username", string.Format("{0}", obj.Username));            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_user>(context, new tbl_user()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_user]
        /// </summary>        
        public static int Delete(string Username)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"Update tbl_user Set is_deleted = 1 
WHERE   [Username]  = @Username";
            context.AddParameter("@Username",  string.Format("{0}", Username));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_user]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_user WHERE is_deleted <> 1 ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_user]
        /// </summary>        
        public static List<tbl_user> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Username, Password, LastLogin, IsLogin, IPAddress, MachineName, is_deleted, FullName, created, creator, edited, editor FROM tbl_user WHERE is_deleted <> 1 ";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_user>(context, new tbl_user());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_user]
        /// </summary>        
        public static List<tbl_user> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_user] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_user].[Username] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_user].*
                FROM    [tbl_user]
                WHERE   is_deleted <> 1 
            )

            SELECT      [Paging_tbl_user].*
            FROM        [Paging_tbl_user]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_user>(context, new tbl_user());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_user] by Primary Key
        /// </summary>        
        public static tbl_user GetByPK(string Username)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT Username, Password, LastLogin, IsLogin, IPAddress, MachineName, is_deleted, FullName, created, creator, edited, editor FROM tbl_user
            WHERE [Username]  = @Username";
            context.AddParameter("@Username", Username);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_user>(context, new tbl_user()).FirstOrDefault();
        }

        #endregion

    }
}