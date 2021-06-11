
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_culture_info]
    /// </summary>    
    public partial class tbl_culture_infoItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_culture_info]
        /// </summary>        
        public static tbl_culture_info Insert(tbl_culture_info obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_culture_info]([culture], [spec_culture], [name]) 
VALUES      (@culture, @spec_culture, @name)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  culture, spec_culture, name, id
FROM    [tbl_culture_info]
WHERE   [id]  = @_id";
            context.AddParameter("@culture", string.Format("{0}", obj.culture));
            context.AddParameter("@spec_culture", string.Format("{0}", obj.spec_culture));
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_culture_info>(context, new tbl_culture_info()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_culture_info]
        /// </summary>        
        public static tbl_culture_info Update(tbl_culture_info obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_culture_info]
SET         [culture] = @culture,
            [spec_culture] = @spec_culture,
            [name] = @name
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  culture, spec_culture, name, id 
FROM    [tbl_culture_info]
WHERE   [id]  = @id";
            context.AddParameter("@culture", string.Format("{0}", obj.culture));
            context.AddParameter("@spec_culture", string.Format("{0}", obj.spec_culture));
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_culture_info>(context, new tbl_culture_info()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_culture_info]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_culture_info 
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
        /// Get Total records from [tbl_culture_info]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_culture_info";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_culture_info]
        /// </summary>        
        public static List<tbl_culture_info> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT culture, spec_culture, name, id FROM tbl_culture_info";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_culture_info>(context, new tbl_culture_info());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_culture_info]
        /// </summary>        
        public static List<tbl_culture_info> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_culture_info] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_culture_info].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_culture_info].*
                FROM    [tbl_culture_info]
            )

            SELECT      [Paging_tbl_culture_info].*
            FROM        [Paging_tbl_culture_info]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_culture_info>(context, new tbl_culture_info());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_culture_info] by Primary Key
        /// </summary>        
        public static tbl_culture_info GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT culture, spec_culture, name, id FROM tbl_culture_info
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_culture_info>(context, new tbl_culture_info()).FirstOrDefault();
        }

        #endregion

    }
}