﻿using System;
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

        // MARK: Men Collection
        public static string MenShirt = "Áo sơ mi nam";
        public static string MenTShirt = "Áo thun nam";
        public static string MenJacket = "Áo khoác nam";
        public static string MenTrouser = "Quần dài nam";
        public static string MenShort = "Quần short nam";
        public static string MenAll = "Tất cả quần áo nam";
        public static string MenArrival = "Quần áo nam mới về ";

        // MARK: Women Collection
        public static string WomenBlouse = "Áo kiểu nữ";
        public static string WomenShirt = "Áo sơ mi nữ";
        public static string WomenTShirt = "Áo thun nữ";
        public static string WomenJacket = "Áo khoác nữ";
        public static string WomenDress = "Váy nữ";
        public static string WomenTrouser = "Quần dài nữ";
        public static string WomenAll = "Tất cả quần áo nữ";
        public static string WomenArrival = "Quần áo nữ mới về";

        // MARK: SEARCH
        public static string Search = "Tìm kiếm sản phẩm";

        // MARK: ADMIN PRODUCT
        public static string CreateProduct = "THÊM MỚI SẢN PHẨM";
        public static string UpdateProduct = "CHỈNH SỬA SẢN PHẨM";
        public static string Suc_CreateProduct = "Thêm sản phẩm mới thành công!";
        public static string Suc_UpdateProduct = "Cập nhật sản phẩm mới thành công!";
        public static string Err_CreateProduct = "Thêm sản phẩm mới thất bại!";
        public static string Err_UpdateProduct = "Cập nhật sản phẩm mới thất bại!";
        public static string Err_CreateProductImage = "Thêm hình ảnh sản phẩm mới thất bại!";
        public static string Err_CreateProductSize = "Thêm size sản phẩm mới thất bại!";
        public static string SoldOut = "Hết hàng";
    }
}