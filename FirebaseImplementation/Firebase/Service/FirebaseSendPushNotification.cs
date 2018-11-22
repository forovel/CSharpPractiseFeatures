using FCM.Net;
using Firebase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Firebase.Service
{
    public class FirebaseSendPushNotification : IFirebaseSendPushNotification
    {
        public async Task<List<PushNotificationResult>> Send(PushNotificationMessage notificationMessage)
        {
            var serverKey = "AAAAJDAnq9A:APA91bFMJY1-PdAnAlplVqSMkqBWn_nytyQGWCyijutYi-8xM0gMLI7qC5av7QxPwkJu00uUZu7P4idPSvKBdPXh4bOU9k8_XHftI7MPlmYcMYv5T-P6p4-hunLQgsLd-x-DwCkq89Kl";

            using (var sender = new Sender(serverKey))
            {
                var message = new Message
                {
                    RegistrationIds = notificationMessage.RegistrationIds,
                    Notification = new Notification
                    {
                        Title = notificationMessage.Title,
                        Body = notificationMessage.Body
                    },
                    TimeToLive = notificationMessage.TimeToLive,
                    Data = notificationMessage.Data
                };

                var result = await sender.SendAsync(message);

                if (result.StatusCode != HttpStatusCode.OK)
                {
                    throw new ArgumentException(result.MessageResponse.InternalError);
                }

                return result.MessageResponse.Results
                    .Select(x => GeneratePushNotificationResult(x.RegistrationId, x.Error))
                    .ToList();
            }
        }

        private PushNotificationResult GeneratePushNotificationResult(string registrationId, string error)
        {
            PushNotificationStatus status;

            switch (error)
            {
                case "InvalidPackageName":
                case "MismatchSenderId":
                case "InvalidParameters":
                case "MessageTooBig":
                case "InvalidDataKey":
                case "InvalidTtl":
                case "Unavailable":
                case "InternalServerError":
                case "InvalidAppsCredential":
                    throw new ArgumentException(error);

                case "MissingRegistration":
                case "InvalidRegistration":
                case "NotRegistered":
                    status = PushNotificationStatus.Failure;
                    break;

                default:
                    status = PushNotificationStatus.Success;
                    break;
            }

            return new PushNotificationResult
            {
                RegistrationId = registrationId,
                Status = status
            };
        }
    }
}
