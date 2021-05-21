using System.Collections.Generic;

namespace TuduManayer.Domain.User.SignUp
{
    public class SignUpUserService : ISignUpUserService
    {
        public ServiceExecutionResult SignUp(SignUpUserArgs args)
        {
            if (string.IsNullOrEmpty(args.Email))
            {
                return ServiceExecutionResult.WithErrors(
                    new List<Error> { Error.With(nameof(args.Email), ErrorCodes.Required)});
            }
            throw new System.NotImplementedException();
        }
    }
}