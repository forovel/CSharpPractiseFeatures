using Microsoft.AspNetCore.Mvc;
using SimpleMVCProject.Web.Models;
using System;
using System.Collections.Generic;
using SimpleMVCProject.Web.Extensions;

namespace SimpleMVCProject.Web.Controllers
{
    public class HtmlHelpersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SimpleHelper()
        {
            return View();
        }

        public IActionResult HelperWithMenu()
        {
            var menu = new MenuWithAttributes
            {
                Id = 1,
                Text = "Some text",
                Price = 6.9,
                Date = DateTime.Today,
                Category = "Main"
            };

            return View(menu);
        }

        public IActionResult HelperList()
        {
            var cars = new Dictionary<int, string>
            {
                { 1, "Red Bull Racing" },
                { 2, "McLaren" },
                { 3, "Mercedes" },
                { 4, "Ferrari" }
            };

            return View(cars.ToSelectListItems(4));
        }

        public IActionResult Display()
        {
            var menu = new MenuWithAttributes
            {
                Id = 1,
                Text = "Some text",
                Price = 6.9,
                Date = DateTime.Today,
                Category = "Main"
            };

            return View(menu);
        }
    }
}
