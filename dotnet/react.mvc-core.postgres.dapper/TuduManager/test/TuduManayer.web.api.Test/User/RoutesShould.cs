using Moq;
using MyTested.AspNetCore.Mvc;
using TuduManayer.web.api.User.SignUp;
using Xunit;

namespace TuduManayer.web.api.Test.User
{
    public class RoutesShould
    {
        [Fact]
        public void MapToSignUpUser()
        {
            MyMvc
                .Routing()
                .ShouldMap(request => request
                    .WithMethod(HttpMethod.Post)
                    .WithLocation("/api/users"))
                .To<SignUpUserController>(x =>
                    x.SignUp(It.IsAny<SignUpUserRequest>()));
        }
    }
}
