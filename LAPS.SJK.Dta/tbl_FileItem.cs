
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_File]
    /// </summary>    
    public partial class tbl_FileItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_File]
        /// </summary>        
        public static tbl_File Insert(tbl_File obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_File]([file_id], [ref_name], [ref_id], [file_type], [file_path], [file_name], [file_ext], [file_blob], [created], [created_by]) 
VALUES      (@file_id, @ref_name, @ref_id, @file_type, @file_path, @file_name, @file_ext, @file_blob, @created, @created_by)

SET @Err = @@Error

SELECT  file_id, ref_name, ref_id, file_type, file_path, file_name, file_ext, file_blob, created, created_by
FROM    [tbl_File]
WHERE   [file_id]  = @file_id";
            context.AddParameter("@file_id", string.Format("{0}", obj.file_id));
            context.AddParameter("@ref_name", string.Format("{0}", obj.ref_name));
            context.AddParameter("@ref_id", string.Format("{0}", obj.ref_id));
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_path", string.Format("{0}", obj.file_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@created", obj.created);
            context.AddParameter("@created_by", string.Format("{0}", obj.created_by));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_File>(context, new tbl_File()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_File]
        /// </summary>        
        public static tbl_File Update(tbl_File obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_File]
SET         [ref_name] = @ref_name,
            [ref_id] = @ref_id,
            [file_type] = @file_type,
            [file_path] = @file_path,
            [file_name] = @file_name,
            [file_ext] = @file_ext,
            [file_blob] = @file_blob
WHERE       [file_id]  = @file_id

SET @Err = @@Error

SELECT  file_id, ref_name, ref_id, file_type, file_path, file_name, file_ext, file_blob, created, created_by 
FROM    [tbl_File]
WHERE   [file_id]  = @file_id";
            context.AddParameter("@ref_name", string.Format("{0}", obj.ref_name));
            context.AddParameter("@ref_id", string.Format("{0}", obj.ref_id));
            context.AddParameter("@file_type", string.Format("{0}", obj.file_type));
            context.AddParameter("@file_path", string.Format("{0}", obj.file_path));
            context.AddParameter("@file_name", string.Format("{0}", obj.file_name));
            context.AddParameter("@file_ext", string.Format("{0}", obj.file_ext));
            context.AddParameter("@file_blob", obj.file_blob, System.Data.DbType.Binary);
            context.AddParameter("@file_id", string.Format("{0}", obj.file_id));            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_File>(context, new tbl_File()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_File]
        /// </summary>        
        public static int Delete(string file_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_File 
WHERE   [file_id]  = @file_id";
            context.AddParameter("@file_id",  string.Format("{0}", file_id));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_File]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_File";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_File]
        /// </summary>        
        public static List<tbl_File> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT file_id, ref_name, ref_id, file_type, file_path, file_name, file_ext, file_blob, created, created_by FROM tbl_File";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_File>(context, new tbl_File());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_File]
        /// </summary>        
        public static List<tbl_File> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_File] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_File].[file_id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_File].*
                FROM    [tbl_File]
            )

            SELECT      [Paging_tbl_File].*
            FROM        [Paging_tbl_File]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_File>(context, new tbl_File());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_File] by Primary Key
        /// </summary>        
        public static tbl_File GetByPK(string file_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT file_id, ref_name, ref_id, file_type, file_path, file_name, file_ext, file_blob, created, created_by FROM tbl_File
            WHERE [file_id]  = @file_id";
            context.AddParameter("@file_id", file_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_File>(context, new tbl_File()).FirstOrDefault();
        }

        #endregion

    }
}