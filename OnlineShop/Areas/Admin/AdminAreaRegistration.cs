using System.Web.Mvc;

namespace OnlineShop.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            
            // MARK: HomeController
            context.MapRoute(
                "Admin_Home",
                "admin",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "OnlineShop.Areas.Admin.Controllers" }
            );

            // MARK: AccountController
            context.MapRoute(
                "Admin_Account",
                "admin/account",
                new { controller = "Account", action = "Index", id = UrlParameter.Optional },
                new[] { "OnlineShop.Areas.Admin.Controllers" }
            );

            // MARK: AccountController
            context.MapRoute(
                "Admin_Orders",
                "admin/orders",
                new { controller = "Orders", action = "Index", id = UrlParameter.Optional },
                new[] { "OnlineShop.Areas.Admin.Controllers" }
            );

            // MARK: Default
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "OnlineShop.Areas.Admin.Controllers" }
            );
        }
    }
}