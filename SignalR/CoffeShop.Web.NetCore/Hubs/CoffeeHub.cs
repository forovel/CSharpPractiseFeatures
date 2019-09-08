using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace CoffeShop.Web.NetCore.Hubs
{
    public class CoffeeHub : Hub
    {
        public async Task GetUpdateForOrder(long orderId)
        {
            await Clients.Caller.SendAsync("ReceiveOrderUpdate", "Steaming");
            Thread.Sleep(2000);

            await Clients.Caller.SendAsync("ReceiveOrderUpdate", "Quality Controll");
            Thread.Sleep(2000);

            await Clients.Caller.SendAsync("ReceiveOrderUpdate", "Testing on humans");
            Thread.Sleep(2000);

            await Clients.Caller.SendAsync("ReceiveOrderUpdate", "Finished");
        }
    }
}
