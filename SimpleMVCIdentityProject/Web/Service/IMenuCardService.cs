using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Service
{
    public interface IMenuCardService
    {
        Task AddMenuAsync(Menu menu);
        Task DeleteMenuAsync(int id);
        Task<Menu> GetMenuByIdAsync(int id);
        Task<IEnumerable<MenuCard>> GetMenuCardsAsync();
        Task<IEnumerable<Menu>> GetMenusAsync();
        Task UpdateMenuAsync(Menu menu);
    }
}
