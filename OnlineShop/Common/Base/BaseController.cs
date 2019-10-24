using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Model.EF;

namespace OnlineShop.Common.Base
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (User)Session[Constants.Constants.USER_SESSION];
            if ((session == null) || (!(bool)session.admin))
            {
                filterContext.Result = new RedirectResult("~/Account/_Login");
            } 
            base.OnActionExecuted(filterContext);
        }
    }
}