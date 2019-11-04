using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using OnlineShop.Common.Base;
using OnlineShop.Model;
using Model.EF;
using OnlineShop.Common.Constants;

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

        public JsonResult Add(int id, int quantity, int size)
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
                            // Check
                            var inStore = new SizeDao(context).GetQuantity(id, size);
                            if ((item.quantity + quantity) > inStore)
                            {
                                return Json(new
                                {
                                    status = false,
                                    message = "Xin lỗi, chúng tôi chỉ còn tất cả " + inStore + " sản phẩm"
                                });
                            }

                            item.quantity += quantity;
                        }
                    }
                }
                else
                {
                    if (!checkQuantity(id, size, quantity))
                    {
                        var inStore = new SizeDao(context).GetQuantity(id, size);
                        return Json(new
                        {
                            status = false,
                            message = "Xin lỗi, chúng tôi chỉ còn tất cả " + inStore + " sản phẩm"
                        });
                    }

                    // Create new item 
                    var item = new CartItem();
                    item.image = new ImageDao(context).GetByIdProduct(id).link;
                    item.product = product;
                    item.quantity = quantity;

                    item.size = size;
                    item.sizeName = new SizeDao(context).GetNameById(size);

                    list.Add(item);
                }
            }
            else
            {
                if (!checkQuantity(id, size, quantity))
                {
                    var inStore = new SizeDao(context).GetQuantity(id, size);
                    return Json(new
                    {
                        status = false,
                        message = "Xin lỗi, chúng tôi chỉ còn tất cả " + inStore + " sản phẩm"
                    });
                }
                // Create new cart 
                var item = new CartItem();
                item.product = product;
                item.image = new ImageDao(context).GetByIdProduct(id).link;
                item.quantity = quantity;
                item.size = size;
                item.sizeName = new SizeDao(context).GetNameById(size);
                var list = new List<CartItem>();
                list.Add(item);
                // Save to session
                Session[Constants.CART_SESSION] = list;

            }

            return Json(new
            {
                status = true
            });
        }

        public bool checkQuantity(int idProd, int idSize, int cartQuantity)
        {
            var inStore = new SizeDao(context).GetQuantity(idProd, idSize);
            if (inStore >= cartQuantity)
            {
                return true;
            }
            return false;
        }
    }
}