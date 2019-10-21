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

namespace OnlineShop.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        OnlineShopContext context = new OnlineShopContext();

        // GET: Admin/Account
        public ActionResult Index()
        {
            ViewBag.ListAccount = getAll();
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
                    AccountModel acc = new AccountModel(user.id_user, user.name, user.username, user.email, user.admin == true ? "Quản trị viên" : "Khách hàng", user.status == true ? "Đang hoạt động" : "Bị khóa");
                    accountModel.Add(acc);
                }
            }
            return accountModel;
        }

        // GET: Admin/Disable
        public ActionResult Disable(int id)
        {
            var dao = new UserDao(context);
            if (dao.changeStatus(id)) {
                ViewBag.Message = "Success";
            }
            else
            {
                ViewBag.Message = "Failed";
            }
            ViewBag.ListAccount = getAll();
            return View("Account");
        }
    }
}