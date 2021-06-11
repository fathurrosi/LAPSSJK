using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{


    public partial class tbl_fileItem
    {
        public static tbl_file GetByReff(string ReferenceTable, string ReferenceID)
        {
            IDBHelper context = new DBHelper();
            context.CommandText = @"	
            SELECT top 1 *  FROM [tbl_file]
            WHERE [ref_name] =@ReferenceTable and [ref_id] =@ReferenceID

            ";
            context.CommandType = System.Data.CommandType.Text;
            context.AddParameter("@ReferenceTable", ReferenceTable);
            context.AddParameter("@ReferenceID", ReferenceID);
            return DBUtil.ExecuteMapper(context, new tbl_file()).FirstOrDefault();
            //return result.FirstOrDefault();

        }

    }
}
