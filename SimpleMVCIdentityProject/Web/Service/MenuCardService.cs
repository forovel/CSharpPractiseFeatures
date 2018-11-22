using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Context;
using Web.Migrations;
using Web.Models;

namespace Web.Service
{
    public class MenuCardService : IMenuCardService
    {
        private readonly PlannedMenusContext _context;

        public MenuCardService(PlannedMenusContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Menu>> GetMenusAsync()
        {
            await EnsureDatabaseCreatedAsync();
            var menus = _context.Menus.Include(m => m.MenuCard);
            return await menus.ToArrayAsync();
        }

        public async Task<IEnumerable<MenuCard>> GetMenuCardsAsync()
        {
            await EnsureDatabaseCreatedAsync();
            var menuCards = _context.MenuCards;
            return await menuCards.ToArrayAsync();
        }

        public async Task<Menu> GetMenuByIdAsync(int id)
        {
            return await _context.Menus.SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task AddMenuAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMenuAsync(Menu menu)
        {
            _context.Menus.Update(menu);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMenuAsync(int id)
        {
            var menu = await _context.Menus.SingleAsync(m => m.Id == id);
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync();
        }

        private async Task EnsureDatabaseCreatedAsync()
        {
            var init = new Seeder(_context);
            await init.CreateAndSeedDatabaseAsync();
        }
    }
}
