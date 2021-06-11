
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tb_contact_us]
    /// </summary>    
    public partial class tb_contact_usItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tb_contact_us]
        /// </summary>        
        public static tb_contact_us Insert(tb_contact_us obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tb_contact_us]([business_day], [business_time], [address], [phone], [email]) 
VALUES      (@business_day, @business_time, @address, @phone, @email)

SET @Err = @@Error

DECLARE @_contact_id Int
SELECT @_contact_id = SCOPE_IDENTITY()

SELECT  contact_id, business_day, business_time, address, phone, email
FROM    [tb_contact_us]
WHERE   [contact_id]  = @_contact_id";
            context.AddParameter("@business_day", string.Format("{0}", obj.business_day));
            context.AddParameter("@business_time", string.Format("{0}", obj.business_time));
            context.AddParameter("@address", string.Format("{0}", obj.address));
            context.AddParameter("@phone", string.Format("{0}", obj.phone));
            context.AddParameter("@email", string.Format("{0}", obj.email));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tb_contact_us>(context, new tb_contact_us()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tb_contact_us]
        /// </summary>        
        public static tb_contact_us Update(tb_contact_us obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tb_contact_us]
SET         [business_day] = @business_day,
            [business_time] = @business_time,
            [address] = @address,
            [phone] = @phone,
            [email] = @email
WHERE       [contact_id]  = @contact_id

SET @Err = @@Error

SELECT  contact_id, business_day, business_time, address, phone, email 
FROM    [tb_contact_us]
WHERE   [contact_id]  = @contact_id";
            context.AddParameter("@business_day", string.Format("{0}", obj.business_day));
            context.AddParameter("@business_time", string.Format("{0}", obj.business_time));
            context.AddParameter("@address", string.Format("{0}", obj.address));
            context.AddParameter("@phone", string.Format("{0}", obj.phone));
            context.AddParameter("@email", string.Format("{0}", obj.email));
            context.AddParameter("@contact_id", obj.contact_id);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tb_contact_us>(context, new tb_contact_us()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tb_contact_us]
        /// </summary>        
        public static int Delete(Int32 contact_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tb_contact_us 
WHERE   [contact_id]  = @contact_id";
            context.AddParameter("@contact_id", contact_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tb_contact_us]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tb_contact_us";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tb_contact_us]
        /// </summary>        
        public static List<tb_contact_us> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT contact_id, business_day, business_time, address, phone, email FROM tb_contact_us";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tb_contact_us>(context, new tb_contact_us());
        }

        /// <summary>
        /// Get All records from TABLE [tb_contact_us]
        /// </summary>        
        public static List<tb_contact_us> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tb_contact_us] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tb_contact_us].[contact_id] DESC ) AS PAGING_ROW_NUMBER,
                        [tb_contact_us].*
                FROM    [tb_contact_us]
            )

            SELECT      [Paging_tb_contact_us].*
            FROM        [Paging_tb_contact_us]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tb_contact_us>(context, new tb_contact_us());
        }

        /// <summary>
        /// Get a single record of TABLE [tb_contact_us] by Primary Key
        /// </summary>        
        public static tb_contact_us GetByPK(Int32 contact_id)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT contact_id, business_day, business_time, address, phone, email FROM tb_contact_us
            WHERE [contact_id]  = @contact_id";
            context.AddParameter("@contact_id", contact_id);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tb_contact_us>(context, new tb_contact_us()).FirstOrDefault();
        }

        #endregion

    }
}