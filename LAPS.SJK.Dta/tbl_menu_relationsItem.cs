
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_menu_relations]
    /// </summary>    
    public partial class tbl_menu_relationsItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_menu_relations]
        /// </summary>        
        public static tbl_menu_relations Insert(tbl_menu_relations obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_menu_relations]([menu_id], [relations_type], [content_id]) 
VALUES      (@menu_id, @relations_type, @content_id)

SET @Err = @@Error

DECLARE @_menu_relations_id Int
SELECT @_menu_relations_id = SCOPE_IDENTITY()

SELECT  menu_relations_id, menu_id, relations_type, content_id
FROM    [tbl_menu_relations]
WHERE   [menu_relations_id]  = @_menu_relations_id";
            context.AddParameter("@menu_id", obj.menu_id);
            context.AddParameter("@relations_type", string.Format("{0}", obj.relations_type));
            context.AddParameter("@content_id", obj.content_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_menu_relations>(context, new tbl_menu_relations()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_menu_relations]
        /// </summary>        
        public static tbl_menu_relations Update(tbl_menu_relations obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_menu_relations]
SET         [menu_id] = @menu_id,
            [relations_type] = @relations_type,
            [content_id] = @content_id
WHERE       [menu_relations_id]  = @menu_relations_id

SET @Err = @@Error

SELECT  menu_relations_id, menu_id, relations_type, content_id 
FROM    [tbl_menu_relations]
WHERE   [menu_relations_id]  = @menu_relations_id";
            context.AddParameter("@menu_id", obj.menu_id);
            context.AddParameter("@relations_type", string.Format("{0}", obj.relations_type));
            context.AddParameter("@content_id", obj.content_id);
            context.AddParameter("@menu_relations_id", obj.menu_relations_id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_menu_relations>(context, new tbl_menu_relations()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_menu_relations]
        /// </summary>        
        public static int Delete(Int32 menu_relations_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_menu_relations 
WHERE   [menu_relations_id]  = @menu_relations_id";
            context.AddParameter("@menu_relations_id", menu_relations_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_menu_relations]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_menu_relations";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_menu_relations]
        /// </summary>        
        public static List<tbl_menu_relations> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT menu_relations_id, menu_id, relations_type, content_id FROM tbl_menu_relations";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_menu_relations>(context, new tbl_menu_relations());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_menu_relations]
        /// </summary>        
        public static List<tbl_menu_relations> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_menu_relations] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_menu_relations].[menu_relations_id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_menu_relations].*
                FROM    [tbl_menu_relations]
            )

            SELECT      [Paging_tbl_menu_relations].*
            FROM        [Paging_tbl_menu_relations]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_menu_relations>(context, new tbl_menu_relations());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_menu_relations] by Primary Key
        /// </summary>        
        public static tbl_menu_relations GetByPK(Int32 menu_relations_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT menu_relations_id, menu_id, relations_type, content_id FROM tbl_menu_relations
            WHERE [menu_relations_id]  = @menu_relations_id";
            context.AddParameter("@menu_relations_id", menu_relations_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_menu_relations>(context, new tbl_menu_relations()).FirstOrDefault();
        }

        #endregion

    }
}