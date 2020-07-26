using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Controllers
{
    public class HomeController : Controller // To make it an MVC controller we inherit this class from Controller Class
    {
        public string Index()
        {
            return "Bookstore";
        }
    }
}
