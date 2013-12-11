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
        [HttpGet]
        public ActionResult EditInformation(int id)
        {
            UserModel editInfo = new UserModel();
            return View(editInfo);
        }

    }
}
