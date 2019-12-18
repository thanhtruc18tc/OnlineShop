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
    public class CategoryController : AdminBaseController
    {
        // GET: Admin/Category
        public ActionResult Index(int page = 1)
        {
            //var daoOrder = new OrderDao(context);
            var daoCategory = new CategoryDao(context);
            //var listOrder = daoOrder.GetAllOrder(page, pageSize);
            var listCat = daoCategory.GetAllCategory(page, pageSize);
            ViewBag.Page = page;
            ViewBag.Total = listCat.Count();
            return View("Index", listCat);
        }

        public ActionResult Create()
        {
            ViewBag.Action = "THÊM MỚI DANH MỤC";
            return View("Edit");
        }

        [HttpPost]
        public ActionResult Create(CategoryView model)
        {
            var daoCat = new CategoryDao(context);
            Category category = new Category
            {
                name = model.Name
            };
            var result = daoCat.AddCategory(category);
            if (result.Equals(true))
            {
                model.Id_Category = category.id_category;
                ViewBag.ClassText = " text-success";
                ModelState.AddModelError("", "Thêm danh mục mới thành công");
            }
            else
            {
                ViewBag.ClassText = " text-danger";
                ModelState.AddModelError("", "Thêm danh mục mới thất bại");
            }
            ViewBag.Action = "THÊM MỚI DANH MỤC";
            return View("Edit", model);
        }
        public ActionResult Edit(int id)
        {
            var cat = new CategoryDao(context).GetCategoryByIdCat(id);
            var model = new CategoryView();
            model.Name = cat.name;
            model.Id_Category = cat.id_category;
            ViewBag.Action = "CHỈNH SỬA DANH MỤC";
            return View("Edit", model);
        }

        [HttpPost]
        public ActionResult Edit(CategoryView model)
        {
            new CategoryDao(context).UpdateCategory(model.Id_Category, model.Name);
            ViewBag.ClassText = " text-success";
            ModelState.AddModelError("", "Chỉnh sửa danh mục thành công");
            ViewBag.Action = "CHỈNH SỬA DANH MỤC";
            return View("Edit", model);
        }
    }
}