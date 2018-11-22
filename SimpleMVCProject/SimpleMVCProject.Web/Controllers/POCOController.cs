using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SimpleMVCProject.Web.Controllers
{
    public class POCOController
    {
        public string Index() => "this is POCO Controller";

        [ActionContext]
        public ActionContext ActionContext { get; set; }

        public HttpContext HttpContext => ActionContext.HttpContext;

        public ModelStateDictionary ModelState => ActionContext.ModelState;

        public string UserAgentInfo()
        {
            if (HttpContext.Request.Headers.ContainsKey("User-Agent"))
            {
                return HttpContext.Request.Headers["User-Agent"];
            }
            return "On user agent information";
        }
    }
}
