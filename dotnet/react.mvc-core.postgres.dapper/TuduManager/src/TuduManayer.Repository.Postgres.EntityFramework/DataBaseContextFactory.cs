namespace TuduManayer.Repository.Postgres.EntityFramework
{
    public class DataBaseContextFactory
    {
        private readonly Configuration configuration;
        
        public TuduManayerDbContext Create()
        {
            return new TuduManayerDbContext(configuration.ConnectionString);    
        }
    }
}