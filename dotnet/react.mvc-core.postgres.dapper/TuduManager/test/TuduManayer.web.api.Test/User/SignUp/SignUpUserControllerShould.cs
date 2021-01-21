using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shouldly;
using TuduManayer.web.api.User.SignUp;
using Xunit;

namespace TuduManayer.web.api.Test.User.SignUp
{
    public class SignUpUserControllerShould
    {
        [Fact]
        public void return_bad_request_when_there_is_an_error()
        {
            var request = new SignUpUserRequest();
            var controller = new SignUpUserController();

            var response = controller.SignUp(request) as BadRequestObjectResult;
            
            response.StatusCode.ShouldBe((int)HttpStatusCode.BadRequest);
        }
    }
}