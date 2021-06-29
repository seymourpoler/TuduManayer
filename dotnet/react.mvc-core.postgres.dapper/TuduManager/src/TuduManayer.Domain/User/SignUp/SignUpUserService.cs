using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace TuduManayer.Domain.User.SignUp
{
    public class SignUpUserService : ISignUpUserService
    {
        public static readonly int MaximumNumberOfCharacters = 255;
        
        public ServiceExecutionResult SignUp(SignUpUserArgs args)
        {
            var errors = new List<Error>();
            if (string.IsNullOrEmpty(args.Email))
            {
                errors.Add(Error.With(nameof(args.Email), ErrorCodes.Required));
            }
            else if (args.Email.Length > MaximumNumberOfCharacters)
            {
                errors.Add(Error.With(nameof(args.Email), ErrorCodes.InvalidLength));
            }
            else if (IsNotValidEmail(args.Email))
            {
                errors.Add(Error.With(nameof(args.Email), ErrorCodes.InvalidFormat));
            }
            if (string.IsNullOrEmpty(args.Password))
            {
                errors.Add(Error.With(nameof(args.Password), ErrorCodes.Required));
            }
            else if (args.Password.Length > MaximumNumberOfCharacters)
            {
                errors.Add( Error.With(nameof(args.Password), ErrorCodes.InvalidLength));
            }

            if (errors.Any())
            {
                return ServiceExecutionResult.WithErrors(errors);
            }
            throw new System.NotImplementedException();
        }

        private static bool IsNotValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return true;
            
            var pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";    
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);    
            return !regex.IsMatch(email);
        }
    }
}