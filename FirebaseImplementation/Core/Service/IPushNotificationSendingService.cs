using Core.Models;
using Firebase.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IPushNotificationSendingService
    {
        Task<List<PushNotificationResultDto>> SendPushNotificationToUsers(PushNotificationSendingDto message);
    }
}
