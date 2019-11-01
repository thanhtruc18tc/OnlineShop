using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Common.Constants;
using OnlineShop.Model;
using Model.Dao;
using OnlineShop.Common.Base;

namespace OnlineShop.Controllers
{
    public class CartController : BaseController
    {
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[Constants.CART_SESSION];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View("Cart");
        }

        public ActionResult Add(int id, int quantity, int size)
        {
            var product = new ProductDao(context).GetDetail(id);

            var cart = Session[Constants.CART_SESSION];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.product.id_product == id && x.size == size))
                {
                    foreach (var item in list)
                    {
                        if (item.product.id_product == id)
                        {
                            item.quantity += quantity;
                        }
                    }
                }
                else
                {
                    // Create new item 
                    var item = new CartItem();
                    item.image = new ImageDao(context).GetByIdProduct(id).link;
                    item.product = product;
                    item.quantity = quantity;
                    item.size = size;
                    list.Add(item);
                }
            }
            else
            {
                // Create new cart 
                var item = new CartItem();
                item.product = product;
                item.image = new ImageDao(context).GetByIdProduct(id).link;
                item.quantity = quantity;
                item.size = size;
                var list = new List<CartItem>();
                list.Add(item);
                // Save to session
                Session[Constants.CART_SESSION] = list;

            }

            return RedirectToAction("Index","Cart");
        }
    }
}