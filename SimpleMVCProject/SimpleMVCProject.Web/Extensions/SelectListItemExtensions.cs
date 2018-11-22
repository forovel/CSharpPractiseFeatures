using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMVCProject.Web.Extensions
{
    public static class SelectListItemExtensions
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(this IDictionary<int, string> dict, int selectedId)
        {
            return dict.Select(item => new SelectListItem
            {
                Selected = item.Key == selectedId,
                Text = item.Value,
                Value = item.Key.ToString()
            });
        }
    }
}
