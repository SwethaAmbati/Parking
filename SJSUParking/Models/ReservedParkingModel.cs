using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SJSUParking.Models
{
    public class ReservedParkingModel
    {
        //[Required]
        //[DataType(System.ComponentModel.DataAnnotations.DataType.Date, ErrorMessage = "Please enter a valid date in the format mm/dd/yyyy")]
        //[Display(Name = "Start Date")]
        //public DateTime StartDate { get; set; }

        //[Required]
        //[DataType(System.ComponentModel.DataAnnotations.DataType.Date, ErrorMessage = "Please enter a valid date in the format mm/dd/yyyy")]
        //[Display(Name = "End Date")]
        //public DateTime EndDate { get; set; }

        //[Required]
        //[DataType(System.ComponentModel.DataAnnotations.DataType.Time, ErrorMessage = "Please enter a valid time in the format HH:mm:ss")]
        //[Display(Name = "Start Time")]
        //public string StartTime { get; set; }

        //[Required]
        //[DataType(System.ComponentModel.DataAnnotations.DataType.Time, ErrorMessage = "Please enter a valid time in the format HH:mm:ss")]
        //[Display(Name = "End Time")]
        //public string EndTime { get; set; }

        [Required]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Time, ErrorMessage = "Please enter a valid garage name")]
        [Display(Name = "Garage Name")]
        public string GarageName { get; set; }

        [Required]
        public string StartDateTime { get; set; }

        [Required]
        public string EndDateTime { get; set; }

        public string SelectedParkingSlotId { get; set; }

        public string SJSUId { get; set; }

        public string type { get; set; }

        //public float Duration { get; set; }

        //public SelectList list = new SelectList(new [] {"North", "South", "East", "West"});

        //public List<ParkingSlotModel> AvailableParkingSlots { get; set; }
    }
}