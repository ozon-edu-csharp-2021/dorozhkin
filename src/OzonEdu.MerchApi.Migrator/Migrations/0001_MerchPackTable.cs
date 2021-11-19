using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Migrations
{
    [Migration(1)]
    public class MerchPackTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists merchpacks(
                    id BIGSERIAL PRIMARY KEY,
                    name TEXT NOT NULL
                    );");
        }

        public override void Down()
        {
            Execute.Sql(@"DROP TABLE if exists merchpacks;");
        }
    }
}