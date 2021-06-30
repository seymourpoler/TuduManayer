namespace TuduManayer.Domain.User.SignUp
{
    public interface ISaveUserRepository
    {
        void Save(User user);
    }
}