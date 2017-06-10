using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkShortener.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string id)
        {
            if (string.IsNullOrEmpty(id)) return HttpNotFound("Link is invalid");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}