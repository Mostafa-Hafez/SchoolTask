using Microsoft.EntityFrameworkCore;
using School.Application.Interfaces;
using School.Domain.ChatEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastructure.Persistence
{
    public class ChatDbContext:DbContext ,IChatDbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options ):base(options)  
        {
            
        }

        public DbSet<ChatMessage> ChatMessages { get; set; }
    }
}
