namespace TuduManayer.Repository.Postgres.EntityFramework
{
    public class DataBaseContextFactory
    {
        private readonly Configuration configuration;

        public DataBaseContextFactory(Configuration configuration)
        {
            this.configuration = configuration;
        }

        public TuduManayerDbContext Create()
        {
            return new TuduManayerDbContext(configuration.ConnectionString);    
        }
    }
}