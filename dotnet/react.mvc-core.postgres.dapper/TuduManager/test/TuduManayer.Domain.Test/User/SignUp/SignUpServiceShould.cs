using Shouldly;
using TuduManayer.Domain.User.SignUp;
using Xunit;

namespace TuduManayer.Domain.Test.User.SignUp
{
    public class SignUpServiceShould
    {
        private ISignUpUserService service;

        public SignUpServiceShould()
        {
            service = new SignUpUserService();
        }

        [Fact]
        public void should_return_error_when_email_is_empty()
        {
            var args = new SignUpUserArgs(string.Empty, "password");
            
            var result = service.SignUp(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors[0].FieldId.ShouldBe(nameof(SignUpUserArgs.Email));
            result.Errors[0].ErrorCode.ShouldBe(ErrorCodes.Required);
        }
        
        [Fact]
        public void should_return_error_when_email_is_null()
        {
            var args = new SignUpUserArgs(null, "password");
            
            var result = service.SignUp(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors[0].FieldId.ShouldBe(nameof(SignUpUserArgs.Email));
            result.Errors[0].ErrorCode.ShouldBe(ErrorCodes.Required);
        }
        
        
        [Fact]
        public void should_return_error_when_email_is_not_valid()
        {
            var args = new SignUpUserArgs("invalid-email", "password");
            
            var result = service.SignUp(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors[0].FieldId.ShouldBe(nameof(SignUpUserArgs.Email));
            result.Errors[0].ErrorCode.ShouldBe(ErrorCodes.InvalidFormat);
        }
        
        [Fact]
        public void should_return_error_when_password_is_empty()
        {
            var args = new SignUpUserArgs("e@ma.il", string.Empty);
            
            var result = service.SignUp(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors[0].FieldId.ShouldBe(nameof(SignUpUserArgs.Password));
            result.Errors[0].ErrorCode.ShouldBe(ErrorCodes.Required);
        }
        
        [Fact]
        public void should_return_error_when_password_is_null()
        {
            var args = new SignUpUserArgs("e@ma.il", null);
            
            var result = service.SignUp(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors[0].FieldId.ShouldBe(nameof(SignUpUserArgs.Password));
            result.Errors[0].ErrorCode.ShouldBe(ErrorCodes.Required);
        }
    }
}