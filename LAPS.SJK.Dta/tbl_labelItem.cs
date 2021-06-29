
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_label]
    /// </summary>    
    public partial class tbl_labelItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_label]
        /// </summary>        
        public static tbl_label Insert(tbl_label obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_label]([c_flag], [name], [value]) 
VALUES      (@c_flag, @name, @value)

SET @Err = @@Error

SELECT  c_flag, name, value
FROM    [tbl_label]
WHERE   [name]  = @name
            AND [c_flag] = @c_flag";
            context.AddParameter("@c_flag", string.Format("{0}", obj.c_flag));
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@value", string.Format("{0}", obj.value));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_label>(context, new tbl_label()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_label]
        /// </summary>        
        public static tbl_label Update(tbl_label obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_label]
SET         [value] = @value
WHERE       [name]  = @name
            AND [c_flag] = @c_flag

SET @Err = @@Error

SELECT  c_flag, name, value 
FROM    [tbl_label]
WHERE   [name]  = @name
        AND [c_flag] = @c_flag";
            context.AddParameter("@value", string.Format("{0}", obj.value));
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@c_flag", string.Format("{0}", obj.c_flag));            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_label>(context, new tbl_label()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_label]
        /// </summary>        
        public static int Delete(string name, string c_flag)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_label 
WHERE   [name]  = @name
        AND [c_flag] = @c_flag";
            context.AddParameter("@name",  string.Format("{0}", name));
            context.AddParameter("@c_flag",  string.Format("{0}", c_flag));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_label]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_label ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_label]
        /// </summary>        
        public static List<tbl_label> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT c_flag, name, value FROM tbl_label ";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_label>(context, new tbl_label());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_label]
        /// </summary>        
        public static List<tbl_label> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_label] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_label].[name], [tbl_label].[c_flag] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_label].*
                FROM    [tbl_label]
                
            )

            SELECT      [Paging_tbl_label].*
            FROM        [Paging_tbl_label]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_label>(context, new tbl_label());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_label] by Primary Key
        /// </summary>        
        public static tbl_label GetByPK(string name, string c_flag)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT c_flag, name, value FROM tbl_label
            WHERE [name]  = @name, AND [c_flag] = @c_flag";
            context.AddParameter("@name", name);
            context.AddParameter("@c_flag", c_flag);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_label>(context, new tbl_label()).FirstOrDefault();
        }

        #endregion

    }
}