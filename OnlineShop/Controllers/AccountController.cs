﻿using Model.Dao;
using OnlineShop.Models;
using System.Web.Mvc;
using OnlineShop.Common.Constants;
using Model.EF;
using OnlineShop.Common.Helper;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        OnlineShopContext context = new OnlineShopContext();


        #region Login
        public ActionResult _Login()
        {
            return View("Login");
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao(context);
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password));
                if (result == 1)
                {
                    var user = dao.GetByUsernameAndPassword(model.UserName, Encryptor.MD5Hash(model.Password));
                    Session.Add(Constants.USER_SESSION, user);

                    if ((bool)user.admin) {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    return RedirectToAction("Index", "Home");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", Constants.USERNAME_NON_EXISTED);
                    return View();
                }
                else
                {
                    ModelState.AddModelError("", Constants.PASSWORD_INCORRECT);
                    return View();
                }
            }
            ViewBag.Status = false;
            return View();
        }
        #endregion

        #region Register
        public ActionResult _SignUp()
        {
            return View("SignUp");
        }

        [HttpPost]
        public ActionResult SignUp(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // MARK: Validate User Information
                var isExisted = IsEmailExisted(model.Email);
                if (isExisted)
                {
                    ModelState.AddModelError("", Constants.EMAIL_EXISTED);
                    return View("SignUp");
                }
                if (model.Password != model.RePassword)
                {
                    ModelState.AddModelError("", Constants.REPASSWORD_INCORRECT);
                    return View("SignUp");
                }

                // MARK: Password hashing
                model.Password = Encryptor.MD5Hash(model.Password);

                // MARK: Save to Database
                var userDao = new UserDao(context);
                User user = new User(model.Username, model.Password, model.Email, model.Name, model.NumberPhone, model.Address, new MemberDao(context).getAll()[0], 0, false, true);
                userDao.Insert(user);

                // MARK: Create a session
                Session.Add(Constants.USER_SESSION, user);

            }
            else
            {
                ViewBag.Message = "Invalid request";
            }

            return RedirectToAction("Index", "Home") ;
        }

        [NonAction]
        public bool IsEmailExisted(string email)
        {
            var dao = new UserDao(context);
            return dao.IsEmailExisted(email);
        }
        #endregion

        #region Forgot password
        // POST: Account/ForgotPassword
        public ActionResult ForgotPassword(string email)
        {
            string newPassword = RandomHelper.RandomPassword();
            bool success = new UserDao(context).ChangePassword(email, Encryptor.MD5Hash(newPassword));

            if (success) {
                new MailHelper().sendMail(email, "Khôi phục mật khẩu", "Mật khẩu mới của bạn là: " + newPassword + ".");
                ViewBag.Message = Constants.CHANGE_PASSWORD_SUCCESS;
            }
            else
            {
                ViewBag.Message = Constants.CHANGE_PASSWORD_FAILD;
            }
            return View("Login");
        }
        #endregion

        #region See Profile
        public ActionResult MyProfile()
        {
            return View("Profile");
        }
        #endregion

        #region Update Profilte
        public ActionResult Update(string id, string name, string username, string email, string address, string phone)
        {
            var user = new UserDao(context).Update(id, name, username, email, address, phone);

            User userSession = (User)Session[Constants.USER_SESSION];
            Session[Constants.USER_SESSION] = user;

            ViewBag.Message = Constants.UPDATE_PROFILE_SUCCESS;
            return View("Profile");
        }
        #endregion

        #region Change Password
        public ActionResult ChangePassword(string oldPass, string newPass, string rePass)
        {

            //UserLogin userSession = (UserLogin)Session[Constants.USER_SESSION];



            //ViewBag.Message = Constants.UPDATE_PASSWORD_SUCCESS;
            return View("Profile");
        }
        #endregion

        #region LogOut
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        #endregion
    }


}