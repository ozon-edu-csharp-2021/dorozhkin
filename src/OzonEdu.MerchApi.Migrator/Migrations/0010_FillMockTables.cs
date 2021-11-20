using FluentMigrator;

namespace OzonEdu.MerchApi.Migrator.Migrations
{
    [Migration(10)]
    public class FillMockTables : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"
                INSERT INTO merch_items (name_item, sku)
                VALUES 
                    ('T-Shirt', 111),
                    ('Socks', 222),
                    ('Pen', 333),
                    ('Cap', 444),
                    ('Sweatshirt', 555)
                ON CONFLICT DO NOTHING
            ");
            
            Execute.Sql(@"
                INSERT INTO merch_packs (merch_items, name_pack)
                VALUES 
                    ('{111, 222, 333}','Welcome-pack'),
                    ('{111, 333, 444}','Starter-pack'),
                    ('{111, 222, 333, 444}','Conference-listener-pack'),
                    ('{111, 222, 333, 555}','Conference-speaker-pack'),
                    ('{111, 222, 333, 444, 555}','Veteran-pack')
                ON CONFLICT DO NOTHING
            ");
            
            Execute.Sql(@"
                INSERT INTO employees (name, email, phone)
                VALUES 
                    ('Kirby', 'krasp0@soundcloud.com', '4798142365'),
                    ('Aleksandr', 'amatcham1@squidoo.com', '4458053040'),
                    ('Gustavus', 'gschieferstein2@cdc.gov', '3198018742'),
                    ('Ardella', 'aeagar3@joomla.org', '3667115882'),
                    ('Reese', 'rfeechan4@theguardian.com', '2093621737'),
                    ('Barris', 'boxbe5@harvard.edu', '5587641419'),
                    ('Erv', 'egilligan6@booking.com', '2388283038'),
                    ('Livy', 'lphilliskirk7@paginegialle.it', '1129360593'),
                    ('Issiah', 'ieardley8@about.com', '5389736923'),
                    ('Leontine', 'lovendon9@vimeo.com', '5469283629'),
                    ('Hill', 'hfreddia@msn.com', '1411156640'),
                    ('Leonerd', 'lboncoeurb@shareasale.com', '2715989815'),
                    ('Brittne', 'bwandrachc@tripod.com', '8953997479'),
                    ('Angelo', 'acecchid@blinklist.com', '3459049249'),
                    ('Octavia', 'oderingtone@hibu.com', '1091527350')
                ON CONFLICT DO NOTHING
            ");
            
            Execute.Sql(@"
                INSERT INTO merch_requests (status_id, merch_pack_id, employee_id, supply_code_id, reserve_code_id, delivery_code_id)
                VALUES 
                    (1, 1, 1, 0, 434, 0),
                    (1, 2, 2, 0, 545, 0),
                    (2, 3, 3, 343, 234, 0),
                    (3, 4, 4, 400, 344, 0),
                    (4, 5, 5, 500, 100, 300)
                ON CONFLICT DO NOTHING
            ");
        }
    }
}