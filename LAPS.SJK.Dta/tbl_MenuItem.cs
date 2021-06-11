
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_menu]
    /// </summary>    
    public partial class tbl_menuItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_menu]
        /// </summary>        
        public static tbl_menu Insert(tbl_menu obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_menu]([menu_name], [on_lock], [parentid], [orderid], [url]) 
VALUES      (@menu_name, @on_lock, @parentid, @orderid, @url)

SET @Err = @@Error

DECLARE @_menu_id Int
SELECT @_menu_id = SCOPE_IDENTITY()

SELECT  menu_id, menu_name, on_lock, parentid, orderid, url
FROM    [tbl_menu]
WHERE   [menu_id]  = @_menu_id";
            context.AddParameter("@menu_name", string.Format("{0}", obj.menu_name));
            context.AddParameter("@on_lock", obj.on_lock);
            context.AddParameter("@parentid", obj.parentid);
            context.AddParameter("@orderid", obj.orderid);
            context.AddParameter("@url", string.Format("{0}", obj.url));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_menu>(context, new tbl_menu()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_menu]
        /// </summary>        
        public static tbl_menu Update(tbl_menu obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_menu]
SET         [menu_name] = @menu_name,
            [on_lock] = @on_lock,
            [parentid] = @parentid,
            [orderid] = @orderid,
            [url] = @url
WHERE       [menu_id]  = @menu_id

SET @Err = @@Error

SELECT  menu_id, menu_name, on_lock, parentid, orderid, url 
FROM    [tbl_menu]
WHERE   [menu_id]  = @menu_id";
            context.AddParameter("@menu_name", string.Format("{0}", obj.menu_name));
            context.AddParameter("@on_lock", obj.on_lock);
            context.AddParameter("@parentid", obj.parentid);
            context.AddParameter("@orderid", obj.orderid);
            context.AddParameter("@url", string.Format("{0}", obj.url));
            context.AddParameter("@menu_id", obj.menu_id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_menu>(context, new tbl_menu()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_menu]
        /// </summary>        
        public static int Delete(Int32 menu_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_menu 
WHERE   [menu_id]  = @menu_id";
            context.AddParameter("@menu_id", menu_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_menu]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_menu";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_menu]
        /// </summary>        
        public static List<tbl_menu> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT menu_id, menu_name, on_lock, parentid, orderid, url FROM tbl_menu";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_menu>(context, new tbl_menu());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_menu]
        /// </summary>        
        public static List<tbl_menu> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_menu] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_menu].[menu_id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_menu].*
                FROM    [tbl_menu]
            )

            SELECT      [Paging_tbl_menu].*
            FROM        [Paging_tbl_menu]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_menu>(context, new tbl_menu());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_menu] by Primary Key
        /// </summary>        
        public static tbl_menu GetByPK(Int32 menu_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT menu_id, menu_name, on_lock, parentid, orderid, url FROM tbl_menu
            WHERE [menu_id]  = @menu_id";
            context.AddParameter("@menu_id", menu_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_menu>(context, new tbl_menu()).FirstOrDefault();
        }

        #endregion

    }
}