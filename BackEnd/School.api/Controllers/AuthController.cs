using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.API.DTOs.AuthDTO;
using School.API.Extentions;
using School.Application.Interfaces;
using School.Domain.Entities;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IJwtService _jwt;

        public AuthController(IUserRepository userRepo, IJwtService jwt)
        {
            _userRepo = userRepo;
            _jwt = jwt;
        }
        [AllowAnonymous]
        [HttpPost("StudentRegister")]
        public async Task<IActionResult> Studentregister(string username, string password)
        {
            var existing = await _userRepo.GetByUsernameAsync(username);
            if (existing != null)
                return this.ToErrorResult(code: System.Net.HttpStatusCode.NotAcceptable, errors: new[] { "Username already exists." });

            var user = new User
            {
                Username = username,
                Password = password,
                RoleId = 1
            };

            await _userRepo.RegisterAsync(user);

            return Ok("User registered successfully.");
        }
        [HttpPost("AdminRegister")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Adminregister(string username, string password)
        {
            var existing = await _userRepo.GetByUsernameAsync(username);
            if (existing != null)
                return this.ToErrorResult(errors: new[] { "Username already exists." }, code: System.Net.HttpStatusCode.NotFound);


            var user = new User
            {
                Username = username,
                Password = password,
                RoleId = 3
            };

            await _userRepo.RegisterAsync(user);

            return this.ToSuccessResult(data: "User registered successfully.");
        }

        [HttpPost("TeacherRegister")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult>TeacherRigister(string username, string password)
        {
            var existing = await _userRepo.GetByUsernameAsync(username);
            if (existing != null)
                return this.ToErrorResult(errors: new[] { "Username already exists." });

            var user = new User
            {
                Username = username,
                Password = password,
                RoleId = 2
            };

            await _userRepo.RegisterAsync(user);

            return this.ToSuccessResult(data: "User registered successfully.");
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO logindto)
        {
            var user = await _userRepo.GetByUsernameAsync(logindto.username);
            if (user == null)
                return this.ToErrorResult(code: System.Net.HttpStatusCode.NotFound, errors: new[] { "User not found" });

            if (user.Password != logindto.password)
                return this.ToErrorResult(code: System.Net.HttpStatusCode.Unauthorized, errors: new[] { "User not found" });
            var token = _jwt.GenerateToken(user);

            return this.ToSuccessResult(data: new { token });
        }



    }
}
