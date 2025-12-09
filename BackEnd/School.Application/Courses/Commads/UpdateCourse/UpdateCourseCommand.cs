using MediatR;

namespace School.Application.Courses.Commads.UpdateCourse
{
    public class UpdateCourseCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
    }
}
