using Castle.Core.Internal;
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
            service = new SignUpUserService(new Validator());
        }

        [Fact]
        public void return_error_when_email_is_empty()
        {
            var args = new SignUpUserArgs(string.Empty, "password");
            
            var result = service.SignUp(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors[0].FieldId.ShouldBe(nameof(SignUpUserArgs.Email));
            result.Errors[0].ErrorCode.ShouldBe(ErrorCodes.Required);
        }
        
        [Fact]
        public void return_error_when_email_is_null()
        {
            var args = new SignUpUserArgs(null, "password");
            
            var result = service.SignUp(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors[0].FieldId.ShouldBe(nameof(SignUpUserArgs.Email));
            result.Errors[0].ErrorCode.ShouldBe(ErrorCodes.Required);
        }
        
        [Fact]
        public void return_error_when_email_is_not_valid()
        {
            var args = new SignUpUserArgs("invalid-email", "password");
            
            var result = service.SignUp(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors[0].FieldId.ShouldBe(nameof(SignUpUserArgs.Email));
            result.Errors[0].ErrorCode.ShouldBe(ErrorCodes.InvalidFormat);
        }
        
        [Fact]
        public void return_error_when_email_has_more_than_maximum_characters()
        {
            var  moreThanMaximumNumberOfCharacters = SignUpUserService.MaximumNumberOfCharacters + 1;
            var email = StringGenerator.Generate(moreThanMaximumNumberOfCharacters);
            var args = new SignUpUserArgs(email, "password");
            
            var result = service.SignUp(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors[0].FieldId.ShouldBe(nameof(SignUpUserArgs.Email));
            result.Errors[0].ErrorCode.ShouldBe(ErrorCodes.InvalidLength);
        }
        
        [Fact]
        public void return_error_when_password_is_empty()
        {
            var args = new SignUpUserArgs("e@ma.il", string.Empty);
            
            var result = service.SignUp(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors[0].FieldId.ShouldBe(nameof(SignUpUserArgs.Password));
            result.Errors[0].ErrorCode.ShouldBe(ErrorCodes.Required);
        }
        
        [Fact]
        public void return_error_when_password_is_null()
        {
            var args = new SignUpUserArgs("e@ma.il", null);
            
            var result = service.SignUp(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors[0].FieldId.ShouldBe(nameof(SignUpUserArgs.Password));
            result.Errors[0].ErrorCode.ShouldBe(ErrorCodes.Required);
        }
        
        [Fact]
        public void return_error_when_password_has_more_than_maximum_characters()
        {
            var  moreThanMaximumNumberOfCharacters = SignUpUserService.MaximumNumberOfCharacters + 1;
            var veryLongPassword = StringGenerator.Generate(moreThanMaximumNumberOfCharacters);
            var args = new SignUpUserArgs("a@ema.il", veryLongPassword);
            
            var result = service.SignUp(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors[0].FieldId.ShouldBe(nameof(SignUpUserArgs.Password));
            result.Errors[0].ErrorCode.ShouldBe(ErrorCodes.InvalidLength);
        }
        
        [Fact]
        public void return_errors_when_both_are_null()
        {
            var args = new SignUpUserArgs(null, null);
            
            var result = service.SignUp(args);
            
            result.IsOk.ShouldBeFalse();
            result.Errors[0].FieldId.ShouldBe(nameof(SignUpUserArgs.Email));
            result.Errors[0].ErrorCode.ShouldBe(ErrorCodes.Required);
            result.Errors[1].FieldId.ShouldBe(nameof(SignUpUserArgs.Password));
            result.Errors[1].ErrorCode.ShouldBe(ErrorCodes.Required);
        }

        [Fact]
        public void signedUp()
        {
            var args = new SignUpUserArgs("e@ma.il", "password");
            
            var result = service.SignUp(args);
            
            result.IsOk.ShouldBeTrue();
            result.Errors.ShouldBeEmpty();
        }
    }
}