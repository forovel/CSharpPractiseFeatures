using Microsoft.AspNetCore.Mvc;
using SimpleMVCProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMVCProject.Web.Components
{
    public class EventListViewComponent : ViewComponent
    {
        private readonly EventsAndMenusContext _eventsAndMenusContext;

        public EventListViewComponent(EventsAndMenusContext eventsAndMenusContext)
        {
            _eventsAndMenusContext = eventsAndMenusContext;
        }

        public Task<IViewComponentResult> InvokeAsync(DateTime from, DateTime to)
        {
            return Task.FromResult<IViewComponentResult>(View(EventsByDateRange(from, to)));
        }

        private IEnumerable<Event> EventsByDateRange(DateTime from, DateTime to)
        {
            return _eventsAndMenusContext.Events.Where(e => e.Day >= from && e.Day <= to);
        }
    }
}
