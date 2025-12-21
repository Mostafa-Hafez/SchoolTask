using Microsoft.EntityFrameworkCore;
using School.Application.DTOs.ChatDTOs;
using School.Application.Interfaces;
using School.Domain.ChatEntities;
using School.Infrastructure.Persistence;

namespace School.Infrastructure.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChatDbContext _chatcontext;
        private readonly SchoolDbContext _schoolDb;

        public ChatRepository(ChatDbContext chatcontext, SchoolDbContext schoolDb)
        {
            _chatcontext = chatcontext;
            _schoolDb = schoolDb;
        }
        public async Task AddMessageAsync(ChatMessage message)
        {
            _chatcontext.ChatMessages.Add(message);
            await _chatcontext.SaveChangesAsync();
        }

        public async Task<List<GetContactsDto>> GetContacts(int userid)
        {
            var students =
             await _schoolDb.Students.
                Where(z => z.UserId != userid).
                Select(g => new GetContactsDto
                {
                    ContactId = g.Id,
                    ContextName = g.Name
                }).ToListAsync();
            return students;
        }

        public async Task<List<ChatMessage>>    GetConversation(int user1, int user2)
        {
            return await _chatcontext.ChatMessages
            .Where(m =>
                (m.SenderId == user1 && m.ReceiverId == user2) ||
                (m.SenderId == user2 && m.ReceiverId == user1))
            .OrderBy(m => m.SentAt)
            .ToListAsync();
        }
    }
}
