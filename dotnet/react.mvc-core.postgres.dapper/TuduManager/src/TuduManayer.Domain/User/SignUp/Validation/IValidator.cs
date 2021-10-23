using System.Collections.Generic;

namespace TuduManayer.Domain.User.SignUp.Validation
{
    public interface IValidator
    {
        List<Error> Validate(SignUpUserArgs args);
    }
}