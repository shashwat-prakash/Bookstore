using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using Bookstore.Models;
using Microsoft.Extensions.Configuration;
using Bookstore.Service;

namespace Bookstore.Controllers
{
    public class HomeController : Controller // To make it an MVC controller we inherit this class from Controller Class
    {
        [ViewData]
        public string ViewAttribute1 { get; set; }
        [ViewData]
        public  string Title { get; set; }

        private IConfiguration _configuration { get; }
        public IUserService _userService { get; }

        public HomeController(IConfiguration configuration, IUserService userService)
        {
            _configuration = configuration;
            _userService = userService;
        }
        public ViewResult Index()
        {
            // var appName = _configuration["ApplicationName"];

            var userId = _userService.GetUserId();
            var isLoggedIn = _userService.IsAuthenticated();
            return View();
        }

        [Route("about-us", Name = "about-us")]
        [HttpGet]
        public ViewResult About()
        {
            var ModelObj = new { Id= 1, Name="Shashwat" };
            return View(ModelObj);
        }

        [HttpGet("contact-us")]
        public ViewResult ContactUs()
        {
            return View();
            /*return View("~/TempViews/Index.cshtml");*/
            /* return View("../../TempViews/Index");*/

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
