using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Common.Base;
using Model.Dao;
using Model.EF;
using OnlineShop.Common.Constants;
using Model.Helper;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductController : AdminBaseController
    {
        // GET: Admin/Product
        public ActionResult Index(int page = 1)
        {
            var daoProduct = new ProductDao(context);
            var daoQua = new SizeDetailDao(context);
            ViewBag.Page = page;
            ViewBag.Total = daoProduct.GetCount();
            var list = daoProduct.GetProducts(page, pageSize);
            var quaProduct = new List<int>();
            foreach(var item in list)
            {
                quaProduct.Add(daoQua.GetQuanlity(item.id_product));
            }
            ViewBag.Category = GetNameCategories(list);
            ViewBag.Quanlity = quaProduct;
            return View(list);
        }

        public ActionResult Delete(int id)
        {
            var result = new ProductDao(context).DeleteProduct(id);
            if (result.Equals(true))
            {
                ViewBag.ClassText = " text-success";
                ModelState.AddModelError("", Constants.Suc_CreateProduct);
            }
            else
            {
                ViewBag.ClassText = " text-danger";
                ModelState.AddModelError("", Constants.Err_CreateProduct);
            }
            return View();

        }
        public ActionResult Create()
        {
            //Default View
            var daoSize = new SizeDao(context);
            var daoCat = new CategoryDao(context);
            ViewBag.Categories = daoCat.GetAll();
            ViewBag.Sizes = daoSize.GetListSize();
            ViewBag.Action = Constants.CreateProduct;
            return View("Detail");
        }

        [HttpPost]
        public ActionResult Create(ProductView model)
        {
            //Default View
            var daoSize = new SizeDao(context);
            var daoCat = new CategoryDao(context);
            ViewBag.Sizes = daoSize.GetListSize();
            ViewBag.Categories = daoCat.GetAll();
            ViewBag.Action = Constants.CreateProduct;
            ViewBag.ClassText = "";

            //Check model
            if (ModelState.IsValid)
            {
                //Import Dao
                ProductDao productDao = new ProductDao(context);
                ImageDao imageDao = new ImageDao(context);
                SizeDetailDao sizeDetailDao = new SizeDetailDao(context);
                //Create Product
                Product product = new Product{
                        name = model.Name,
                        id_category = model.Id_category,
                        description = model.Description,
                        price = model.Price,
                        promotionPrice = model.PrPrice,
                        dateCreate = DateTime.Now
                    };
                //Add Product
                var result = productDao.AddProduct(product);
                if (result == true)
                {
                    //Get id_product
                    int id_product = product.id_product;
                    //Insert Size
                    var resultSize = true;
                    for(int i_size = 0; i_size < model.Id_Size.Count; i_size++)
                    {
                        var rsSize = sizeDetailDao.Insert(id_product, model.Id_Size[i_size], model.Qua_Size[i_size]);
                        if (rsSize == false)
                        {
                            resultSize = false;
                        }
                    }
                    if(resultSize == false)
                    {
                        ViewBag.ClassText = " text-danger";
                        ModelState.AddModelError("", Constants.Err_CreateProductSize);
                    }
                    else
                    {
                        //Insert Images
                        var resultImg = true;
                        foreach (var img in model.Images)
                        {
                            var rsI = imageDao.Insert(id_product, img);
                            if(rsI == false)
                            {
                                resultImg = false;
                            }
                        }
                        if(resultImg == false)
                        {
                            ViewBag.ClassText = " text-danger";
                            ModelState.AddModelError("", Constants.Err_CreateProductImage);
                        }
                        else
                        {
                            ViewBag.ClassText = " text-success";
                            ModelState.AddModelError("", Constants.Suc_CreateProduct);
                        }
                    }
                }
                else
                {
                    ViewBag.ClassText = " text-danger";
                    ModelState.AddModelError("", Constants.Err_CreateProduct);
                }
                return View("Detail");
            }
            return View("Detail");
        }

        public ActionResult Edit(int id)
        {
            List<string> listImages = new ImageDao(context).GetAllImage(id);
            List<SizeDetail> listSize = new SizeDetailDao(context).GetAllSizeDetailById(id);
            List<int> listIdSize = new List<int>();
            List<int> listQuaSize = new List<int>();
            foreach (var size in listSize)
            {
                listIdSize.Add(size.id_size);
                listQuaSize.Add(size.quantity);
            }
            var product = new ProductDao(context).GetDetail(id);

            //Create model
            var model = new ProductView();
            model.Id_product = id;
            model.Name = product.name;
            model.Price = (product.price != null) ? (int)product.price : 0;
            model.PrPrice = (product.promotionPrice != null)?(int)product.promotionPrice:0;
            model.Id_category = product.id_category;
            model.Description = product.description;
            model.Images = listImages;
            model.Id_Size = listIdSize;
            model.Qua_Size = listQuaSize;

            //Default View
            var daoSize = new SizeDao(context);
            var daoCat = new CategoryDao(context);
            ViewBag.Categories = daoCat.GetAll();
            ViewBag.Sizes = daoSize.GetListSize();
            ViewBag.Action = Constants.UpdateProduct;
            return View("Detail", model);
        }

        [HttpPost]
        public ActionResult Edit(ProductView model)
        {
            var product = new ProductDao(context).UpdateProduct(model.Id_product, model.Name, model.Description, model.Price, model.PrPrice, model.Id_category);
            ViewBag.ClassText = " text-success";
            ModelState.AddModelError("", Constants.Suc_UpdateProduct);
            model.Name = product.name;
            model.Price = (product.price != null) ? (int)product.price : 0;
            model.PrPrice = (product.promotionPrice != null) ? (int)product.promotionPrice : 0;
            model.Id_category = product.id_category;
            model.Description = product.description;
            //Default View
            var daoSize = new SizeDao(context);
            var daoCat = new CategoryDao(context);
            ViewBag.Categories = daoCat.GetAll();
            ViewBag.Sizes = daoSize.GetListSize();
            ViewBag.Action = Constants.UpdateProduct;
            return View("Detail", model);
        }


        private List<String> GetNameCategories(IEnumerable<Product> list)
        {
            var daoCategory = new CategoryDao(context);
            List<String> categories = new List<String>();
            foreach (var item in list)
            {
                categories.Add(daoCategory.GetNameById(item.id_category));
            }
            return categories;
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