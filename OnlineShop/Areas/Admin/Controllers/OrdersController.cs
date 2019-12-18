using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Common.Base;
using Model.Dao;
using Model.EF;
using OnlineShop.Common.Constants;
using OnlineShop.Model;
using Model.Helper;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class OrdersController : AdminBaseController
    {
        // GET: Admin/Orders
        public ActionResult Index(int page = 1)
        {
            var daoOrder = new OrderDao(context);
            var listOrder = daoOrder.GetAllOrder(page, pageSize);
            ViewBag.Page = page;
            ViewBag.Total = listOrder.Count();
            return View("Orders", listOrder);
        }

        public ActionResult Edit(int id)
        {
            var order = new OrderDao(context).GetDetailByIdOrder(id);
            var model = new OrderView();
            model.Name = new UserDao(context).GetById((int)order.id_customer).name;
            model.ShipName = order.shipName;
            model.SDT = order.shipMobile;
            model.Email = order.shipEmail;
            model.Address = order.shipAddress;
            model.status = order.status;
            model.IsPaid = order.isPaid;
            model.TotalPrice = order.totalPrice;
            model.Datetime = order.createDate;
            model.Id_Order = order.id_order;
            model.Id_Customer = (int)order.id_customer;
            var daoOrderDetail = new OrderDetailDao(context);
            var daoProduct = new ProductDao(context);
            var listDetail = daoOrderDetail.GetAllByIdOrd(model.Id_Order);
            List<string> listName = new List<string>();
            foreach(var item in listDetail)
            {
                listName.Add(daoProduct.GetDetail(item.id_product).name);
            }
            ViewBag.ListDetail = listDetail;
            ViewBag.ListName = listName;
            //Default View
            ViewBag.Action = "CHỈNH SỬA ĐƠN HÀNG";
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(OrderView model)
        {
            var order = new OrderDao(context).UpdateOrder(model.Id_Order,model.IsPaid,model.Address,model.Email,model.SDT,model.Name,model.status,model.TotalPrice);
            ViewBag.ClassText = " text-success";
            ModelState.AddModelError("", Constants.Order_Success);
            //Default View
            ViewBag.Action = "CHỈNH SỬA ĐƠN HÀNG";
            return View("Edit", model);
        }
    }
}