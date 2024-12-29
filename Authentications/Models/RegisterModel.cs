using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Authentications.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage="Id Required")]
        [DataType(DataType.PhoneNumber)]
        public int Id { get; set; }
        [Required(ErrorMessage = "UserName Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Pwd { get; set; }
        [Required(ErrorMessage = "Confirm Password Required")]
        [DataType(DataType.Password)]
        [Compare("Pwd",ErrorMessage ="Enter Pwd & Cpwd Should Not Be Same")]
        [Display(Name ="Confirm Password")]
        public string Cpwd { get; set; }
        [Required(ErrorMessage = "Age Required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Gender Required")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone Required")]
        [DataType(DataType.PhoneNumber)]
        public long Phone { get; set; }

    }
}