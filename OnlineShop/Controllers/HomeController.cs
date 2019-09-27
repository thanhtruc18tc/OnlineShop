using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using OnlineShop.Models;
using OnlineShop.Common;

namespace OnlineShop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.Password);
                if (result)
                {
                    //var user = dao.GetById(model.UserName);
                    //var userSession = new UserLogin();
                    //userSession.UserID = user.ID;
                    //Session.Add(Constants.USER_SESSION, userSession);
                    ModelState.AddModelError("", "Login successfully");
                    ViewBag.ShowModal = false;

                    return RedirectToAction("Index", "Home");
                    //return View("Index");
                }
                else
                {
                    ViewBag.ShowModal = true;
                    ModelState.AddModelError("", "Login failed.");
                }
            }
            ViewBag.ShowModal = true;
            return View("Index");
        }
    }
}