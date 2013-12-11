using SJSUParking.Controllers.DataAccess;
using SJSUParking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SJSUParking.Controllers
{
    public class ManageParkingSlotsController : Controller
    {
        //
        // GET: /ManageParkingSlots/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public string GetParkingSlots(String garageName)
        {
            List<ParkingSlotModel> availableSlots = DAL.GetParkingSlots(garageName);
            var jsonSerialiser = new JavaScriptSerializer();
            return jsonSerialiser.Serialize(availableSlots);
        }

        [HttpPost]
        public void SaveParkingSlot(string selslotId, string type)
        {
            DAL.UpdateParkingSlot(selslotId, type);
        }
    }
}
