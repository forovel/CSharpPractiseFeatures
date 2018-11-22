using Microsoft.AspNetCore.Http;
using SimpleCoreServer.Web.Extensions;
using SimpleCoreServer.Web.Services;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCoreServer.Web.Controllers
{
    public class HomeController
    {
        private readonly ISimpleService _simpleService;

        public HomeController(ISimpleService simpleService)
        {
            _simpleService = simpleService;
        }

        public async Task Index(HttpContext context)
        {
            var sb = new StringBuilder();
            sb.Append("<ul>");
            sb.Append(string.Join(string.Empty,
              _simpleService.GetSamples().Select(s => s.Li()).ToArray()));
            sb.Append("</ul>");
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync(sb.ToString());
        }
    }
}
