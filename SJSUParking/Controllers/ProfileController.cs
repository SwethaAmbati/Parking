using SJSUParking.Models;
using SJSUParking.Controllers.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJSUParking.Controllers
{
    public class ProfileController : Controller
    {
        //
        // GET: /Profile/

        public ActionResult Index()
        {
            UserModel mo = DAL.UserProfile(this.User.Identity.Name.ToString());
            return View(mo);
            
        }

    }
}
