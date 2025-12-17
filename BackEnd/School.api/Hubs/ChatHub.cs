using Microsoft.AspNetCore.SignalR;
using School.Application.Interfaces;
using School.Domain.ChatEntities;
using System.Security.Claims;

namespace School.API.Hubs
{
    public class ChatHub:Hub
    {
        private readonly IChatRepository _chatRepository;
        private readonly IFirebaseNotificationService _firebaseNotification;

        public ChatHub(IChatRepository chatRepository , IFirebaseNotificationService  firebaseNotification)
        {
            _chatRepository = chatRepository;
            _firebaseNotification = firebaseNotification;
        }
        public async Task SendMessage(int receiverId, string message )
        {
            var senderId = int.Parse(
                Context.User!.FindFirst(ClaimTypes.NameIdentifier)!.Value
            );

            var chatMessage = new ChatMessage
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Message = message
            };

            await _chatRepository.AddMessageAsync(chatMessage);

            
            await Clients.User(receiverId.ToString())
                .SendAsync("ReceiveMessage", senderId, message);
            
        }
    }
}
