using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using School.Application.Interfaces;
using School.Domain.ChatEntities;
using System.Security.Claims;

namespace School.API.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IChatRepository _chatRepository;
        private readonly IStudentRepository _studentRepo;
        private readonly IFirebaseNotificationService _firebaseNotification;

        public ChatHub(IChatRepository chatRepository, IStudentRepository studentRepo, IFirebaseNotificationService firebaseNotification)
        {
            _chatRepository = chatRepository;
            _studentRepo = studentRepo;
            _firebaseNotification = firebaseNotification;
        }
        public async Task SendMessage(int receiverId, string message)
        {
            var senderId = int.Parse(Context.User?
            .FindFirst(ClaimTypes.NameIdentifier)?.Value);


            var chatMessage = new ChatMessage
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Message = message
            };

            await _chatRepository.AddMessageAsync(chatMessage);

            ;

            await Clients.User(receiverId.ToString()).SendAsync("ReceiveMessage", chatMessage);
            await Clients.User(senderId.ToString()).SendAsync("ReceiveMessage", chatMessage);
            var receiver = await _studentRepo.GetByIdAsync(receiverId);

            if (!string.IsNullOrEmpty(receiver?.FirebaseDeviceToken))
            {
                await _firebaseNotification.SendNotificatioAsync(
                    receiver.FirebaseDeviceToken,
                    "New Message",
                    message
                );
            }
        }
    }
}
