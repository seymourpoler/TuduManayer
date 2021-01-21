using System;
using Microsoft.AspNetCore.Mvc;
using TuduManayer.Domain.User.SignUp;

namespace TuduManayer.web.api.User.SignUp
{
    public partial class SignUpUserController : Controller
    {
        private readonly ISignUpUserService signUpUserService;

        public SignUpUserController(ISignUpUserService signUpUserService)
        {
            this.signUpUserService = signUpUserService;
        }

        [HttpPost("/api/users")]
        public IActionResult SignUp(SignUpUserRequest request)
        {
            var executionResult = signUpUserService.SignUp(new SignUpUserArgs(request.Email, request.Password));
            if(executionResult.IsOk)
            {
                throw new NotImplementedException();
            }

            return BadRequest(executionResult.Errors);
        }
    }
}