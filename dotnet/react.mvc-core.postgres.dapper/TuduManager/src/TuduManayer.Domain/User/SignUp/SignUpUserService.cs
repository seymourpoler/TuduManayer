using System.Linq;

namespace TuduManayer.Domain.User.SignUp
{
    public class SignUpUserService : ISignUpUserService
    {
        private readonly Validator validator;
        private readonly ISaveUserRepository saveUserRepository;

        public SignUpUserService(Validator validator, ISaveUserRepository saveUserRepository)
        {
            this.validator = validator;
            this.saveUserRepository = saveUserRepository;
        }

        public ServiceExecutionResult SignUp(SignUpUserArgs args)
        {
            var errors = validator.Validate(args);

            if (errors.Any())
            {
                return ServiceExecutionResult.WithErrors(errors);
            }

            var user = new User(args.Email, args.Password);
            saveUserRepository.Save(user);
            
            return ServiceExecutionResult.WithSucess();
        }
    }
}