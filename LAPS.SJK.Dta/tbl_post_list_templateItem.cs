
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_post_list_template]
    /// </summary>    
    public partial class tbl_post_list_templateItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_post_list_template]
        /// </summary>        
        public static tbl_post_list_template Insert(tbl_post_list_template obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_post_list_template]([template_name], [remark], [created], [creator], [is_deleted], [id_post_detail]) 
VALUES      (@template_name, @remark, @created, @creator, @is_deleted, @id_post_detail)

SET @Err = @@Error

DECLARE @_id Int
SELECT @_id = SCOPE_IDENTITY()

SELECT  id, template_name, remark, created, creator, is_deleted, id_post_detail
FROM    [tbl_post_list_template]
WHERE   [id]  = @_id";
            context.AddParameter("@template_name", string.Format("{0}", obj.template_name));
            context.AddParameter("@remark", string.Format("{0}", obj.remark));
            context.AddParameter("@created", obj.created);
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@is_deleted", obj.is_deleted);
            context.AddParameter("@id_post_detail", obj.id_post_detail);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_list_template>(context, new tbl_post_list_template()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_post_list_template]
        /// </summary>        
        public static tbl_post_list_template Update(tbl_post_list_template obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_post_list_template]
SET         [template_name] = @template_name,
            [remark] = @remark,
            [creator] = @creator,
            [is_deleted] = @is_deleted,
            [id_post_detail] = @id_post_detail
WHERE       [id]  = @id

SET @Err = @@Error

SELECT  id, template_name, remark, created, creator, is_deleted, id_post_detail 
FROM    [tbl_post_list_template]
WHERE   [id]  = @id";
            context.AddParameter("@template_name", string.Format("{0}", obj.template_name));
            context.AddParameter("@remark", string.Format("{0}", obj.remark));
            context.AddParameter("@creator", string.Format("{0}", obj.creator));
            context.AddParameter("@is_deleted", obj.is_deleted);
            context.AddParameter("@id_post_detail", obj.id_post_detail);
            context.AddParameter("@id", obj.id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_list_template>(context, new tbl_post_list_template()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_post_list_template]
        /// </summary>        
        public static int Delete(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"Update tbl_post_list_template Set is_deleted = 1 
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
        /// Get Total records from [tbl_post_list_template]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_post_list_template WHERE is_deleted <> 1 ";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_post_list_template]
        /// </summary>        
        public static List<tbl_post_list_template> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT id, template_name, remark, created, creator, is_deleted, id_post_detail FROM tbl_post_list_template WHERE is_deleted <> 1 ";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_list_template>(context, new tbl_post_list_template());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_post_list_template]
        /// </summary>        
        public static List<tbl_post_list_template> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_post_list_template] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_post_list_template].[id] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_post_list_template].*
                FROM    [tbl_post_list_template]
                WHERE   is_deleted <> 1 
            )

            SELECT      [Paging_tbl_post_list_template].*
            FROM        [Paging_tbl_post_list_template]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_post_list_template>(context, new tbl_post_list_template());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_post_list_template] by Primary Key
        /// </summary>        
        public static tbl_post_list_template GetByPK(Int32 id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT id, template_name, remark, created, creator, is_deleted, id_post_detail FROM tbl_post_list_template
            WHERE [id]  = @id";
            context.AddParameter("@id", id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_post_list_template>(context, new tbl_post_list_template()).FirstOrDefault();
        }

        #endregion

    }
}