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

        public static Dto.tbl_user Insert(Dto.tbl_user obj, List<int> roles)
        {
            IDBHelper context = new DBHelper();
            Dto.tbl_user result = null;
            try
            {

                context.BeginTransaction();
                context.CommandText = @"

INSERT INTO [tbl_user]([Username], [Password], [LastLogin], [IsLogin], [IPAddress], [MachineName], [is_deleted], [FullName], [created], [creator]) 
VALUES      (@Username, @Password, @LastLogin, @IsLogin, @IPAddress, @MachineName, @is_deleted, @FullName, @created, @creator)


select * from tbl_user where Username =@Username
";
                context.CommandType = CommandType.Text;
                context.AddParameter("@Username", string.Format("{0}", obj.Username));
                context.AddParameter("@Password", string.Format("{0}", obj.Password));
                context.AddParameter("@LastLogin", obj.LastLogin);
                context.AddParameter("@IsLogin", obj.IsLogin);
                context.AddParameter("@IPAddress", string.Format("{0}", obj.IPAddress));
                context.AddParameter("@MachineName", string.Format("{0}", obj.MachineName));
                context.AddParameter("@is_deleted", obj.is_deleted);
                context.AddParameter("@FullName", string.Format("{0}", obj.FullName));
                context.AddParameter("@created", obj.created);
                context.AddParameter("@creator", string.Format("{0}", obj.creator));

                result = DBUtil.ExecuteMapper(context, new Dto.tbl_user()).FirstOrDefault();
                if (result != null)
                {
                    roles.ForEach(t =>
                    {
                        context.Clear();
                        context.AddParameter("Username", obj.Username);
                        context.AddParameter("@RoleID", t);
                        context.CommandText = @"
INSERT INTO tbl_user_role
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
            catch (Exception ex)
            {
                context.RollbackTransaction();
                result = null;
            }

            return result;
        }

        public static int Insert(string Username, string password, string hint, List<int> roles)
        {
            IDBHelper context = new DBHelper();
            string Fullname = hint;
            int result = -1;
            try
            {

                context.BeginTransaction();
                context.CommandText = @"
INSERT INTO tbl_user
           (Username, Fullname
           ,Password
          , is_deleted)
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
INSERT INTO tbl_user_role
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
                context.RollbackTransaction();
                result = -1;
            }

            return result;
        }

        public static Dto.tbl_user Update(Dto.tbl_user obj, List<int> roles)
        {


            IDBHelper context = new DBHelper();
            Dto.tbl_user result = null;
            try
            {
                context.BeginTransaction();
                context.CommandText = @"
UPDATE      [tbl_user] SET
            [FullName] = @FullName,
            [edited] = @edited,
            [editor] = @editor
WHERE       [Username]  = @Username

select * from tbl_user where Username =@Username
";
                context.CommandType = CommandType.Text;
                context.AddParameter("@FullName", string.Format("{0}", obj.FullName));
                context.AddParameter("@edited", obj.edited);
                context.AddParameter("@editor", string.Format("{0}", obj.editor));
                context.AddParameter("@Username", string.Format("{0}", obj.Username));

                result = DBUtil.ExecuteMapper(context, new Dto.tbl_user()).FirstOrDefault();
                if (result != null)
                {
                    context.Clear();
                    context.AddParameter("Username", obj.Username);
                    context.CommandText = @"                    
DELETE FROM tbl_user_role
      WHERE Username =@Username
";
                    context.CommandType = CommandType.Text;
                    DBUtil.ExecuteNonQuery(context);
                    roles.ForEach(t =>
                    {
                        context.Clear();
                        context.AddParameter("Username", obj.Username);
                        context.AddParameter("@RoleID", t);
                        context.CommandText = @"
                        INSERT INTO tbl_user_role
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
            catch (Exception ex)
            {
                context.RollbackTransaction();
                result = null;
            }
            return result;
        }
        public static int Update(string Username, string password, string hint, List<int> roles)
        {
            IDBHelper context = new DBHelper();
            string fullname = hint;
            int result = -1;
            try
            {
                context.BeginTransaction();
                context.CommandText = @"

UPDATE tbl_user
           set 
            Password =@Password
          , fullname =@fullname   
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
DELETE FROM tbl_user_role
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
                        INSERT INTO tbl_user_role
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
                context.RollbackTransaction();
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
          , is_deleted=1
		  where Username=@Username
";
            context.CommandType = CommandType.Text;
            context.AddParameter("@Username", Username);
            context.AddParameter("@Password", password);
            return DBUtil.ExecuteNonQuery(context);
        }   

    }
}
