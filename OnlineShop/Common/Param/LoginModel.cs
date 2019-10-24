using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Please enter email")]
        public string UserName { get; set; }
        public string Password { get; set; }

    }
}