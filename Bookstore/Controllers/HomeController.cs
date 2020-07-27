using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class HomeController : Controller // To make it an MVC controller we inherit this class from Controller Class
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult About()
        {
            var ModelObj = new { Id= 1, Name="Shashwat" };
            return View(ModelObj);
        }

        public ViewResult ContactUs()
        {
            /*return View();*/
            /*return View("~/TempViews/Index.cshtml");*/
            return View("../../TempViews/Index");

        }

        public ViewResult Extra()
        {
            return View("Career");
        }
    }
}
