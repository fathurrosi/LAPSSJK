using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LAPS.SJK.Dto.Cstm;
using LAPS.SJK.Dta;
using LAPS.SJK.Logic;
using LAPS.SJK.UI.Models;
using LAPS.SJK.Logic.Enum;

namespace LAPS.SJK.UI.Controllers
{
    public class UserController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel user)
        {
            if (ModelState.IsValid)
            {

                string usernname = user.Username;
                string password = Security.MD5Hash(user.Password.Trim());
                #region Login

                Log.Info(string.Format("User :{0}-{1} try to log in", usernname, password));

                Dto.Cstm.tbl_user Item = tbl_userItem.GetUser(usernname);
                if (Item != null && Item.Password == password &&
                    Item.Roles.Where(t => string.Format("{0}", t.Name).ToLower() == string.Format("{0}", UserType.User).ToLower()).Count() > 0)
                {
                    tbl_userItem.UpdateLogin(user.Username, "", "");
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index", "Home");
                }

                #endregion
            }
            ModelState.AddModelError("", "invalid Username or Password");
            return View();
        }


        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserModel registerUser)
        {
            if (ModelState.IsValid)
            {
                registerUser.IsLogin = 0;
                registerUser.is_deleted = 1;
                registerUser.LastLogin = DateTime.Now;

                tbl_userItem.Insert(registerUser);

                return RedirectToAction("Login");

            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        // GET: Admin/User
        public ActionResult Index()
        {
            List<UserModel> results = new List<UserModel>();
            List<Dto.tbl_user> list = tbl_userItem.GetAll();
            list.ForEach(t => { results.Add(new UserModel(t)); });
            return View(results);
        }


        // GET: user/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: user/Create
        [HttpPost]
        public ActionResult Add(UserModel model)
        {
            try
            {
                Dto.tbl_user result = null;
                // TODO: Add insert logic here
                Dto.tbl_user item = new Dto.tbl_user();

                item.Username = model.Username;
                item.Password = Security.MD5Hash("admin");
                item.LastLogin = DateTime.Now;
                item.IsLogin = 0; ;
                item.IPAddress = "";
                item.MachineName = "";
                item.is_deleted = 0;
                item.FullName = model.FullName;
                item.creator = Utilities.Username;
                item.created = DateTime.Now;

                result = tbl_userItem.GetByPK(model.Username);
                if (result != null)
                {
                    ModelState.AddModelError("", string.Format("{0} sudah ada.", model.Username));
                    return View();
                }

                result = tbl_userItem.Insert(item);
                if (result == null)
                {
                    ModelState.AddModelError("", "Ups, Data tidak dapat tersimpan!");
                    return View();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: user/Edit/5
        public ActionResult Edit(string id)
        {
            Dto.tbl_user item = tbl_userItem.GetByPK(id);
            return View(new UserModel(item));
        }

        // POST: user/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, UserModel model)
        {
            try
            {
                Dto.tbl_user result = null;
                // TODO: Add update logic here
                Dto.tbl_user item = tbl_userItem.GetByPK(id);

                if (item != null)
                {
                    item.Username = model.Username;
                    item.Password = model.Password;
                    item.FullName = model.FullName;
                    item.editor = Utilities.Username;
                    item.edited = DateTime.Now;
                    result = tbl_userItem.Update(item);
                    //update
                }
                else
                {
                    item = new Dto.tbl_user();
                    item.Username = "Admin";
                    item.Password = Security.MD5Hash("admin");
                    item.LastLogin = DateTime.Now;
                    item.IsLogin = 0; ;
                    item.IPAddress = "";
                    item.MachineName = "";
                    item.is_deleted = 0;
                    item.FullName = model.FullName;
                    item.creator = Utilities.Username;
                    item.created = DateTime.Now;
                    result = tbl_userItem.Insert(item);
                }

                if (result == null)
                {
                    ModelState.AddModelError("", "Ups, Data tidak dapat tersimpan!");
                    return View();
                }


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: user/Delete/5
        public ActionResult Delete(string id)
        {
            // TODO: Add update logic here
            Dto.tbl_user item = tbl_userItem.GetByPK(id);
            int result = tbl_userItem.Delete(id);

            if (result > 0)
            {
                ModelState.AddModelError("", "Ups, Data tidak dapat tersimpan!");
                return View();
            }
            return RedirectToAction("Index");
            //return View();
        }
    }
}
