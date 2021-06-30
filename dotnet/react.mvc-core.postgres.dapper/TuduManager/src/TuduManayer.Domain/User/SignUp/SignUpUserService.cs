using System.Linq;

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
    }
}