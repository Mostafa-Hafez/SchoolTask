using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Students.Commans.CreateStudent
{
    public class CreateStudentCommand  : IRequest<int>
   {
        public string Name { get; set; }
        public string Email { get; set; }
        public int ClassId { get; set; }
        public int UserId { get; set; }
    }
}
