using System;
using System.Collections.Generic;

namespace SimpleMVCProject.Web.Models
{
    public class EventsAndMenusContext
    {
        private IEnumerable<Event> _events = null;
        public IEnumerable<Event> Events
        {
            get => _events ?? (_events = GetEvents());
        }

        private IEnumerable<Menu> _menus = null;
        public IEnumerable<Menu> Menus
        {
            get => _menus ?? (_menus = GetMenus());
        }

        private IEnumerable<Event> GetEvents()
        {
            return new List<Event>
            {
                new Event(1, "Formula 1 G.P. Australia, Melbourne", new DateTime(2018, 3, 25)),
                new Event(2, "Formula 1 G.P. Bahrain, Sakhir", new DateTime(2018, 4, 8)),
                new Event(3, "Formula 1 G.P. China, Shanghai", new DateTime(2018, 4, 15)),
                new Event(4, "Formula 1 G.P. Aserbaidschan, Baku", new DateTime(2018, 4, 29))
            };
        }

        private IEnumerable<Menu> GetMenus()
        {
            return new List<Menu>
            {
                new Menu
                {
                    Id = 1,
                    Text = "Sandwich",
                    Price = 12.90,
                    Category = "Main"
                },
                new Menu
                {
                    Id = 2,
                    Text = "Sandwich1",
                    Price = 15.90,
                    Category = "Vegetarian"
                },
                new Menu
                {
                    Id = 3,
                    Text = "Sandwich2",
                    Price = 13.90,
                    Category = "Main"
                }
            };
        }

    }
}
