using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.API.Extentions;
using School.Application.Class.Queries.GetAllClass;
using School.Application.Class.Queries.GetClassById;
using School.Application.Courses.Commads.DeleteCourse;
using School.Application.Courses.Commads.UpdateCourse;

namespace School.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClassesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClassesController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateClassCommand command)
            => this.ToSuccessResult(data: await _mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateClassCommand command)
        {
            command = command with { Id = id };
            return this.ToSuccessResult(data: await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
            => this.ToSuccessResult(await _mediator.Send(new DeleteClassCommand(id)));

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
            => this.ToSuccessResult(data: await _mediator.Send(new GetClassByIdQuery(id)));

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page = 1, [FromQuery] int size = 10, string ClassName = "", string TeacherName = "")
            => this.ToSuccessResult(data: await _mediator.Send(new GetClassesQuery(page, size, ClassName, TeacherName)));
    }

}
