using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Migrations
{
    [Migration(6)]
    public class FillRequestStatus : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"
                INSERT INTO request_status (id, status)
                VALUES 
                    (1, 'Created'),
                    (2, 'InProcess'),
                    (3, 'WaitingSupply'),
                    (4, 'Closed')
                ON CONFLICT DO NOTHING
            ");
        }
    }
}