
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_m_content_type]
    /// </summary>    
    public partial class tbl_m_content_typeItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_m_content_type]
        /// </summary>        
        public static tbl_m_content_type Insert(tbl_m_content_type obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_m_content_type]([type_name], [type_description]) 
VALUES      (@type_name, @type_description)

SET @Err = @@Error

SELECT  type_name, type_description
FROM    [tbl_m_content_type]
WHERE   [type_name]  = @type_name";
            context.AddParameter("@type_name", string.Format("{0}", obj.type_name));
            context.AddParameter("@type_description", string.Format("{0}", obj.type_description));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_m_content_type>(context, new tbl_m_content_type()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_m_content_type]
        /// </summary>        
        public static tbl_m_content_type Update(tbl_m_content_type obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_m_content_type]
SET         [type_description] = @type_description
WHERE       [type_name]  = @type_name

SET @Err = @@Error

SELECT  type_name, type_description 
FROM    [tbl_m_content_type]
WHERE   [type_name]  = @type_name";
            context.AddParameter("@type_description", string.Format("{0}", obj.type_description));
            context.AddParameter("@type_name", string.Format("{0}", obj.type_name));            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_m_content_type>(context, new tbl_m_content_type()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_m_content_type]
        /// </summary>        
        public static int Delete(string type_name)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_m_content_type 
WHERE   [type_name]  = @type_name";
            context.AddParameter("@type_name",  string.Format("{0}", type_name));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_m_content_type]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_m_content_type ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_m_content_type]
        /// </summary>        
        public static List<tbl_m_content_type> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT type_name, type_description FROM tbl_m_content_type ";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_m_content_type>(context, new tbl_m_content_type());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_m_content_type]
        /// </summary>        
        public static List<tbl_m_content_type> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_m_content_type] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_m_content_type].[type_name] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_m_content_type].*
                FROM    [tbl_m_content_type]
                
            )

            SELECT      [Paging_tbl_m_content_type].*
            FROM        [Paging_tbl_m_content_type]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_m_content_type>(context, new tbl_m_content_type());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_m_content_type] by Primary Key
        /// </summary>        
        public static tbl_m_content_type GetByPK(string type_name)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT type_name, type_description FROM tbl_m_content_type
            WHERE [type_name]  = @type_name";
            context.AddParameter("@type_name", type_name);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_m_content_type>(context, new tbl_m_content_type()).FirstOrDefault();
        }

        #endregion

    }
}