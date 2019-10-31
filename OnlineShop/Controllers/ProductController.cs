using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using OnlineShop.Common.Base;
using OnlineShop.Model;
using Model.EF;
namespace OnlineShop.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index(int id)
        {
            var passModel = new ProductDetailPage();

            var dao = new ProductDao(context);
            var detail = dao.GetDetail(id);
            passModel.productDetail = detail;

            var sizeDao = new SizeDao(context);
            passModel.listSize = sizeDao.GetSizeList(id);

            var listImage = new ImageDao(context).GetAllImage(id);
            ViewBag.ListImage = listImage;

            var relativeProduct = dao.GetRelativeProduct("", id);
            passModel.listRelativeProduct = relativeProduct;

            var listRelativeImage = GetListImage(relativeProduct);
            passModel.listImageRelativeProduct = listRelativeImage;

            ViewBag.Title = detail.name;

            return View("Product", passModel);
        }

        private List<Image> GetListImage(IEnumerable<Product> list)
        {
            List<Image> listImage = new List<Image>();
            var dao = new ImageDao(context);
            foreach (var item in list)
            {
                listImage.Add(dao.GetByIdProduct(item.id_product));
            }
            return listImage;
        }
    }
}