using FluentMigrator;

namespace TuduManayer.Migration.Postgres.Fluent.Migrations
{
    [Migration(20201123, "20201123_AddTodoTable")]
    public class AddTodoTable :  FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("Todos")
                .WithColumn("id").AsInt32().Identity().PrimaryKey() 
                .WithColumn("title").AsString(255)
                .WithColumn("description").AsString(255)
                .WithColumn("creation_date").AsDateTime().NotNullable()
                .WithColumn("updated_date").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Todos");
        }
    }
}
