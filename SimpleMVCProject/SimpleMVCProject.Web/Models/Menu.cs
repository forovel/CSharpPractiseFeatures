using System;

namespace SimpleMVCProject.Web.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }
    }
}
