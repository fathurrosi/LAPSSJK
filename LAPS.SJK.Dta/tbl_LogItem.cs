
using System;
using System.Linq;
using System.Collections.Generic;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    /// <summary>
    /// Dta Class of TABLE [tbl_Log]
    /// </summary>    
    public partial class tbl_LogItem
    {
       
        #region Data Access

        /// <summary>
        /// Execute Insert to TABLE [tbl_Log]
        /// </summary>        
        public static tbl_Log Insert(tbl_Log obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF
DECLARE @Err int

INSERT INTO [tbl_Log]([LogDate], [IPAddress], [LogType], [LongMessage], [ShortMessage], [Username], [MechineName]) 
VALUES      (@LogDate, @IPAddress, @LogType, @LongMessage, @ShortMessage, @Username, @MechineName)

SET @Err = @@Error

DECLARE @_ID BigInt
SELECT @_ID = SCOPE_IDENTITY()

SELECT  LogDate, IPAddress, LogType, LongMessage, ShortMessage, Username, MechineName, ID
FROM    [tbl_Log]
WHERE   [ID]  = @_ID";
            context.AddParameter("@LogDate", obj.LogDate);
            context.AddParameter("@IPAddress", string.Format("{0}", obj.IPAddress));
            context.AddParameter("@LogType", string.Format("{0}", obj.LogType));
            context.AddParameter("@LongMessage", string.Format("{0}", obj.LongMessage));
            context.AddParameter("@ShortMessage", string.Format("{0}", obj.ShortMessage));
            context.AddParameter("@Username", string.Format("{0}", obj.Username));
            context.AddParameter("@MechineName", string.Format("{0}", obj.MechineName));
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Log>(context, new tbl_Log()).FirstOrDefault();
        }

        /// <summary>
        /// Execute Update to TABLE [tbl_Log]
        /// </summary>        
        public static tbl_Log Update(tbl_Log obj)
        {
             IDBHelper context = new DBHelper();
            string sqlQuery = @"
SET NOCOUNT OFF

DECLARE @Err int

UPDATE      [tbl_Log]
SET         [LogDate] = @LogDate,
            [IPAddress] = @IPAddress,
            [LogType] = @LogType,
            [LongMessage] = @LongMessage,
            [ShortMessage] = @ShortMessage,
            [Username] = @Username,
            [MechineName] = @MechineName
WHERE       [ID]  = @ID

SET @Err = @@Error

SELECT  LogDate, IPAddress, LogType, LongMessage, ShortMessage, Username, MechineName, ID 
FROM    [tbl_Log]
WHERE   [ID]  = @ID";
            context.AddParameter("@LogDate", obj.LogDate);
            context.AddParameter("@IPAddress", string.Format("{0}", obj.IPAddress));
            context.AddParameter("@LogType", string.Format("{0}", obj.LogType));
            context.AddParameter("@LongMessage", string.Format("{0}", obj.LongMessage));
            context.AddParameter("@ShortMessage", string.Format("{0}", obj.ShortMessage));
            context.AddParameter("@Username", string.Format("{0}", obj.Username));
            context.AddParameter("@MechineName", string.Format("{0}", obj.MechineName));
            context.AddParameter("@ID", obj.ID);            
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Log>(context, new tbl_Log()).FirstOrDefault(); 
        }

        /// <summary>
        /// Execute Delete to TABLE [tbl_Log]
        /// </summary>        
        public static int Delete(Int64 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery =@"DELETE FROM tbl_Log 
WHERE   [ID]  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteNonQuery(context);
        }
        public static int GetCount(int PageSize, int PageIndex)
        {
            return GetTotalRecord();
        }
        /// <summary>
        /// Get Total records from [tbl_Log]
        /// </summary>        
        public static int GetTotalRecord()
        {
            int result = -1;
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT Count(*) as Total FROM tbl_Log";
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            object obj = DBUtil.ExecuteScalar(context);
            if (obj != null)
                int.TryParse(obj.ToString(), out result);
            return result;
            
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Log]
        /// </summary>        
        public static List<tbl_Log> GetAll()
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = "SELECT LogDate, IPAddress, LogType, LongMessage, ShortMessage, Username, MechineName, ID FROM tbl_Log";
            context.CommandText = sqlQuery;
            context.CommandType =  System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Log>(context, new tbl_Log());
        }

        /// <summary>
        /// Get All records from TABLE [tbl_Log]
        /// </summary>        
        public static List<tbl_Log> GetPaging(int PageSize, int PageIndex)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"
            WITH [Paging_tbl_Log] AS
            (
                SELECT  ROW_NUMBER() OVER (ORDER BY [tbl_Log].[ID] DESC ) AS PAGING_ROW_NUMBER,
                        [tbl_Log].*
                FROM    [tbl_Log]
            )

            SELECT      [Paging_tbl_Log].*
            FROM        [Paging_tbl_Log]
            ORDER BY PAGING_ROW_NUMBER           
            OFFSET @PageIndex ROWS 
            FETCH Next @PageSize ROWS ONLY
";
        
            context.AddParameter("@PageIndex", PageIndex);
            context.AddParameter("@PageSize", PageSize);
            context.CommandType = System.Data.CommandType.Text;
            context.CommandText = sqlQuery;
            return DBUtil.ExecuteMapper<tbl_Log>(context, new tbl_Log());
        }

        /// <summary>
        /// Get a single record of TABLE [tbl_Log] by Primary Key
        /// </summary>        
        public static tbl_Log GetByPK(Int64 ID)
        {
            IDBHelper context = new DBHelper();
            string sqlQuery = @"SELECT LogDate, IPAddress, LogType, LongMessage, ShortMessage, Username, MechineName, ID FROM tbl_Log
            WHERE [ID]  = @ID";
            context.AddParameter("@ID", ID);
            context.CommandText = sqlQuery;
            context.CommandType = System.Data.CommandType.Text;
            return DBUtil.ExecuteMapper<tbl_Log>(context, new tbl_Log()).FirstOrDefault();
        }

        #endregion

    }
}