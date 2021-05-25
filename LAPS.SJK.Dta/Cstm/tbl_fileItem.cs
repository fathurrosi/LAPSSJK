using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{


    public partial class tbl_FileItem
    {
        public static tbl_File GetByReff(string ReferenceTable, string ReferenceID)
        {
            IDBHelper context = new DBHelper();
            context.CommandText = @"	
            SELECT top 1 *  FROM [tbl_File]
            WHERE [ref_name] =@ReferenceTable and [ref_id] =@ReferenceID

            ";
            context.CommandType = System.Data.CommandType.Text;
            context.AddParameter("@ReferenceTable", ReferenceTable);
            context.AddParameter("@ReferenceID", ReferenceID);
            return DBUtil.ExecuteMapper(context, new tbl_File()).FirstOrDefault();
            //return result.FirstOrDefault();

        }

    }
}
