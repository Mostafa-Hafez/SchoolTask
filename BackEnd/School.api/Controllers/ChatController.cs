using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using School.API.DTOs;
using School.API.Extentions;
using School.API.Hubs;
using School.Application.Interfaces;
using School.Domain.ChatEntities;
using System.Security.Claims;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Student")]
    public class ChatController : ControllerBase
    {
        private readonly IChatRepository _chatRepo;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IStudentRepository _studentrepo;
        private readonly IFirebaseNotificationService _firebaseNotificationService;

        public ChatController(IChatRepository chatRepo, IHubContext<ChatHub> hubContext,
            IStudentRepository studentrepo, IFirebaseNotificationService firebaseNotificationService)
        {
            _chatRepo = chatRepo;
            _hubContext = hubContext;
            _studentrepo = studentrepo;
            _firebaseNotificationService = firebaseNotificationService;
        }
        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendChatMessageDto dto)
        {
            var senderId = int.Parse(User.FindFirstValue("UId")!);



            var message = new ChatMessage
            {
                SenderId = senderId,
                ReceiverId = dto.ReceiverId,
                Message = dto.Message,
                SentAt = DateTime.UtcNow
            };

            await _chatRepo.AddMessageAsync(message);


            await _hubContext.Clients
                .User(dto.ReceiverId.ToString())
                .SendAsync("ReceiveMessage", new
                {
                    message.Id,
                    message.SenderId,
                    message.ReceiverId,
                    message.Message,
                    message.SentAt
                });
            var receiver = await _studentrepo.GetByIdAsync(dto.ReceiverId);

            if (!string.IsNullOrEmpty(receiver?.FirebaseDeviceToken))
            {
                await _firebaseNotificationService.SendNotificatioAsync(
                    receiver.FirebaseDeviceToken,
                    "New Message",
                    message.Message
                );
            }

            return this.ToSuccessResult(data: message);
        }


        [HttpGet("Getconversation")]
        public async Task<IActionResult> GetConversation(int recieverid)
        {
            var userId = int.Parse(User.FindFirstValue("UId")!);

            var messages = await _chatRepo.GetConversation(userId, recieverid);

            return this.ToSuccessResult(data: messages);
        }

        [HttpGet("chat-list")]
        public async Task<IActionResult> GetChatList()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            return this.ToSuccessResult(await _chatRepo.GetContacts(userId));
        }
    }
}
