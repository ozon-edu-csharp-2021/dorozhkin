using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Migrations
{
    [Migration(2)]
    public class MerchItemTable : Migration
    {
        public override void Up()
        {
            Create
                .Table("MerchItem")
                .WithColumn("id").AsInt64().Identity().PrimaryKey()
                .WithColumn("name").AsString().NotNullable()
                .WithColumn("sku").AsInt64().NotNullable();
        }

        public override void Down()
        {
            Delete.Table("MerchItem");
        }
    }
}