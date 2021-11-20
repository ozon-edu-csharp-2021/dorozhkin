using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Migrations
{
    [Migration(4)]
    public class EmployeesTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists employees(
                    id BIGSERIAL PRIMARY KEY,
                    name TEXT NOT NULL,
                    email VARCHAR(100) NOT NULL,
                    phone VARCHAR(12) NOT NULL);"
            );
        }

        public override void Down()
        {
            Execute.Sql(@"DROP TABLE if exists employees;");
        }
    }
}