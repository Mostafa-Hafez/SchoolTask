using FirebaseAdmin.Messaging;
using School.Application.Interfaces;

namespace School.Infrastructure.Services
{
    public class FirebaseNotificationService : IFirebaseNotificationService
    {
        public async Task SendNotificatioAsync(string deviceToken, string title, string body)
        {
            var message = new Message
            {
                Token = deviceToken,
                Notification = new Notification
                {
                    Title = title,
                    Body = body
                }
            };

            await FirebaseMessaging.DefaultInstance.SendAsync(message);
        }
    }
}
