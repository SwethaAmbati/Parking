using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SJSUParking.Models
{
    public class UserModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Email Id")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone number")]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "SJSU Id")]
        public string SJSUId { get; set; }
        [Required]
        [Display(Name = "Driver's License Number")]
        public string DrivingLicNo { get; set; }
        [Required]
        [Display(Name = "Type Of User")]
        public string Type { get; set; }

    }
}