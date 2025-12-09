using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.API.Extentions;
using School.Application.Students.Commans.CreateStudent;
using School.Application.Students.Commans.DeleteStudent;
using School.Application.Students.Commans.UpdateStudent;
using School.Application.Students.Queries.GetStudentById;
using School.Application.Students.Queries.GetStudents;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        => this.ToSuccessResult(data: await _mediator.Send(command));


        [Authorize(Roles = "Student")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var UserId = int.Parse(User.FindFirst("UId").Value);

            return this.ToSuccessResult(data: await _mediator.Send(new GetStudentByIdQuery(UserId)));

        }

        [HttpGet]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10, string Name = "", string className = "")
            => this.ToSuccessResult(data: await _mediator.Send(new GetStudentsQuery() { Page = page, PageSize = pageSize, Name = Name, ClassName = className }));

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateStudentCommand command)
        {
            var UserId = id;// int.Parse(User.FindFirst("UId").Value);
            if (UserId != command.Id) return this.ToErrorResult(errors: new[] { "UserId not true" });

            await _mediator.Send(command);
            return this.ToSuccessResult(data: "Student Updated Succesfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteStudentCommand(id));
            return this.ToSuccessResult(data: "Deleted Successully", code: System.Net.HttpStatusCode.NoContent);
        }
    }
}
