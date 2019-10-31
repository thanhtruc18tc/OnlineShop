using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;

namespace OnlineShop.Model
{
    public class CartItem
    {
        public Product product { get; set; }
        public string image { get; set; }
        public string productName { get; set; }
        public int individualPrice { get; set; }
        public int quantity { get; set; }
        public int totalPrice { get; set; }
    }
}