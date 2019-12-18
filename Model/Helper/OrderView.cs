using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model.EF;

namespace Model.Helper
{
    public class OrderView
    {
        public int Id_Order { get; set; }
        public int Id_Customer { get; set; }
        public string Name { get; set; }
        public string ShipName { get; set; }
        public string Email { get; set; }
        public string SDT { get; set; }
        public string Address { get; set; }
        public int TotalPrice { get; set; }
        public string status { get; set; }
        public bool IsPaid { get; set; }
        public DateTime Datetime { get; set; }

        public List<OrderDetail> Products { get; set; }
    }
}
