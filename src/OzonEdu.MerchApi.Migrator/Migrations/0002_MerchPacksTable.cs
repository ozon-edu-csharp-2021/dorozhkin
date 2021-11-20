using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Migrations
{
    [Migration(2)]
    public class MerchPacksTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists merch_packs(
                    id BIGSERIAL PRIMARY KEY,
                    merch_items INT[] NOT NULL,
                    name_pack TEXT NOT NULL);"
            );
        }

        public override void Down()
        {
            Execute.Sql(@"DROP TABLE if exists merch_packs;");
        }
    }
}