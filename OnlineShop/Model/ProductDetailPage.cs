using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model.EF;
namespace OnlineShop.Model
{
    public class ProductDetailPage
    {
        public Product productDetail { get; set; }
        public List<Size> listSize { get; set; }
        public IEnumerable<Product> listRelativeProduct { get; set; }
        public List<Image> listImageRelativeProduct { get; set;
 }
    }
}