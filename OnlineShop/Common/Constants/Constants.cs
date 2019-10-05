using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Common.Constants
{
    public class Constants
    {
        // MARK: LOGIN 
        public static string SHOW_LOGIN_MODAL = "SHOW_LOGIN_MODAL";
        public static string SHOW_SIGN_UP_MODAL = "SHOW_SIGN_UP_MODAL";
        public static string USER_SESSION = "USER_SESSION";
        public static string LOGIN_FAILED = "Đăng nhập thất bại.";
        public static string LOGIN_SUCCESSFUL = "Đăng nhập thành công.";
        public static string SIGN_UP_FAILED = "Đăng kí thất bại.";
        public static string SIGN_UP_SUCCESSFUL = "Đăng kí thành công.";
        public static string EMAIL_EXISTED = "Email đã tồn tại.";
        public static string USERNAME_EXISTED = "Username đã tồn tại.";
        public static string USERNAME_NON_EXISTED = "Username không tồn tại.";
        public static string REPASSWORD_INCORRECT = "Nhập lại mật khẩu không đúng.";
        public static string PASSWORD_INCORRECT = "Mật khẩu không đúng.";
    }
}