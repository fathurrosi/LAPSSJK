
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Combo_Detail]
    /// </summary>    
    public partial class tbl_Combo_DetailItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Combo_Detail]
        /// </summary>        
        public static tbl_Combo_Detail Insert(tbl_Combo_Detail obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Combo_Detail]([name], [parent], [header], [sequence]) 
VALUES      (@name, @parent, @header, @sequence)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  name, parent, header, sequence, id
FROM    [tbl_Combo_Detail]
WHERE   [id]  = @_id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@parent", string.Format("{0}", obj.parent));
            context.AddParameter("@header", string.Format("{0}", obj.header));
            context.AddParameter("@sequence", obj.sequence);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Combo_Detail>(context, new tbl_Combo_Detail()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Combo_Detail]
        /// </summary>        
        public static tbl_Combo_Detail Update(tbl_Combo_Detail obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Combo_Detail]
SET         [name] = @name,
            [parent] = @parent,
            [header] = @header,
            [sequence] = @sequence
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  name, parent, header, sequence, id 
FROM    [tbl_Combo_Detail]
WHERE   [id]  = @id";
            context.AddParameter("@name", string.Format("{0}", obj.name));
            context.AddParameter("@parent", string.Format("{0}", obj.parent));
            context.AddParameter("@header", string.Format("{0}", obj.header));
            context.AddParameter("@sequence", obj.sequence);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Combo_Detail>(context, new tbl_Combo_Detail()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Combo_Detail]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Combo_Detail 
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
        /// Get Total records from [tbl_Combo_Detail]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Combo_Detail";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Combo_Detail]
        /// </summary>        
        public static List<tbl_Combo_Detail> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT name, parent, header, sequence, id FROM tbl_Combo_Detail";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Combo_Detail>(context, new tbl_Combo_Detail());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Combo_Detail]
        /// </summary>        
        public static List<tbl_Combo_Detail> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Combo_Detail] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Combo_Detail].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Combo_Detail].*
                FROM    [tbl_Combo_Detail]
            )

            SELECT      [Paging_tbl_Combo_Detail].*
            FROM        [Paging_tbl_Combo_Detail]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Combo_Detail>(context, new tbl_Combo_Detail());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Combo_Detail] by Primary Key
        /// </summary>        
        public static tbl_Combo_Detail GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT name, parent, header, sequence, id FROM tbl_Combo_Detail
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Combo_Detail>(context, new tbl_Combo_Detail()).FirstOrDefault();
        }

        #endregion

    }
}