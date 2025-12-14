using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  string  Email { get; set; } 
        public int ClassId { get; set; }

        public int? UserId { get; set; }
        // Navigation
        public  Class? Class { get; set; }
        public User? User { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; } =  new List<Enrollment>();
    }
}
