using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SJSUParking.Models;
using System.Web.Script.Serialization;
using SJSUParking.Controllers.DataAccess;


namespace SJSUParking.Controllers
{
    public class CheckParkingAvailabilityController : Controller
    {
        //
        // GET: /CheckParkingAvailability/

        public ActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public string GetAvailableParking(ReservedParkingModel reservedParkingModel)
        {
            if (ModelState.IsValid)
            {
               // reservedParkingModel.type = Session["TYPE"].ToString();
                List<ParkingSlotModel> availableSlots = DAL.GetAllAvailableSlots(reservedParkingModel);
                var jsonSerialiser = new JavaScriptSerializer();
                return jsonSerialiser.Serialize(availableSlots);
            }

            else
            {
                return null;
            }
        }

    }
}
