using System;

namespace SimpleMVCProject.Web.Models
{
    public class Event
    {
        public int Id { get; }
        public string Text { get; }
        public DateTime Day { get; }

        public Event(int id, string text, DateTime day)
        {
            Id = id;
            Text = text;
            Day = day;
        }
    }
}
