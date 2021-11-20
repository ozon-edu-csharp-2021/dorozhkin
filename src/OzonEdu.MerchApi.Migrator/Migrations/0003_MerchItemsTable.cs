using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Migrations
{
    [Migration(3)]
    public class MerchItemsTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists merch_items(
                    id BIGSERIAL PRIMARY KEY,
                    name_item TEXT NOT NULL,
                    sku INT NOT NULL);"
            );
        }

        public override void Down()
        {
            Execute.Sql(@"DROP TABLE if exists merch_items;");
        }
    }
}