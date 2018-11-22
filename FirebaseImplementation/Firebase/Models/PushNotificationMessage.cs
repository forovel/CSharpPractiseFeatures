using System.Collections.Generic;

namespace Firebase.Models
{
    public class PushNotificationMessage
    {
        public List<string> RegistrationIds { get; set; }
        public string TargetAppType { get; set; }
        public int? TimeToLive { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public object Data { get; set; }
    }
}
