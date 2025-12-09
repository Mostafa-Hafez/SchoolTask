using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Courses.Commads.UpdateCourse
{
    public record UpdateClassCommand(int Id,string Name,string TeacherName) : IRequest<bool>;

}
