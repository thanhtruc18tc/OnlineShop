using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EF;
using OnlineShop.Areas.Admin.Models;
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

        public List<AccountModel> getAll()
        {
            List<AccountModel> accountModel = new List<AccountModel>();
            var dao = new UserDao(context);
            var listAccount = dao.getAll();

            if (listAccount.Count > 0)
            {
                foreach (User user in listAccount)
                {
                    AccountModel acc = new AccountModel(user.id_user, user.name, user.username, user.email, (bool)user.admin, (bool)user.status);
                    accountModel.Add(acc);
                }
            }
            return accountModel;
        }

        public List<AccountModel> getAdmin()
        {
            List<AccountModel> accountModel = new List<AccountModel>();
            var dao = new UserDao(context);
            var listAccount = dao.getAdmin();

            if (listAccount.Count > 0)
            {
                foreach (User user in listAccount)
                {
                    AccountModel acc = new AccountModel(user.id_user, user.name, user.username, user.email, (bool)user.admin, (bool)user.status);
                    accountModel.Add(acc);
                }
            }
            return accountModel;
        }

        // POST: Admin/ChangeStatus
        [HttpPost]
        public ActionResult ChangeStatus(int id)
        {
            var dao = new UserDao(context);
            if (!dao.changeStatus(id))
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
           var result = new UserDao(context).changeStatus(id);
           return Json(new
           {
               status = result
           });
        }
    }
}