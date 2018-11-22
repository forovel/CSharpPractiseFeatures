using Firebase.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Firebase.Service
{
    public interface IFirebaseSendPushNotification
    {
        Task<List<PushNotificationResult>> Send(PushNotificationMessage notificationMessage);
    }
}
