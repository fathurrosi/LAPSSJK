using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using LAPS.SJK.Dto;

namespace LAPS.SJK.Dta
{
    public partial class tbl_roleItem
    {

        public static List<tbl_role> GetByUsername(string Username)
        {
            List<tbl_role> results = new List<tbl_role>();
            IDBHelper context = new DBHelper();
            context.CommandText = @" 

select r.* from tbl_user_Role u
inner join tbl_role r on u.RoleID = r.id
where u.Username=@Username
";
            context.CommandType = CommandType.Text;
            context.AddParameter("@Username", string.Format("{0}", Username));
            results = DBUtil.ExecuteMapper(context, new tbl_role());

            return results;
        }
    }
}
