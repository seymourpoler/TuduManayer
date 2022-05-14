using System.Collections.Generic;
using System.Linq;

namespace TuduManayer.Domain.User.SignUp.Validation
{
    public interface IValidator
    {
        List<Error> Validate(SignUpUserArgs args);
    }
    
    public class Validator
    {
        public static readonly int MaximumNumberOfCharacters = 255;

        private List<IValidator> validators = new List<IValidator>
        {
            new EmailValidator(),
            new PasswordValidator()
        };

        public List<Error> Validate(SignUpUserArgs args)
        {
            return validators
                .SelectMany(x => x.Validate(args))
                .ToList();
        }
    }
}