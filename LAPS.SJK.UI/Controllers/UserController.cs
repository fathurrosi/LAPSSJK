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
                registerUser.IsActive = 1;
                registerUser.LastLogin = DateTime.Now;
                
                tbl_userItem.Insert(registerUser);

                return RedirectToAction("Login");

            }
            return View();
        }

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Register(RegisterViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //        var result = await UserManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

        //            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
        //            // Send an email with this link
        //            // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
        //            // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
        //            // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

        //            return RedirectToAction("Index", "Home");
        //        }
        //        AddErrors(result);
        //    }

        //    // If we got this far, something failed, redisplay form
        //    return View(model);
        //}

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        //public ActionResult Logout()
        //{
        //    //userService.LoggedOut(Utilities.GetCurrentUsername(), Utilities.GetIPAddress());
        //    Session.Abandon();
        //    Session.Clear();
        //    Session.RemoveAll();

        //    return RedirectToAction("Index", "Home");
        //}
    }
}
