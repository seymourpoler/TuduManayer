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
        private Mock<ISignUpUserService> service;
        private SignUpUserController controller;
        
        public SignUpUserControllerShould()
        {
             service = new Mock<ISignUpUserService>();
             controller = new SignUpUserController(service.Object);
        }

        [Fact]
        public void return_bad_request_when_there_is_an_error()
        {
            const string email = "a@mail.com";
            service.Setup(x => x.SignUp(It.Is<SignUpUserArgs>(y => y.Email == email)))
                .Returns(ServiceExecutionResult.WithErrors(new List<Error>{Error.With(nameof(SignUpUserArgs.Password), ErrorCodes.Required)}));
            var request = new SignUpUserRequest {Email = email};

            var response = controller.SignUp(request) as BadRequestObjectResult;
            
            response.StatusCode.ShouldBe((int)HttpStatusCode.BadRequest);
            ((IReadOnlyList<Error>)response.Value)[0].FieldId.ShouldBe(nameof(SignUpUserArgs.Password));
            ((IReadOnlyList<Error>)response.Value)[0].ErrorCode.ShouldBe(ErrorCodes.Required);
        }

        [Fact]
        public void return_ok_when_is_signed_up()
        {
            const string email = "a@mail.com";
            service.Setup(x => x.SignUp(It.Is<SignUpUserArgs>(y => y.Email == email)))
                .Returns(ServiceExecutionResult.WithSucess());
            var request = new SignUpUserRequest {Email = email, Password = "password"};

            var response = controller.SignUp(request) as OkResult;
            
            response.StatusCode.ShouldBe((int)HttpStatusCode.OK);
        }
    }
}