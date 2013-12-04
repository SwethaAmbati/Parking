using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SJSUParking.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "SJSU ID")]
        public string SJSUId { get; set; }

        [Required]
        public string Password { get; set; }

        public bool authenticated { get; set; }

        public string Type { get; set; }
    }
}
