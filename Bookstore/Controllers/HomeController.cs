using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using Bookstore.Models;

namespace Bookstore.Controllers
{
    public class HomeController : Controller // To make it an MVC controller we inherit this class from Controller Class
    {
        [ViewData]
        public string ViewAttribute1 { get; set; }
        [ViewData]
        public  string Title { get; set; }

        public ViewResult Index()
        {
            ViewBag.Title = "Welcome To My Bookstore";
            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "Shashwat";
            ViewBag.Data = data;

            ViewBag.BookDetails = new BookModel() { Id = 1, Author = "ABC", Language = "en" };

            ViewData["property"] = "BookStore";
            ViewData["book"] = new BookModel() { Id = 1, Author = "abcdfg", TotalPages = 34 };
            ViewAttribute1 = "Shashwat";
            Title = "Home page";
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

        public ViewResult Help()
        {
            return View();
        }

        public ViewResult Extra()
        {
            return View("Career");
        }
    }
}
