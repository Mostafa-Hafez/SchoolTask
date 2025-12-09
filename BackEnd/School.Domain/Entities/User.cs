using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    
    public class User
    {   
        public int Id { get; set; }
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;

        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<Student> Students { get; set; } = new List<Student>();

    }
    
}
