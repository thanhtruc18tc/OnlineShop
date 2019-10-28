using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using OnlineShop.Models;
using OnlineShop.Common.Constants;
using Model.EF;
using OnlineShop.Common.Helper;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            new UserDao(new OnlineShopContext()).test();
            return View();
        }

        public ActionResult Shop()
        {
            return View();
        }

        public ActionResult Product()
        {
            return View();
        }


        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Thankyou()
        {
            return View();
        }

    }
        
}