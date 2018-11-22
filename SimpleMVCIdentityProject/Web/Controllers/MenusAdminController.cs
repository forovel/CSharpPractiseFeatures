using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using Web.Models;
using Web.Service;

namespace Web.Controllers
{
    public class MenusAdminController : Controller
    {
        private readonly IMenuCardService _menuCardService;

        public MenusAdminController(IMenuCardService menuCardService)
        {
            _menuCardService = menuCardService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _menuCardService.GetMenusAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _menuCardService.GetMenuByIdAsync(id.Value);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        public async Task<IActionResult> Create()
        {
            var cards = await _menuCardService.GetMenuCardsAsync();
            ViewBag.MenuCardId = new SelectList(cards, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text,Price,Active,Order,Type,Day,MenuCardId")] Menu menu)
        {
            if (ModelState.IsValid)
            {
                await _menuCardService.AddMenuAsync(menu);
                return RedirectToAction(nameof(Index));
            }
            var cards = await _menuCardService.GetMenuCardsAsync();
            ViewBag.MenuCardId = new SelectList(cards, "Id", "Name", menu.MenuCardId);
            return View(menu);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _menuCardService.GetMenuByIdAsync(id.Value);
            if (menu == null)
            {
                return NotFound();
            }
            var cards = await _menuCardService.GetMenuCardsAsync();
            ViewBag.MenuCardId = new SelectList(cards, "Id", "Name", menu.MenuCardId);
            return View(menu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Text,Price,Active,Order,Type,Day,MenuCardId")] Menu menu)
        {
            if (id != menu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _menuCardService.UpdateMenuAsync(menu);
                return RedirectToAction(nameof(Index));
            }
            var cards = await _menuCardService.GetMenuCardsAsync();
            ViewBag.MenuCardId = new SelectList(cards, "Id", "Name", menu.MenuCardId);
            return View(menu);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var menu = await _menuCardService.GetMenuByIdAsync(id.Value);
            if (menu == null)
            {
                return NotFound();
            }

            return View(menu);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var menu = await _menuCardService.GetMenuByIdAsync(id);
            await _menuCardService.DeleteMenuAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
