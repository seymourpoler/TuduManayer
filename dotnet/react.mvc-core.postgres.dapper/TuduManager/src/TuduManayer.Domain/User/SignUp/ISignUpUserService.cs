namespace TuduManayer.Domain.User.SignUp
{
    public interface ISignUpUserService
    {
        ServiceExecutionResult SignUp(SignUpUserArgs args);
    }
}