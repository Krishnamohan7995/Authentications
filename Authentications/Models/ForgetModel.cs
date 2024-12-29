using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Authentications.Models
{
    public class ForgetModel
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string Pwd { get; set; }

        [Required(ErrorMessage = "Confirm Password Required")]
        [DataType(DataType.Password)]
        [Compare("Pwd", ErrorMessage = "Enter Pwd & Cpwd Should Not Be Same")]
        [Display(Name = "Confirm New Password")]
        public string Cpwd { get; set; }
    }
}