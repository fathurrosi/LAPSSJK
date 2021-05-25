using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace LAPS.SJK.Dto.Cstm
{
    public class privilege : IDataMapper<privilege>
    {

        public int MenuID { get; set; }

        public int RoleID { get; set; }

        public bool AllowCreate { get; set; }

        public bool AllowRead { get; set; }

        public bool AllowUpdate { get; set; }

        public bool AllowDelete { get; set; }

        public bool AllowPrint { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public privilege Map(System.Data.IDataReader reader)
        {
            privilege obj = new privilege();
            obj.Code = reader["Code"].ToString();
            obj.Name = reader["Name"].ToString();
            obj.Url = reader["Url"].ToString();
            obj.MenuID = (reader["ID"] is System.DBNull) ? 0 : Convert.ToInt32(reader["ID"]);

            return obj;
        }
    }
}
