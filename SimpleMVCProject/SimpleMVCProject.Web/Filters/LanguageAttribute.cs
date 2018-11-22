using Microsoft.AspNetCore.Mvc.Filters;

namespace SimpleMVCProject.Web.Filters
{
    public class LanguageAttribute : ActionFilterAttribute
    {
        private string _laguage = null;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _laguage = context.RouteData.Values["language"]?.ToString();
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {

        }
    }
}
