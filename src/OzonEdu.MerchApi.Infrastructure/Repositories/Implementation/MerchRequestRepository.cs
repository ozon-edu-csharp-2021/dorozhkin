using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.ValueObject;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.ValueObjects;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities;
using OzonEdu.MerchApi.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.MerchApi.Infrastructure.Repositories.Implementation
{
    public class MerchRequestRepository : IMerchRequestRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IChangeTracker _changeTracker;
        private const int Timeout = 5;   
        
        public MerchRequestRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory, IChangeTracker changeTracker)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _changeTracker = changeTracker;
        }

        public async Task<MerchRequest> CreateAsync(MerchRequest itemToCreate, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                INSERT INTO merch_requests (status_id, merch_pack_id, employee_id, supply_code_id, reserve_code_id, delivery_code_id)
                VALUES (@StatusId, @MerchPackId, @EmployeeId, @SupplyCodeId, @ReserveCodeId, @DeliveryCodeId);
                SELECT id
                FROM merch_requests
                ORDER BY id DESC
                LIMIT 1";
            

            var parameters = new
            {
                StatusId = itemToCreate.Status.Id,
                MerchPackId = itemToCreate.MerchPackId,
                EmployeeId = itemToCreate.EmployeeId,
                SupplyCodeId = itemToCreate.SupplyCodeStatus,
                ReserveCodeId = itemToCreate.ReserveCodeStatus,
                DeliveryCodeId = itemToCreate.DeliveryCode
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var merchRequestModel = await connection.QueryFirstAsync<Models.MerchRequest>(commandDefinition);

            var merchRequest = CreateMerchRequestEntity(merchRequestModel);

            _changeTracker.Track(merchRequest);
            return merchRequest;
        }

        public async Task<MerchRequest> UpdateAsync(MerchRequest itemToUpdate, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                UPDATE merch_requests
                SET delivery_code_id = 4444
                WHERE id = @Id;
                SELECT id
                FROM merch_requests
                WHERE id = @Id";
            

            var parameters = new
            {
                Id = itemToUpdate.Id
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var merchRequestModel = await connection.QueryFirstAsync<Models.MerchRequest>(commandDefinition);

            var merchRequest = CreateMerchRequestEntity(merchRequestModel);

            _changeTracker.Track(merchRequest);
            return merchRequest;
        }

        public Task<MerchRequest> FindByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<MerchRequest>> FindByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                SELECT *
                FROM merch_requests
                WHERE employee_id = @EmployeeId;";
            
            var parameters = new
            {
                EmployeeId = employeeId,
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var merchRequestModels = await connection.QueryAsync<Models.MerchRequest>(commandDefinition);

            var result = new List<MerchRequest>();
            
            foreach (var merchRequestModel in merchRequestModels)
            {
                var merchRequest = CreateMerchRequestEntity(merchRequestModel);

                _changeTracker.Track(merchRequest);
                
                result.Add(merchRequest);
            }
            
            return result;
        }

        public async Task<List<MerchRequest>> GetByEmployeeIdWithMerchPackIdAsync(long employeeId, long merchPackId,
            CancellationToken cancellationToken = default)
        {
            const string sql = @"
                SELECT *
                FROM merch_requests
                WHERE employee_id = @EmployeeId
                AND merch_pack_id = @MerchPackId";
            
            var parameters = new
            {
                EmployeeId = employeeId,
                MerchPackId = merchPackId
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var merchRequestModels = await connection.QueryAsync<Models.MerchRequest>(commandDefinition);
            
            var result = new List<MerchRequest>();
            
            foreach (var merchRequestModel in merchRequestModels)
            {
                var merchRequest = CreateMerchRequestEntity(merchRequestModel);

                _changeTracker.Track(merchRequest);
                
                result.Add(merchRequest);
            }
            
            return result;
        }

        public async Task<List<MerchRequest>> GetAllRequestsAsync(CancellationToken cancellationToken = default)
        {
            const string sql = @"
                SELECT *
                FROM merch_requests;";
            
            var commandDefinition = new CommandDefinition(
                sql,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var merchRequestModels = await connection.QueryAsync<Models.MerchRequest>(commandDefinition);
            
            var result = new List<MerchRequest>();
            
            foreach (var merchRequestModel in merchRequestModels)
            {
                var merchRequest = CreateMerchRequestEntity(merchRequestModel);

                _changeTracker.Track(merchRequest);
                
                result.Add(merchRequest);
            }
            
            return result;
        }

        private MerchRequest CreateMerchRequestEntity(Models.MerchRequest merchRequestModel)
        {
            var merchRequest = new MerchRequest(
                merchRequestModel.MerchPackId,
                merchRequestModel.EmployeeId);

            merchRequest.SetId(merchRequestModel.Id);
            
            if (merchRequestModel.SupplyCodeId != null)
                merchRequest.SetWaitingSupplyStatus((long) merchRequestModel.SupplyCodeId);
            
            if (merchRequestModel.ReserveCodeId is not null)
                merchRequest.SetInProcessStatus((long) merchRequestModel.ReserveCodeId);
            
            if (merchRequestModel.DeliveryCodeId is not null)
                merchRequest.SetClosedStatus((long) merchRequestModel.DeliveryCodeId);
            
            return merchRequest;
        }
    }
}