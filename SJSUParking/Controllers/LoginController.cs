using SJSUParking.Controllers.DataAccess;
using SJSUParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SJSUParking.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                //if (loginModel.Username == "ked" && loginModel.Password == "admin123") // DB Call for UserName and Password
                if (DAL.UserIsValid(loginModel).authenticated)
                {
                    FormsAuthentication.SetAuthCookie(loginModel.SJSUId, false);// If it is set to false, the cookie is destroyed after user closes the browser
                    Session["SJSUID"] = loginModel.SJSUId;
                    Session["TYPE"] = loginModel.Type;
                    return RedirectToAction("index", "home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");//If authentcation fails
                }
              
            }
            return View();
        }

    }
}
