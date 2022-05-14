using Microsoft.EntityFrameworkCore;

namespace TuduManayer.Repository.Postgres.EntityFramework
{
    public class TuduManayerDbContext : DbContext
    {
        private readonly string connectionString;

        public TuduManayerDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
        
        public DbSet<Todo.Models.Todo> Todos { get; set; }
        public DbSet<User.Models.User> Users { get; set; }
    }
}