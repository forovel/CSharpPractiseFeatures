using Microsoft.AspNetCore.Mvc;
using SimpleMVCProject.Web.Models;
using System;
using System.Threading.Tasks;

namespace SimpleMVCProject.Web.Controllers
{
    public class SubmitDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateMenu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMenu(int id, string text, double price, DateTime date, string category)
        {
            var m = new Menu { Id = id, Text = text, Price = price, Date = date, Category = category };
            ViewBag.Info = $"menu created: {m.Text}, Price: {m.Price}, date: {m.Date.ToShortDateString()}, category: {m.Category}";

            return View("Index");
        }

        public IActionResult CreateMenu2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMenu2(Menu menu)
        {
            ViewBag.Info = $"menu created: {menu.Text}, Price: {menu.Price}, date: {menu.Date.ToShortDateString()}, category: {menu.Category}";

            return View("Index");
        }

        public IActionResult CreateMenu3()
        {
            return View();
        }

        [HttpPost]
        [ActionName("CreateMenu3")]
        public async Task<IActionResult> CreateMenu3Result()
        {
            var model = new Menu();
            bool updated = await TryUpdateModelAsync<Menu>(model);
            if (updated)
            {
                ViewBag.Info = $"menu created: {model.Text}, Price: {model.Price}, date: {model.Date.ToShortDateString()}, category: {model.Category}";
            }

            return View("Error");
        }

        public IActionResult CreateMenu4()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMenu4(MenuWithAttributes model)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Info = $"menu created: {model.Text}, Price: {model.Price}, date: {model.Date.ToShortDateString()}, category: {model.Category}";
                return View();
            }

            return View("Error");
        }
    }
}
