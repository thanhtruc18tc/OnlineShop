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
using OnlineShop.Common.Helper;

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

            if (sessionUser != null)
            {
                cartInfo.shipName = sessionUser.name;
                cartInfo.shipPhone = sessionUser.phone;
                cartInfo.shipEmail = sessionUser.email;
                cartInfo.shipAddress = sessionUser.address;
            }

            var totalPrice = 0;
            if (sessionCart != null)
            {
                foreach (var item in sessionCart)
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
            return Json(new
            {
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
                if (jsonItem.quantity == 0)
                {
                    var delete = Delete(jsonItem.product.id_product);
                    return Json(new
                    {
                        status = true
                    });
                }

                if (jsonItem != null)
                {
                    var inStore = new SizeDao(context).GetQuantity(jsonItem.product.id_product, item.size);
                    if (inStore < jsonItem.quantity)
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

            return RedirectToAction("Index", "Cart");
        }

        public ActionResult SubmitOrder(string name, string email, string phone, string address, string pay_method)
        {
            var dao = new OrderDao(context);
            string contentString = "";
            var sessionCart = (List<CartItem>)Session[Constants.CART_SESSION];

            var totalPrice = 0;
            foreach (var item in sessionCart)
            {
                updateQuantityInStore(item.product.id_product, item.size, item.quantity);

                var itemPrice = 0;
                var indivialPrice = 0;
                var discountPrice = 0;
                if (item.product.promotionPrice == null)
                {
                    indivialPrice = (int)item.product.price;
                    itemPrice = (int)item.product.price * item.quantity;
                } else {
                    discountPrice = (int)item.product.price - (int)item.product.promotionPrice;
                    indivialPrice = (int)item.product.promotionPrice;
                    itemPrice = (int)item.product.promotionPrice * item.quantity;
                }
               

                totalPrice += itemPrice;
                contentString += "<tr><td align=\"left\" style=\"padding:3px 9px\" valign=\"top\"><span> {{itemName}} </span><br></td><td align=\"left\" style=\"padding:3px 9px\" valign=\"top\"><span> {{itemSize}} </span><br></td><td align=\"left\" style =\"padding:3px 9px\" valign=\"top\"><span> {{itemIndiPrice}}đ </span></td><td align=\"left\" style =\"padding:3px 9px\" valign=\"top\">{{itemQuantity}}</td><td align=\"left\" style=\"padding:3px 9px\" valign=\"top\"><span>{{itemDiscount}}đ </span></td><td align=\"right\" style=\"padding:3px 9px\" valign=\"top\" ><span>{{itemPrice}} </span></td></tr>";
                contentString = contentString.Replace("{{itemName}}", item.product.name);
                contentString = contentString.Replace("{{itemSize}}", item.sizeName);
                contentString = contentString.Replace("{{itemIndiPrice}}", String.Format("{0:n0}", indivialPrice));
                contentString = contentString.Replace("{{itemQuantity}}", item.quantity.ToString());
                contentString = contentString.Replace("{{itemDiscount}}", "0");
                contentString = contentString.Replace("{{itemPrice}}", String.Format("{0:n0}", itemPrice));
                
            }

            var idUser = 1;
            var sessionUser = (User)Session[Constants.USER_SESSION];
            if (sessionUser != null)
            {
                idUser = sessionUser.id_user;
            }

            var order = new Order(name, phone, email, address, totalPrice, idUser, "Chưa duyệt", false, DateTime.Now);
            var success = dao.AddOrder(order);
            Session[Constants.CART_SESSION] = null;
            setMessage("Đơn hàng của bạn đã được gửi đi.");

            // Send mail
            var shipFee = 30000;
            string content = System.IO.File.ReadAllText(Server.MapPath("~/Common/Order.html"));
            content = content.Replace("{{name}}", name);
            content = content.Replace("{{email}}", email);
            content = content.Replace("{{phone}}", phone);
            content = content.Replace("{{address}}", address);
            content = content.Replace("{{createDate}}", DateTime.Now.ToString());
            
            if (totalPrice > 500000)
            {
                shipFee = 0;
            }
            content = content.Replace("{{totalPrice}}", String.Format("{0:n0}", totalPrice + shipFee));
            content = content.Replace("{{shipFee}}", shipFee.ToString());
            content = content.Replace("{{content}}", contentString);
            if (pay_method == "cod")
            {
                content = content.Replace("{{paymentMethod}}", "Thanh toán khi nhận hàng");
            } else
            {
                content = content.Replace("{{paymentMethod}}", "Chuyển khoản");
            }
            
            new MailHelper().sendMail(email, "Đơn hàng mới từ The ShopMax", content);
            Console.WriteLine(content);
            return RedirectToAction("Index", "Cart");
        }

        private bool updateQuantityInStore(int id, int idSize, int quantity)
        {
            var dao = new SizeDetailDao(context);
            return dao.updateQuantity(id, idSize, quantity);
        }
    }
}