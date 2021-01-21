using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shouldly;
using TuduManayer.Domain;
using TuduManayer.Domain.User.SignUp;
using TuduManayer.web.api.User.SignUp;
using Xunit;

namespace TuduManayer.web.api.Test.User.SignUp
{
    public class SignUpUserControllerShould
    {
        [Fact]
        public void return_bad_request_when_there_is_an_error()
        {
            const string email = "a@mail.com";
            var service = new Mock<ISignUpUserService>();
            service.Setup(x => x.SignUp(It.Is<SignUpUserArgs>(y => y.Email == email)))
                .Returns(ServiceExecutionResult.WithErrors(new List<Error>{Error.With(nameof(SignUpUserArgs.Password), ErrorCodes.Required)}));
            var request = new SignUpUserRequest {Email = email};
            var controller = new SignUpUserController(service.Object);

            var response = controller.SignUp(request) as BadRequestObjectResult;
            
            response.StatusCode.ShouldBe((int)HttpStatusCode.BadRequest);
            ((IReadOnlyList<Error>)response.Value)[0].FieldId.ShouldBe(nameof(SignUpUserArgs.Password));
            ((IReadOnlyList<Error>)response.Value)[0].ErrorCode.ShouldBe(ErrorCodes.Required);
        }
    }
}