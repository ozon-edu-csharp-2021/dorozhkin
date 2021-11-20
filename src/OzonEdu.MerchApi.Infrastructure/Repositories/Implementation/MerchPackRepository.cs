using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.ValueObject;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.ValueObjects;
using OzonEdu.MerchApi.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.MerchApi.Infrastructure.Repositories.Implementation
{
    public class MerchPackRepository : IMerchPackRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IChangeTracker _changeTracker;
        private const int Timeout = 5;

        private readonly List<MerchPack> _merchPacks; //todo remove

        public MerchPackRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory,
            IChangeTracker changeTracker)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _changeTracker = changeTracker;
        }

        public Task<MerchPack> CreateAsync(MerchPack itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchPack> UpdateAsync(MerchPack itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<MerchPack> FindByIdAsync(long merchPackId, CancellationToken cancellationToken = default)
        {
            // return _merchPacks.FirstOrDefault(x => x.Id == merchPackId);

            const string sqlForMerchPack = @"
                SELECT *
                FROM merch_packs
                WHERE id = @Id;";

            const string sqlForMerchItemSkus = @"
                SELECT merch_items 
                FROM merch_packs 
                WHERE id = @Id;";

            var parameters = new
            {
                Id = merchPackId,
            };
            var commandDefinition = new CommandDefinition(
                sqlForMerchPack,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var merchPackModel = await connection.QueryFirstAsync<Models.MerchPack>(commandDefinition);

            var merchSkus = await connection.QueryFirstAsync<long[]>(sqlForMerchItemSkus,
                new {Id = merchPackId});

            merchPackModel.MerchSkus = merchSkus;

            var merchItems = new List<MerchItem>();
            
            foreach (var merchSku in merchSkus)
            {
                var merchItem = await FindMerchItemBySkuAsync(merchSku, cancellationToken);
                merchItems.Add(merchItem);
            }
            
            // var merchItemsTask =
            //     Task.WhenAll(merchPackModel.MerchItemsId.Select(async x =>
            //         await FindMerchItemByIdAsync(x, cancellationToken)));
            // var merchItems = merchItemsTask.Result;

            var merchPack = new MerchPack(new NamePack(merchPackModel.NamePack), merchItems);

            _changeTracker.Track(merchPack);
            return merchPack;
        }

        public async Task<MerchItem> CreateMerchItemByIdAsync(MerchItem merchItemToSave,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<MerchItem> FindMerchItemBySkuAsync(long sku,
            CancellationToken cancellationToken = default)
        {
            const string sql = @"
                SELECT *
                FROM merch_items
                WHERE sku = @Sku;";

            var parameters = new
            {
                Sku = sku,
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var merchItemModel = await connection.QueryFirstAsync<Models.MerchItem>(commandDefinition);

            var merchItem = new MerchItem(
                new NameItem(merchItemModel.NameItem),
                new Sku(merchItemModel.Sku)
            );
            
            _changeTracker.Track(merchItem);
            return merchItem;
        }
    }
}