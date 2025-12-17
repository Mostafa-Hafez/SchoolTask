using Microsoft.EntityFrameworkCore;
using School.Application.Interfaces;
using School.Domain.ChatEntities;
using School.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChatDbContext _chatcontext;
            
        public ChatRepository(ChatDbContext chatcontext )
        {
            _chatcontext = chatcontext;
        }
        public async Task AddMessageAsync(ChatMessage message)
        {
            _chatcontext.ChatMessages.Add(message);
            await _chatcontext.SaveChangesAsync();
        }

        public async Task<List<ChatMessage>> GetConversation(int user1, int user2)
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
