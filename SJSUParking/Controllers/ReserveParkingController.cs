using SJSUParking.Controllers;
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
    public class ReserveParkingController : Controller
    {
        //
        // GET: /ReserveParking/

        public ActionResult Index()
        {
            return View(new ReservedParkingModel());
        }

        [HttpPost]
        public string GetAvailableParking(ReservedParkingModel reservedParkingModel)
        {

            if (ModelState.IsValid)
            {
                reservedParkingModel.type = Session["TYPE"].ToString();
                List<ParkingSlotModel> availableSlots = DAL.GetAvailableSlots(reservedParkingModel);
                var jsonSerialiser = new JavaScriptSerializer();
                return jsonSerialiser.Serialize(availableSlots);
            }

            else
            {
                return null;
            }

        }

        [HttpPost]
        public void BookParkingSlot(ReservedParkingModel reservedParkingModel)
        {
            if (ModelState.IsValid)
            {
                reservedParkingModel.SJSUId = Session["SJSUID"].ToString();
                DAL.InsertUserParkingReservation(reservedParkingModel);
            }
        }
    }
}
