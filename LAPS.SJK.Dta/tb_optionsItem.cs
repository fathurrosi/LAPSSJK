
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tb_options]
    /// </summary>    
    public partial class tb_optionsItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tb_options]
        /// </summary>        
        public static tb_options Insert(tb_options obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tb_options]([option_name], [option_value], [autoload]) 
VALUES      (@option_name, @option_value, @autoload)

SET @Err = @@Error

DECLARE @_option_id Int
SELECT @_option_id = SCOPE_IDENTITY()

SELECT  option_id, option_name, option_value, autoload
FROM    [tb_options]
WHERE   [option_id]  = @_option_id";
            context.AddParameter("@option_name", string.Format("{0}", obj.option_name));
            context.AddParameter("@option_value", string.Format("{0}", obj.option_value));
            context.AddParameter("@autoload", string.Format("{0}", obj.autoload));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tb_options>(context, new tb_options()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tb_options]
        /// </summary>        
        public static tb_options Update(tb_options obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tb_options]
SET         [option_name] = @option_name,
            [option_value] = @option_value,
            [autoload] = @autoload
WHERE       [option_id]  = @option_id

SET @Err = @@Error

SELECT  option_id, option_name, option_value, autoload 
FROM    [tb_options]
WHERE   [option_id]  = @option_id";
            context.AddParameter("@option_name", string.Format("{0}", obj.option_name));
            context.AddParameter("@option_value", string.Format("{0}", obj.option_value));
            context.AddParameter("@autoload", string.Format("{0}", obj.autoload));
            context.AddParameter("@option_id", obj.option_id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tb_options>(context, new tb_options()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tb_options]
        /// </summary>        
        public static int Delete(Int32 option_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tb_options 
WHERE   [option_id]  = @option_id";
            context.AddParameter("@option_id", option_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tb_options]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tb_options";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tb_options]
        /// </summary>        
        public static List<tb_options> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT option_id, option_name, option_value, autoload FROM tb_options";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tb_options>(context, new tb_options());
        }

        /// <summary>
        /// Get All records from TABLE [tb_options]
        /// </summary>        
        public static List<tb_options> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tb_options] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tb_options].[option_id] DESC ) AS PAGING_ROW_NUMBER,
                        [tb_options].*
                FROM    [tb_options]
            )

            SELECT      [Paging_tb_options].*
            FROM        [Paging_tb_options]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tb_options>(context, new tb_options());
        }

        /// <summary>
        /// Get a single record of TABLE [tb_options] by Primary Key
        /// </summary>        
        public static tb_options GetByPK(Int32 option_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT option_id, option_name, option_value, autoload FROM tb_options
            WHERE [option_id]  = @option_id";
            context.AddParameter("@option_id", option_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tb_options>(context, new tb_options()).FirstOrDefault();
        }

        #endregion

    }
}