using Microsoft.AspNetCore.Mvc;
using SimpleMVCProject.Web.Models;
using System;

namespace SimpleMVCProject.Web.Controllers
{
    public class ResultController : Controller
    {
        public IActionResult JsonDemo()
        {
            var menu = new Menu
            {
                Id = 1,
                Text = "Sandwich",
                Price = 12.90,
                Date = DateTime.Today,
                Category = "Main"
            };
            return Json(menu);
        }

        public IActionResult Image()
        {
            return File("~/images/cute-cat.jpg", "image/jpg");
        }
    }
}
