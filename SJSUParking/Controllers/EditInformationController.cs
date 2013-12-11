using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJSUParking.Models;
using SJSUParking.Controllers.DataAccess;

namespace SJSUParking.Controllers
{
    public class EditInformationController : Controller
    {
        //
        // GET: /EditInformation/

        public ActionResult Index()
        {
            UserModel editinfo = DAL.EditProfile(this.User.Identity.Name.ToString());
            return View(editinfo);     
            
        }

        [HttpPost]
        public ActionResult Index(UserModel user)
        {
            if (!ModelState.IsValid)
            {
                DAL.SaveProfile(user, this.User.Identity.Name.ToString());
                return RedirectToAction("Index", "Profile");
          }
            return View();
        }

    }
}
