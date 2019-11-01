using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Model
{
    public class CartInfo
    {
        public string shipName { get; set; }
        public string shipPhone { get; set; }
        public string shipEmail { get; set; }
        public string shipAddress { get; set; }
        public int totalPrice { get; set; }
        public int discountPrice { get; set; }
        public int lastPrice { get; set; }
        public bool isCOD { get; set; }

    }
}