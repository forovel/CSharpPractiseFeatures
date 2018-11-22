using Core.Models;
using Core.Service;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WriteMessageConsole.Service
{
    public class WriteFromConsoleService
    {
        private readonly IPushNotificationSendingService _pushNotificationSendingService;

        public WriteFromConsoleService()
        {
            _pushNotificationSendingService = new PushNotificationSendingService();
        }

        public async Task WriteToUsers()
        {
            bool writeIds = true;
            bool timeToLive = true;
            TimeSpan correctTime;
            var message = new PushNotificationSendingDto();

            Console.WriteLine("Write id/ids of user/s: (if you want to finish write ids write enought)");
            message.UsersTokens = new List<string>();
            while (writeIds)
            {
                var id = Console.ReadLine();
                if (id == "enought")
                {
                    writeIds = false;
                    break;
                }
                message.UsersTokens.Add(id);
            }
            Console.WriteLine("--------------------------------");

            Console.WriteLine("Write title of notification");
            message.Title = Console.ReadLine();
            Console.WriteLine("--------------------------------");

            Console.WriteLine("Write information which should placed in notification");
            message.Body = Console.ReadLine();
            Console.WriteLine("--------------------------------");

            Console.WriteLine("Write how much time should notification live (example '00:15:00') means 15 minutes");
            while (timeToLive)
            {
                var time = Console.ReadLine();

                if (TimeSpan.TryParse(time, out correctTime))
                {
                    timeToLive = false;
                    message.TimeToLive = (int)correctTime.TotalSeconds;
                }
                else
                {
                    Console.WriteLine("try again enter the time");
                }
            }
            Console.WriteLine("-----------------");

            Console.WriteLine("Sending message/s...");
            var results = await _pushNotificationSendingService.SendPushNotificationToUsers(message);
            foreach (var result in results)
            {
                Console.WriteLine(result.Status);
            }

            Console.ReadLine();
        }
    }
}
