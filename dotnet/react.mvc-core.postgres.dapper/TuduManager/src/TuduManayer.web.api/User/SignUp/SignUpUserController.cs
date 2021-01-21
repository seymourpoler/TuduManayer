using System;
using Microsoft.AspNetCore.Mvc;

namespace TuduManayer.web.api.User.SignUp
{
    public partial class SignUpUserController : Controller
    {
        [HttpPost("/api/users")]
        public IActionResult SignUp(SignUpUserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}