using TuduManayer.Domain.User.SignUp;

namespace TuduManayer.Repository.Postgres.EntityFramework.User
{
    public class SaveUserRepository : ISaveUserRepository
    {
        private readonly DataBaseContextFactory dataBaseContextFactory;

        public SaveUserRepository(DataBaseContextFactory dataBaseContextFactory)
        {
            this.dataBaseContextFactory = dataBaseContextFactory;
        }

        public void Save(Domain.User.User user)
        {
            using var dbContext = dataBaseContextFactory.Create();
            dbContext.Users.Add(new Models.User
            {
                email = user.Email,
                password = user.Password,
                creation_date = user.CreationDate,
                updated_date = null
            });
            dbContext.SaveChanges();
        }
    }
}