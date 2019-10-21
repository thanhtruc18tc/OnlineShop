﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        // GET: Admin/Order
        public ActionResult Index()
        {
            return View("Order");
        }

        // GET: Admin/OrderDetail
        public ActionResult OrderDetail()
        {
            return View("OrderDetail");
        }
    }
}