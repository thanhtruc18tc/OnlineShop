using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Common.Constants;
using OnlineShop.Model;
using Model.Dao;
using OnlineShop.Common.Base;
using System.Web.Script.Serialization;
using Model.EF;
namespace OnlineShop.Controllers
{
    public class CartController : BaseController
    {
        // GET: Cart
        public ActionResult Index()
        {
            
            //var list = new List<CartItem>();
            //if (cart != null)
            //{
            //    list = (List<CartItem>)cart;
            //}
            var cartInfo = new CartInfo();
            var sessionUser = (User)Session[Constants.USER_SESSION];
            var sessionCart = (List<CartItem>)Session[Constants.CART_SESSION];

            if (sessionUser != null) {
                cartInfo.shipName = sessionUser.name;
                cartInfo.shipPhone = sessionUser.phone;
                cartInfo.shipEmail = sessionUser.email;
                cartInfo.shipAddress = sessionUser.address;
            }

            var totalPrice = 0;
            if(sessionCart != null)
            {
                foreach(var item in sessionCart)
                {
                    var price = (((item.product.promotionPrice == null) ? (int)item.product.price : (int)item.product.promotionPrice)) * item.quantity;
                    totalPrice += price;
                }
                cartInfo.totalPrice = totalPrice;
            }
            var discountPrice = 0;
            cartInfo.discountPrice = discountPrice;
            cartInfo.lastPrice = totalPrice - discountPrice;
            cartInfo.isCOD = true;

            return View("Cart", cartInfo);
        }

        public JsonResult Delete(int id)
        {
            var sessionCart = (List<CartItem>)Session[Constants.CART_SESSION];
            sessionCart.RemoveAll(x => x.product.id_product == id);
            Session[Constants.CART_SESSION] = sessionCart;
            return Json( new {
                 status = true
            });

        }

        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[Constants.CART_SESSION];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.product.id_product == item.product.id_product);

                // If quantity = 0 => delete that item
                if (jsonItem.quantity == 0) {
                    var delete = Delete(jsonItem.product.id_product);
                    return Json(new
                    {
                        status = true
                    });
                }

                if (jsonItem != null)
                {
                    var inStore = new SizeDao(context).GetQuantity(jsonItem.product.id_product, item.size);
                    if ( inStore < jsonItem.quantity)
                    {
                        return Json(new
                        {
                            status = false,
                            message = "Xin lỗi, chúng tôi chỉ còn tất cả " + inStore + " sản phẩm"
                        });
                    }
                    item.quantity = jsonItem.quantity;
                }
            }
            Session[Constants.CART_SESSION] = sessionCart;
            return Json(new
            {
                status = true
            });
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

        public ActionResult SubmitOrder()
        {
            var sessionCart = (List<CartItem>)Session[Constants.CART_SESSION];

            return RedirectToAction("Index", "Cart");
        }
    }
}