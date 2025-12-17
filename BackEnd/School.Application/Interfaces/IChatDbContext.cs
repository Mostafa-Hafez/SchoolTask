using Microsoft.EntityFrameworkCore;
using School.Domain.ChatEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Interfaces
{
    public interface IChatDbContext
    {
        public DbSet<ChatMessage> ChatMessages { get; }
    }
}
