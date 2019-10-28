using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ErrorController : Controller
    {
        // GET: NotFound
        public ActionResult Index()
        {
            return View("Error");
        }
    }
}