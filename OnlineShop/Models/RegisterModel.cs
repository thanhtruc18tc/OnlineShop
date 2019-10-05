using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    public class RegisterModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public string Address { get; set; }
    }
}