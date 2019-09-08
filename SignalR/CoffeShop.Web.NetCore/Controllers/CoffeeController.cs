using CoffeShop.Web.NetCore.Hubs;
using CoffeShop.Web.NetCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CoffeShop.Web.NetCore.Controllers
{
    [Route("[controller]")]
    public class CoffeeController : Controller
    {
        private readonly IHubContext<CoffeeHub> _coffeeHub;

        public CoffeeController(IHubContext<CoffeeHub> coffeeHub)
        {
            _coffeeHub = coffeeHub;
        }

        [HttpPost]
        public async Task<IActionResult> OrderCoffee([FromBody] Order order)
        {
            await _coffeeHub.Clients.All.SendAsync("NewOrder", order);
            return Accepted(1);
        }
    }
}
