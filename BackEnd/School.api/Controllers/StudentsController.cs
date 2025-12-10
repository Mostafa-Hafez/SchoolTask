using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.API.DTOs.Student;
using School.API.Extentions;
using School.Application.Students.Commans.CreateStudent;
using School.Application.Students.Commans.DeleteStudent;
using School.Application.Students.Commans.UpdateStudent;
using School.Application.Students.Queries.GetStudentById;
using School.Application.Students.Queries.GetStudents;
using System.Security.Claims;

namespace School.API.Controllers
{
    [Authorize]
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        => this.ToSuccessResult(data: await _mediator.Send(command));


        [Authorize(Roles = "Student,Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var userIdclaims = User.FindFirst("UId")?.Value;
            int userId = userIdclaims != null ? int.Parse(userIdclaims) : 0;
            if (role == "Student")
            {
                id = userId;
            }
            return this.ToSuccessResult(data: await _mediator.Send(new GetStudentByIdQuery(id)));

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll(int page = 1, int pageSize = 10, string Name = "", string className = "")
            => this.ToSuccessResult(data: await _mediator.Send(new GetStudentsQuery() { Page = page, PageSize = pageSize, Name = Name, ClassName = className }));

        [HttpPut("{id}")]
        [Authorize(Roles = "Student,Admin")]
        public async Task<IActionResult> Update(int id,UpdateStudentDTO studentsto )
        {

            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var userIdclaim = User.FindFirst("UId")?.Value;
            int userId = userIdclaim != null ? int.Parse(userIdclaim) : 0;
            if (role == "Student")
            {
                id = userId;
            }
            UpdateStudentCommand command = new UpdateStudentCommand() { Id=id,Name=studentsto.Name,Email=studentsto.Email,ClassId=studentsto.ClassId};
            await _mediator.Send(command);
            return this.ToSuccessResult(data: "Student Updated Succesfully");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteStudentCommand(id));
            return this.ToSuccessResult(data: "Deleted Successully", code: System.Net.HttpStatusCode.NoContent);
        }
    }
}
