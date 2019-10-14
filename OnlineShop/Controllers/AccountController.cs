using Model.Dao;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Common.Constants;
using Model.EF;
using OnlineShop.Common.Helper;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        #region Login

        public ActionResult LoginIndex()
        {
            return View("Login");
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    //var user = dao.GetById(model.UserName);
                    //var userSession = new UserLogin();
                    //userSession.UserID = user.ID;
                    //Session.Add(Constants.USER_SESSION, userSession);
                    ViewBag.Message = Constants.LOGIN_SUCCESSFUL;
                    ViewBag.Status = "True";
                    return RedirectToAction("Index", "Home");
                    //return View("Index");
                    //return View("Index");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", Constants.USERNAME_NON_EXISTED);
                    ViewBag.Status = false;
                    ViewBag.ShowModal = Constants.SHOW_LOGIN_MODAL;
                    return View();
                }
                else
                {
                    ViewBag.ShowModal = Constants.SHOW_LOGIN_MODAL;
                    ModelState.AddModelError("", Constants.PASSWORD_INCORRECT);
                    ViewBag.Status = false;
                    return View();
                }
            }
            ViewBag.Status = false;
            return View();
        }
        #endregion

        #region Register
        public ActionResult SignUpIndex()
        {
            return View("SignUp");
        }

        [HttpPost]
        public ActionResult SignUp(RegisterModel model)
        {
            bool status = false;
            string message = "";
            #region Check Model Validation
            if (ModelState.IsValid)
            {
                #region Validate User Information
                var isExisted = IsEmailExisted(model.Email);
                if (isExisted)
                {
                    ModelState.AddModelError("", Constants.EMAIL_EXISTED);
                    ViewBag.ShowModal = Constants.SHOW_SIGN_UP_MODAL;
                    ViewBag.Status = false;
                    return View("SignUp");
                }
                if (model.Password != model.RePassword)
                {
                    ModelState.AddModelError("", Constants.REPASSWORD_INCORRECT);
                    ViewBag.ShowModal = Constants.SHOW_SIGN_UP_MODAL;
                    ViewBag.Status = false;
                    return View("SignUp");
                }
                #endregion

                #region Password hashing
                model.Password = Encryptor.MD5Hash(model.Password);
                #endregion

                #region Save to Database
                var dao = new UserDao();
                User user = new User(model.Username, model.Password, model.Name, model.Address, model.Email, model.NumberPhone, DateTime.Now, true);
                long id = dao.Insert(user);
                #endregion

                message = "Registration successfully done.";
                status = true;
            }
            else
            {
                message = "Invalid request";
            }
            #endregion

            ViewBag.Status = status;
            ViewBag.Message = message;

            //ModelState.AddModelError("", Constants.SIGN_UP_SUCCESSFUL);
            //return View("SignUp", model);
            return RedirectToAction("Index", "Home", model) ;
        }
        // Verify

        [NonAction]
        public bool IsEmailExisted(string email)
        {
            var dao = new UserDao();
            return dao.IsEmailExisted(email);
        }
        #endregion
    }


}