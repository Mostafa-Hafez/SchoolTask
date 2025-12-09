using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string TeacherName { get; set; } = default!;

        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
