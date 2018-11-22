using Microsoft.AspNetCore.Mvc;
using SimpleMVCProject.Web.Models;
using System;
using System.Collections.Generic;

namespace SimpleMVCProject.Web.Controllers
{
    public class ViewsDemoController : Controller
    {
        private readonly EventsAndMenusContext _eventsAndMenusContext;

        public ViewsDemoController(EventsAndMenusContext eventsAndMenusContext)
        {
            _eventsAndMenusContext = eventsAndMenusContext;
        }

        public IActionResult InjectServiceInView()
        {
            return View();
        }

        public IActionResult UsePartialView()
        {
            return View(_eventsAndMenusContext);
        }

        public IActionResult UseViewComponent()
        {
            return View();
        }

        public IActionResult UseViewComponent1()
        {
            return View();
        }

        public IActionResult Index()
        {
            ViewBag.Name = "Test view bag";
            return View();
        }

        public IActionResult PassingModel()
        {
            var listMenu = new List<Menu>
            {
                new Menu
                {
                    Id = 1,
                    Text = "Sandwich",
                    Price = 12.90,
                    Date = DateTime.Today,
                    Category = "Main"
                },
                new Menu
                {
                    Id = 2,
                    Text = "Sandwich1",
                    Price = 15.90,
                    Date = DateTime.Today,
                    Category = "Vegetarian"
                },
                new Menu
                {
                    Id = 3,
                    Text = "Sandwich2",
                    Price = 13.90,
                    Date = DateTime.Today,
                    Category = "Main"
                }
            };

            return View(listMenu);
        }

        public IActionResult LayoutUsingSections()
        {
            return View();
        }
    }
}
