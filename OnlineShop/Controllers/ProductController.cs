using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using OnlineShop.Common.Base;

namespace OnlineShop.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Product
        public ActionResult Index(int id)
        {
            var dao = new ProductDao(context);
            var model = dao.GetDetail(id);

            var listImage = new ImageDao(context).GetAllImage(id);
            ViewBag.ListImage = listImage;
            return View("Product", model);
        }
    }
}