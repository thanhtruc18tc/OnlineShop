using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Model.EF;

namespace OnlineShop.Common.Base
{
    public class AdminBaseController : Controller
    {
        public OnlineShopContext context = new OnlineShopContext();
        public int pageSize = 9;
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (User)Session[Constants.Constants.USER_SESSION];
            if ((session == null) || (!(bool)session.isAdmin))
            {
                filterContext.Result = new RedirectResult("~/account/login");
            } 
            base.OnActionExecuted(filterContext);
        }
    }
}