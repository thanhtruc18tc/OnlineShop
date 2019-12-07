using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model.EF;

namespace Model.Helper
{
    public class ProductView
    {
        public int Id_product { get; set; }
        public int Id_category { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public int Price { get; set; }
        public int PrPrice { get; set; }
        public List<int> Id_Size { get; set; }
        public List<int> Qua_Size { get; set; }
        public List<String> Images { get; set; }
    }
}
