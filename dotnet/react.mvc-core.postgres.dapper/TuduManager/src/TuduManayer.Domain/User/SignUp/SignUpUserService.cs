using System.Linq;
using System.Text.RegularExpressions;

namespace TuduManayer.Domain.User.SignUp
{
    public class SignUpUserService : ISignUpUserService
    {
        public static readonly int MaximumNumberOfCharacters = 255;
        private readonly Validator validator;

        public SignUpUserService(Validator validator, ISaveUserRepository saveUserRepository)
        {
            this.validator = validator;
        }

        public ServiceExecutionResult SignUp(SignUpUserArgs args)
        {
            var errors = validator.Validate(args);

            if (errors.Any())
            {
                return ServiceExecutionResult.WithErrors(errors);
            }
            return ServiceExecutionResult.WithSucess();
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