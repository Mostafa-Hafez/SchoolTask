using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Courses.Commads.DeleteCourse
{
    public record DeleteClassCommand(int Id) : IRequest<bool>;

}
