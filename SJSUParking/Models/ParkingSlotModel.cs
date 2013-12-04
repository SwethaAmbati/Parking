using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJSUParking.Models
{
    public class ParkingSlotModel
    {
        public string GarageName { get; set; }
        public string SlotId { get; set; }
        public int Floor { get; set; }
        public string Type { get; set; }
    }
}