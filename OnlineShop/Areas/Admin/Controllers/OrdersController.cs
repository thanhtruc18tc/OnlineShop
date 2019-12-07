using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Common.Base;
using Model.Dao;
using Model.EF;
using OnlineShop.Common.Constants;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class OrdersController : BaseController
    {
        // GET: Admin/Orders
        public ActionResult Index(int page = 1)
        {
            var daoOrder = new OrderDao(context);
            var listOrder = daoOrder.GetAllOrder(page, pageSize);
            var listNameCus = new List<string>();
            foreach(var order in listOrder)
            {
                listNameCus.Add(new UserDao(context).GetById((int)order.id_customer).name);
            }
            ViewBag.Page = page;
            ViewBag.Total = listOrder.Count();
            ViewBag.Users = listNameCus;
            return View("Orders",listOrder);
        }
    }
}