using Microsoft.AspNetCore.Mvc;
using School.API.Helpers;
using System.Net;

namespace School.API.Extentions
{
        public static class ApiResponseExtensions
        {
            public static IActionResult ToSuccessResult<T>(this ControllerBase controller, T data, string message = "Success", HttpStatusCode code = HttpStatusCode.OK)
            {
                var response = new ResponseSchema<T>
                {
                    Success = true,
                    Data = data,
                    Code = (int)code,
                    Message = message,
                    Errors = Array.Empty<string>()
                };
                return controller.StatusCode((int)response.Code, response);
            }

            public static IActionResult ToErrorResult(this ControllerBase controller, IEnumerable<string> errors, string message = "One or more errors occurred", HttpStatusCode code = HttpStatusCode.BadRequest)
            {
                var response = new ResponseSchema<object>
                {
                    Success = false,
                    Data = null,
                    Code = (int)code,
                    Message = message,
                    Errors = errors
                };
                return controller.StatusCode((int)response.Code, response);
            }
        }
    
}
