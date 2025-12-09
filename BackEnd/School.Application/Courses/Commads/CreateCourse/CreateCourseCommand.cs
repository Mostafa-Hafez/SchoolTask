using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Courses.Commads.CreateCourse
{
    public class CreateCourseCommand: IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
