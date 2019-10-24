using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using OnlineShop.Common.Constants;
using OnlineShop.Common.Helper;
using OnlineShop.Common.Base;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class AccountController : BaseController
    {
        OnlineShopContext context = new OnlineShopContext();
        int isFilterBy = 0;

        // GET: Admin/Account
        public ActionResult Index()
        {
            ViewBag.ListAccount = getAll();
            return View("Account");
        }

        // GET: Admin/Account/Filter
        public ActionResult Filter(int filterBy)
        {
            if (filterBy == 1)
            {
                ViewBag.Filter = 1;
                ViewBag.ListAccount = getAdmin();
            }
            return View("Account");
        }

        public List<User> getAll()
        {
            return new UserDao(context).getAll();
        }

        public List<User> getAdmin()
        {
           
            return new UserDao(context).getAllAdmin();
        }

        // POST: Admin/ChangeStatus
        [HttpPost]
        public ActionResult ChangeStatus(int id)
        {
            var dao = new UserDao(context);
            if (!dao.ChangeStatus(id))
            {
                ViewBag.Message = "Failed";
            }
            else
            {
                ViewBag.ListAccount = getAll();
            }
            return Index();
        }

        // POST: Admin/Change
        [HttpPost]
        public JsonResult Change(int id)
        {
           var result = new UserDao(context).ChangeStatus(id);
           return Json(new
           {
               status = result
           });
        }
    }
}