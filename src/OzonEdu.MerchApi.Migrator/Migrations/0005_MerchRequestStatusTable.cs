using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Migrations
{
    [Migration(5)]
    public class MerchRequestStatusTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists request_status(
                    id INT NOT NULL PRIMARY KEY,
                    status TEXT NOT NULL);"
            );
        }

        public override void Down()
        {
            Execute.Sql(@"DROP TABLE if exists request_status;");
        }
    }
}