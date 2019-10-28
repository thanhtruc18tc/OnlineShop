using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace OnlineShop.Common.Base
{
    public class BaseController : Controller
    {
        public OnlineShopContext context = new OnlineShopContext();
        public int pageSize = 9;

        public void setMessage(string message)
        {
            TempData["Message"] = message;
        }
    }
}