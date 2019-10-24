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
        public static string EMAIL_EXISTED = "Email đã tồn tại.";
        public static string USERNAME_EXISTED = "Username đã tồn tại.";
        public static string USERNAME_NON_EXISTED = "Username không tồn tại.";
        public static string REPASSWORD_INCORRECT = "Nhập lại mật khẩu không đúng.";
        public static string PASSWORD_INCORRECT = "Mật khẩu không đúng.";

        // MARK: FORGOT PASSWORD
        public static string CHANGE_PASSWORD_SUCCESS = "Mật khẩu mới đã được gửi về mail của bạn.";
        public static string CHANGE_PASSWORD_FAILD = "Email không tồn tại.";

        // MARK: PROFILE
        public static string UPDATE_PROFILE_SUCCESS = "Cập nhật thông tin thành công.";
        public static string UPDATE_PASSWORD_SUCCESS = "Cập nhật mật khẩu thành công.";

    }
}