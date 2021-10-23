using System.Collections.Generic;

namespace TuduManayer.Domain.User.SignUp.Validation
{
    public class PasswordValidator : IValidator
    {
        public List<Error> Validate(SignUpUserArgs args)
        {
            var errors = new List<Error>();
            if (string.IsNullOrEmpty(args.Password))
            {
                errors.Add(Error.With(nameof(args.Password), ErrorCodes.Required));
            }
            else if (args.Password.Length > Validator.MaximumNumberOfCharacters)
            {
                errors.Add( Error.With(nameof(args.Password), ErrorCodes.InvalidLength));
            }
            return errors;
        }
    }
}