
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Setting]
    /// </summary>    
    public partial class tbl_SettingItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Setting]
        /// </summary>        
        public static tbl_Setting Insert(tbl_Setting obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Setting]([name], [value], [description]) 
VALUES      (@name, @value, @description)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, name, value, description
FROM    [tbl_Setting]
WHERE   [id]  = @_id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@value", string.Format("{0}", obj.value));
            context.AddParameter("@description", string.Format("{0}", obj.description));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Setting>(context, new tbl_Setting()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Setting]
        /// </summary>        
        public static tbl_Setting Update(tbl_Setting obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Setting]
SET         [name] = @name,
            [value] = @value,
            [description] = @description
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, name, value, description 
FROM    [tbl_Setting]
WHERE   [id]  = @id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@value", string.Format("{0}", obj.value));
            context.AddParameter("@description", string.Format("{0}", obj.description));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Setting>(context, new tbl_Setting()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Setting]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Setting 
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
        /// Get Total records from [tbl_Setting]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Setting";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Setting]
        /// </summary>        
        public static List<tbl_Setting> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, name, value, description FROM tbl_Setting";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Setting>(context, new tbl_Setting());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Setting]
        /// </summary>        
        public static List<tbl_Setting> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Setting] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Setting].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Setting].*
                FROM    [tbl_Setting]
            )

            SELECT      [Paging_tbl_Setting].*
            FROM        [Paging_tbl_Setting]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Setting>(context, new tbl_Setting());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Setting] by Primary Key
        /// </summary>        
        public static tbl_Setting GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, name, value, description FROM tbl_Setting
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Setting>(context, new tbl_Setting()).FirstOrDefault();
        }

        #endregion

    }
}