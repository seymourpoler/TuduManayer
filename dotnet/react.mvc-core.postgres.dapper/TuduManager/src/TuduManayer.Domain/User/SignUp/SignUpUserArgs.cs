namespace TuduManayer.Domain.User.SignUp
{
    public class SignUpUserArgs
    {
        public string Email { get; }
        public string Password { get; }
        
        public SignUpUserArgs(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}