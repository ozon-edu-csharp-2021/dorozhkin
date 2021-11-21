using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Migrations
{
    [Migration(1)]
    public class MerchRequestsTable : Migration
    {
        public override void Up()
        {
            Execute.Sql(@"
                CREATE TABLE if not exists merch_requests(
                    id BIGSERIAL PRIMARY KEY,
                    status_id INT NOT NULL,
                    merch_pack_id INT NOT NULL,
                    employee_id INT NOT NULL,
                    supply_code_id INT,
                    reserve_code_id INT,
                    delivery_code_id INT);"
            );
        }

        public override void Down()
        {
            Execute.Sql(@"DROP TABLE if exists merch_requests;");
        }
    }
}