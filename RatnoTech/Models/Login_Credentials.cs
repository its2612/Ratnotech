using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RatnoTech.Models
{
    public class Login_Credentials
    {
        [Required(ErrorMessage="compulsory")]
        public string Username { get; set; }
        [Required(ErrorMessage = "compulsory")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}