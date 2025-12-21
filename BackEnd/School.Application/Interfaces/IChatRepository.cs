using School.Application.DTOs.ChatDTOs;
using School.Domain.ChatEntities;

namespace School.Application.Interfaces
{
    public interface IChatRepository
    {
        Task AddMessageAsync(ChatMessage message);
        Task<List<ChatMessage>> GetConversation(int user1, int user2);

        Task<List<GetContactsDto>> GetContacts(int userid); 
    }
}
