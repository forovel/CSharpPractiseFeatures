using Firebase;
using Firebase.Models;
using Firebase.Service;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UnitTests.Firebase
{
    [TestFixture]
    public class FirebaseSendPushNotificationTests
    {
        private IFirebaseSendPushNotification _firebaseSendPushNotification;

        [OneTimeSetUp]
        public void Settings()
        {
            _firebaseSendPushNotification = new FirebaseSendPushNotification();
        }

        [Test]
        public async Task Should_ReturnSuccess_When_SendingMessageWithoutData()
        {
            var message = new PushNotificationMessage()
            {
                RegistrationIds = new List<string>()
                {
                   "Insert Token Id"
                },
                Title = "Some title",
                Body = "Some body",
                TimeToLive = 100,
                TargetAppType = "TestApp"
            };

            var result = await _firebaseSendPushNotification.Send(message);

            Assert.AreEqual(PushNotificationStatus.Success, result[0].Status);
        }

        [Test]
        public async Task Should_ReturnSuccess_When_SendingMessageWithoutTargetApp()
        {
            var message = new PushNotificationMessage()
            {
                RegistrationIds = new List<string>()
                {
                   "Insert Token Id"
                },
                Title = "Some title",
                Body = "Some body",
                TimeToLive = 100,
                Data = new { data = "data" }
            };

            var result = await _firebaseSendPushNotification.Send(message);

            Assert.AreEqual(PushNotificationStatus.Success, result[0].Status);
        }

        [Test]
        public async Task Should_ReturnSuccess_When_SendingMessageWithoutTimeToLive()
        {
            var message = new PushNotificationMessage()
            {
                RegistrationIds = new List<string>()
                {
                   "Insert Token Id"
                },
                Title = "Some title",
                Body = "Some body",
                TargetAppType = "TestApp",
                Data = new { data = "data" }
            };

            var result = await _firebaseSendPushNotification.Send(message);

            Assert.AreEqual(PushNotificationStatus.Success, result[0].Status);
        }

        [Test]
        public async Task Should_ReturnSuccess_When_SendingMessageWithoutBody()
        {
            var message = new PushNotificationMessage()
            {
                RegistrationIds = new List<string>()
                {
                   "Insert Token Id"
                },
                Title = "Some title",
                TimeToLive = 100,
                TargetAppType = "TestApp",
                Data = new { data = "data" }
            };

            var result = await _firebaseSendPushNotification.Send(message);

            Assert.AreEqual(PushNotificationStatus.Success, result[0].Status);
        }

        [Test]
        public async Task Should_ReturnSuccess_When_SendingMessageWithoutTitle()
        {
            var message = new PushNotificationMessage()
            {
                RegistrationIds = new List<string>()
                {
                   "Insert Token Id"
                },
                Body = "Some body",
                TimeToLive = 100,
                TargetAppType = "TestApp",
                Data = new { data = "data" }
            };

            var result = await _firebaseSendPushNotification.Send(message);

            Assert.AreEqual(PushNotificationStatus.Success, result[0].Status);
        }

        [Test]
        public async Task Should_ReturnFailure_When_SendingMessageWithoutRegistrationIds()
        {
            var message = new PushNotificationMessage()
            {
                Body = "Some body",
                TimeToLive = 100,
                TargetAppType = "TestApp",
                Data = new { data = "data" }
            };

            var result = await _firebaseSendPushNotification.Send(message);

            Assert.AreEqual(PushNotificationStatus.Failure, result[0].Status);
        }
    }
}
