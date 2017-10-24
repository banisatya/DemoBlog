using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using DemoBlog.DataAccess.ViewModel;

namespace DemoBlog.WebUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        wcfUserService.UserServiceClient userProxy;
        public AccountController()
        {
            userProxy = new wcfUserService.UserServiceClient();
        }
                
        #region Login

        [AllowAnonymous]
        public ActionResult Login()
        {
            string returnUrl = null;
            if (TempData["ReturnURL"] != null)
                returnUrl = TempData["ReturnURL"].ToString();
            ViewBag.ReturnUrl = returnUrl ?? @Url.Action("Index", "Home");
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if (ModelState.IsValid)
            {
                model.Password = CommonFunctions.EncryptPassword(model.Password);
                var outModel = userProxy.IsValidUser(model);
                if (outModel.IsValidUser == true)
                {
                    Session["UserID"] = outModel.UserID;
                    Session["IsAdminUser"] = outModel.IsAdminUser;
                    SetLogin(model);
                    return RedirectToLocal(ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        public void SetLogin(LoginViewModel user)
        {
            FormsAuthentication.SetAuthCookie(user.UserName, false);
        }
        
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (!String.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion
                
        #region Register and LogOff

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (userProxy.IsUserNameExists(model.UserName))
            {
                ModelState.AddModelError("UserName", "User Name exists already. Please try with another one");
            }
            if (ModelState.IsValid)
            {
                model.Password = CommonFunctions.EncryptPassword(model.Password);
                var dbResult = userProxy.CreateUser(model);
                if (dbResult.IsSuccess)
                {
                    Session["UserID"] = dbResult.RecordID;
                    Session["IsAdminUser"] = dbResult.IsTrueOption1;
                    SetLogin(new LoginViewModel { UserName = model.UserName });
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //AddErrors(result);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Manage User

        [AllowAnonymous]
        public ActionResult ManageUser()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult _UserList()
        {
            var lst = userProxy.UserListSelectAll().ToList();
            return PartialView(lst);
        }

        [AllowAnonymous]
        public JsonResult _DeleteUser(int id)
        {
            dbActionResult dbResult = userProxy.DeleteUser(id);
            return Json(new { IsSuccess = dbResult.IsSuccess }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult _CreateAdminUser(int id)
        {
            dbActionResult dbResult = userProxy.CreateAdminUser(id);
            return Json(new { IsSuccess = dbResult.IsSuccess }, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}