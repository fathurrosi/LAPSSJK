
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_combo_detail]
    /// </summary>    
    public partial class tbl_combo_detailItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_combo_detail]
        /// </summary>        
        public static tbl_combo_detail Insert(tbl_combo_detail obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_combo_detail]([name], [parent], [header], [sequence]) 
VALUES      (@name, @parent, @header, @sequence)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  name, parent, header, sequence, id
FROM    [tbl_combo_detail]
WHERE   [id]  = @_id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@parent", string.Format("{0}", obj.parent));
            context.AddParameter("@header", string.Format("{0}", obj.header));
            context.AddParameter("@sequence", obj.sequence);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_combo_detail>(context, new tbl_combo_detail()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_combo_detail]
        /// </summary>        
        public static tbl_combo_detail Update(tbl_combo_detail obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_combo_detail]
SET         [name] = @name,
            [parent] = @parent,
            [header] = @header,
            [sequence] = @sequence
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  name, parent, header, sequence, id 
FROM    [tbl_combo_detail]
WHERE   [id]  = @id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@parent", string.Format("{0}", obj.parent));
            context.AddParameter("@header", string.Format("{0}", obj.header));
            context.AddParameter("@sequence", obj.sequence);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_combo_detail>(context, new tbl_combo_detail()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_combo_detail]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_combo_detail 
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
        /// Get Total records from [tbl_combo_detail]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_combo_detail ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_combo_detail]
        /// </summary>        
        public static List<tbl_combo_detail> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT name, parent, header, sequence, id FROM tbl_combo_detail ";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_combo_detail>(context, new tbl_combo_detail());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_combo_detail]
        /// </summary>        
        public static List<tbl_combo_detail> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_combo_detail] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_combo_detail].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_combo_detail].*
                FROM    [tbl_combo_detail]
                
            )

            SELECT      [Paging_tbl_combo_detail].*
            FROM        [Paging_tbl_combo_detail]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_combo_detail>(context, new tbl_combo_detail());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_combo_detail] by Primary Key
        /// </summary>        
        public static tbl_combo_detail GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT name, parent, header, sequence, id FROM tbl_combo_detail
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_combo_detail>(context, new tbl_combo_detail()).FirstOrDefault();
        }

        #endregion

    }
}