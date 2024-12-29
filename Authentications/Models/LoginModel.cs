using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Authentications.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Pwd { get; set; }
        [Required(ErrorMessage = "Click Me")]
        [Display(Name ="Remember Me")]
        public bool Rememberme { get; set; }
    }
}