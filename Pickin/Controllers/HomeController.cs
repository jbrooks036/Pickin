using Pickin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Pickin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            // 1. Create or Get a list of things
            List<string> my_list = new List<string>();
            my_list.Add("One");
            my_list.Add("Two");
            my_list.Add("Three");

            ViewBag.SomeData = my_list;

            return View(my_list);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}