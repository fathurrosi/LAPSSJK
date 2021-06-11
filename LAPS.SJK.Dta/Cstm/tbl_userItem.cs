using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using LAPS.SJK.Dta;
using LAPS.SJK.Dto.Cstm;

namespace LAPS.SJK.Dta
{
    public partial class tbl_userItem
    {
        public static tbl_user GetUser(string Username)
        {
            tbl_user user = null;
            IDBHelper context = new DBHelper();
            context.CommandText = @"	SELECT * from tbl_user WHERE Username = @Username ";
            context.CommandType = CommandType.Text;
            context.AddParameter("@Username", string.Format("{0}", Username));
            List<tbl_user> result = DBUtil.ExecuteMapper(context, new tbl_user());
            if (result.Count > 0)
            {
                user = result.FirstOrDefault();
                user.Roles = tbl_roleItem.GetByUsername(user.Username);
            }
            return user;
        }

        public static void UpdateLogin(string Username, string machine, string ipAddress)
        {
            IDBHelper context = new DBHelper();
            context.CommandText = @"UPDATE tbl_user
   SET LastLogin =  @LastLogin
      ,IsLogin = 1
      ,IPAddress = @IPAddress
      ,MachineName = @MachineName   
    
 WHERE  Username = @Username";
            context.CommandType = CommandType.Text;

            context.AddParameter("@LastLogin", DateTime.Now);
            context.AddParameter("@Username", Username);
            context.AddParameter("@MachineName", machine);
            context.AddParameter("@IPAddress", ipAddress);

            DBUtil.ExecuteNonQuery(context);
        }



        public static int Insert(string Username, string password, string hint, List<int> roles)
        {
            string Fullname = hint;
            int result = -1;
            try
            {

                IDBHelper context = new DBHelper();
                context.BeginTransaction();
                context.CommandText = @"
INSERT INTO tbl_user
           (Username, Fullname
           ,Password
          , IsActive)
     VALUES
           (@Username, @Fullname
           ,@Password
           ,1)
";
                context.CommandType = CommandType.Text;
                context.AddParameter("@Username", Username);
                context.AddParameter("@Fullname", Fullname);
                context.AddParameter("@Password", password);
                result = DBUtil.ExecuteNonQuery(context);
                if (result > 0)
                {
                    roles.ForEach(t =>
                    {
                        context.Clear();
                        context.AddParameter("Username", Username);
                        context.AddParameter("@RoleID", t);
                        context.CommandText = @"
INSERT INTO tbl_userRole
           (Username
           ,RoleID)
     VALUES
           (@Username
           ,@RoleID)
                        ";
                        context.CommandType = CommandType.Text;
                        DBUtil.ExecuteNonQuery(context);
                    });
                    context.CommitTransaction();
                }
            }
            catch (Exception)
            {
                result = -1;
            }

            return result;
        }

        //
        public static int Update(string Username, string password, string hint, List<int> roles)
        {
            string fullname = hint;
            int result = -1;
            try
            {
                IDBHelper context = new DBHelper();
                context.BeginTransaction();
                context.CommandText = @"

UPDATE tbl_user
           set Password =@Password
          , IsActive=1,  fullname =@fullname   
		  where Username=@Username

";
                context.CommandType = CommandType.Text;
                context.AddParameter("@Username", Username);
                context.AddParameter("@Password", password);
                context.AddParameter("@fullname", fullname);
                result = DBUtil.ExecuteNonQuery(context);
                if (result > 0)
                {
                    context.Clear();
                    context.AddParameter("Username", Username);
                    context.CommandText = @"                    
DELETE FROM tbl_userRole
      WHERE Username =@Username
";
                    context.CommandType = CommandType.Text;
                    DBUtil.ExecuteNonQuery(context);
                    roles.ForEach(t =>
                    {
                        context.Clear();
                        context.AddParameter("Username", Username);
                        context.AddParameter("@RoleID", t);
                        context.CommandText = @"
                        INSERT INTO tbl_userRole
           (Username
           ,RoleID)
     VALUES
           (@Username
           ,@RoleID)
                        ";
                        context.CommandType = CommandType.Text;
                        DBUtil.ExecuteNonQuery(context);
                    });
                    context.CommitTransaction();
                }
            }
            catch (Exception)
            {
                result = -1;
            }
            return result;
        }

        public static int UpdatePassword(string Username, string password)
        {
            IDBHelper context = new DBHelper();
            context.CommandText = @"
update tbl_user
           set Password =@Password
          , IsActive=1
		  where Username=@Username
";
            context.CommandType = CommandType.Text;
            context.AddParameter("@Username", Username);
            context.AddParameter("@Password", password);
            return DBUtil.ExecuteNonQuery(context);
        }

        //        public static int Delete(string Username)
        //        {
        //            IDBHelper context = new DBHelper();
        //            context.CommandText = @"
        //DELETE FROM tbl_user
        //      WHERE Username =@Username;

        //DELETE FROM tbl_userrole 
        //	WHERE
        //	Username = @Username;
        //";
        //            context.CommandType = CommandType.Text;
        //            context.AddParameter("@Username", Username);
        //            return DBUtil.ExecuteNonQuery(context);
        //        }

    }
}
