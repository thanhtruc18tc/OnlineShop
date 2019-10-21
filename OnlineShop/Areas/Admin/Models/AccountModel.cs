using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class AccountModel
    {
        public int id { get; set; }
        public String name { get; set; }
        public String username { get; set; }
        public String email { get; set; }
        public String role { get; set; }
        public String status { get; set; }

        public AccountModel(int id, String name, String username, String email, String role, String status) {
            this.id = id;
            this.name = name;
            this.username = username;
            this.email = email;
            this.role = role;
            this.status = status;
        }
    }
}