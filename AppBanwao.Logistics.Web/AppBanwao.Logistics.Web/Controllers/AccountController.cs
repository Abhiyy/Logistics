using AppBanwao.Logistics.Web.Helpers;
using AppBanwao.Logistics.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AppBanwao.Logistics.Web.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        UserHelper _userHelper = null;
        
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _userHelper = new UserHelper(model.UserName, model.Password);
                    var user = _userHelper.GetUser();
                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, model.isRemember);
                        

                        return RedirectToAction("Index", "Admin");
                    }
                }
                catch (Exception ex)
                {

                }
            }
            else {
                return View(model);
            }
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
