using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TuduManayer.Domain.User.SignUp.Validation
{
    public class EmailValidator : IValidator
    {
        public List<Error> Validate(SignUpUserArgs args)
        {
            var errors = new List<Error>();
            if (string.IsNullOrEmpty(args.Email))
            {
                errors.Add(Error.With(nameof(args.Email), ErrorCodes.Required));
            }
            else if (args.Email.Length > Validator.MaximumNumberOfCharacters)
            {
                errors.Add(Error.With(nameof(args.Email), ErrorCodes.InvalidLength));
            }
            else if (IsNotValidEmail(args.Email))
            {
                errors.Add(Error.With(nameof(args.Email), ErrorCodes.InvalidFormat));
            }
            return errors;
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