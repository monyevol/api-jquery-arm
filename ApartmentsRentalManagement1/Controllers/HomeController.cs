using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApartmentsRentalManagement1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About Us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Title = "Contact Us";

            return View();
        }

        public ActionResult CentralPoint()
        {
            ViewBag.Title = "Central Point";

            return View();
        }
    }
}
