using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Threading;
using System.Threading.Tasks;

namespace TuduManayer.Repository.Postgres.EntityFramework
{
    public class Migrator : IMigrator
    {
        private readonly DataBaseContextFactory dataBaseContextFactory;

        public Migrator(DataBaseContextFactory dataBaseContextFactory)
        {
            this.dataBaseContextFactory = dataBaseContextFactory;
        }

        public void Migrate(string targetMigration = null)
        {
            using var dbContext = dataBaseContextFactory.Create();
            dbContext.Database.Migrate();
        }

        public async Task MigrateAsync(string targetMigration = null, CancellationToken cancellationToken = new CancellationToken())
        {
            await using var dbContext = dataBaseContextFactory.Create();
            await dbContext.Database.MigrateAsync(cancellationToken);
        }

        public string GenerateScript(string fromMigration = null, string toMigration = null, bool idempotent = false)
        {
            using var dbContext = dataBaseContextFactory.Create();
            return dbContext.Database.GenerateCreateScript();
        }
    }
}
