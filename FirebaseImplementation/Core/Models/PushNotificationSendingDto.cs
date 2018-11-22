using System.Collections.Generic;

namespace Core.Models
{
    public class PushNotificationSendingDto
    {
        public List<string> UsersTokens { get; set; }
        public int? TimeToLive { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
