using Microsoft.AspNetCore.Mvc;
using SimpleMVCProject.Web.Models;
using System;
using System.Collections.Generic;

namespace SimpleMVCProject.Web.Controllers
{
    public class TagHelpersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LabelHelper()
        {
            return View(GetSampleMenus());
        }

        public IActionResult InputHelper()
        {
            return View(GetSampleMenu());
        }

        public IActionResult FormHelper()
        {
            return View(GetSampleMenus());
        }

        [HttpPost]
        public IActionResult FormHelper(MenuWithAttributes model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View("ValidationHelperResult", model);
        }

        public IActionResult EnvironmentHelper()
        {
            return View();
        }

        public IActionResult Markdown()
        {
            return View();
        }

        public IActionResult MarkdownAttribute()
        {
            return View();
        }

        public IActionResult CustomTable()
        {
            return View(GetSampleMenus());
        }

        private IList<MenuWithAttributes> GetSampleMenus() =>
            new List<MenuWithAttributes>
            {
                new MenuWithAttributes
                {
                    Id = 1,
                    Text = "Schweinsbraten mit Knödel und Sauerkraut",
                    Price = 8.5,
                    Date = new DateTime(2018, 10, 5),
                    Category = "Main"
                },
                new MenuWithAttributes
                {
                    Id = 2,
                    Text = "Erdäpfelgulasch mit Tofu und Gebäck",
                    Price = 8.5,
                    Date = new DateTime(2018, 10, 6),
                    Category = "Vegetarian"
                },
                new MenuWithAttributes
                {
                    Id = 3,
                    Text = "Tiroler Bauerngröst'l mit Spiegelei und Krautsalat",
                    Price = 8.5,
                    Date = new DateTime(2018, 10, 7),
                    Category = "Vegetarian"
                }
            };

        private MenuWithAttributes GetSampleMenu() =>
          new MenuWithAttributes
          {
              Id = 1,
              Text = "Schweinsbraten mit Knödel und Sauerkraut",
              Price = 6.9,
              Date = new DateTime(2018, 10, 5),
              Category = "Main"
          };
    }
}
