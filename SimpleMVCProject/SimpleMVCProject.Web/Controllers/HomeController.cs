using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SimpleMVCProject.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public string Hello() => "Hello from ASP.NET MVC";

        public string Gretting(string name) => HtmlEncoder.Default.Encode($"Hello, {name}");
        public string Gretting2(int id) => HtmlEncoder.Default.Encode($"Hello, {id}");
    }
}
