using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TuduManayer.Domain.User.SignUp
{
    public class SignUpUserService : ISignUpUserService
    {
        public static readonly int MaximumNumberOfCharacters = 255;
        
        public ServiceExecutionResult SignUp(SignUpUserArgs args)
        {
            if (string.IsNullOrEmpty(args.Email))
            {
                return ServiceExecutionResult.WithErrors(
                    new List<Error> { Error.With(nameof(args.Email), ErrorCodes.Required)});
            }
            else if (args.Email.Length > MaximumNumberOfCharacters)
            {
                return ServiceExecutionResult.WithErrors(
                    new List<Error> { Error.With(nameof(args.Email), ErrorCodes.InvalidLength)});
            }
            
            if (IsNotValidEmail(args.Email))
            {
                return ServiceExecutionResult.WithErrors(
                    new List<Error> { Error.With(nameof(args.Email), ErrorCodes.InvalidFormat)});
            }
            
            
            
            if (string.IsNullOrEmpty(args.Password))
            {
                return ServiceExecutionResult.WithErrors(
                    new List<Error> { Error.With(nameof(args.Password), ErrorCodes.Required)});
            }
            else if (args.Password.Length > MaximumNumberOfCharacters)
            {
                return ServiceExecutionResult.WithErrors(
                    new List<Error> { Error.With(nameof(args.Password), ErrorCodes.InvalidLength)});
            }
            throw new System.NotImplementedException();
        }
        
        public static bool IsNotValidEmail( string email)
        {
            var pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";    
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);    
            return !regex.IsMatch(email);
        }
    }
}