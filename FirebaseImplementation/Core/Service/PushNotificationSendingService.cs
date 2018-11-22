using Core.Models;
using Firebase.Models;
using Firebase.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Service
{
    public class PushNotificationSendingService : IPushNotificationSendingService
    {
        private readonly IFirebaseSendPushNotification _firebaseSendPushNotification;

        public PushNotificationSendingService()
        {
            _firebaseSendPushNotification = new FirebaseSendPushNotification();
        }

        public async Task<List<PushNotificationResultDto>> SendPushNotificationToUsers(PushNotificationSendingDto message)
        {
            var pushNotificationMessage = new PushNotificationMessage
            {
                RegistrationIds = message.UsersTokens,
                Title = message.Title,
                Body = message.Body,
                TimeToLive = message.TimeToLive
            };

            var result = await _firebaseSendPushNotification.Send(pushNotificationMessage);

            List<PushNotificationResultDto> notificationResult = result.Select(x => new PushNotificationResultDto { Status = x.Status.ToString() }).ToList();

            return notificationResult;
        }
    }
}
