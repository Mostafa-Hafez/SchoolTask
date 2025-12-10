using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.API.Extentions;
using School.Application.Courses.Commads.CreateCourse;
using School.Application.Courses.Commads.DeleteCourse;
using School.Application.Courses.Commads.UpdateCourse;
using School.Application.Courses.Queries.GetClassById;
using School.Application.Courses.Queries.GetClasses;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCourseCommand command)
        {
            var id = await _mediator.Send(command);
            return this.ToSuccessResult(data: new { Id = id });
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCourseCommand command)
        {
            if (id != command.Id) return this.ToErrorResult(code: System.Net.HttpStatusCode.BadRequest, errors: new[] { "Id mismatch" });
            var result = await _mediator.Send(command);
            return result ? this.ToSuccessResult(code: System.Net.HttpStatusCode.OK, data: result) : this.ToErrorResult(code: System.Net.HttpStatusCode.NotFound, errors: new[] { "Not Found!" });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCourseCommand(id));
            return result ? this.ToSuccessResult(code: System.Net.HttpStatusCode.OK, data: result) : this.ToErrorResult(code: System.Net.HttpStatusCode.NotFound, errors: new[] { "Not Found!" });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var course = await _mediator.Send(new GetCourseByIdQuery(id));
            if (course == null) return this.ToErrorResult(code: System.Net.HttpStatusCode.NotFound, errors: new[] { "Not Found" });
            return this.ToSuccessResult(data: course);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int pageSize = 10, string CourseName = "", string Description = "")
        {
            var courses = await _mediator.Send(new GetCoursesQuery(page, pageSize, CourseName, Description));
            return this.ToSuccessResult(data: courses);
        }
    }
}
