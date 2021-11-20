using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.ValueObjects;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities;

namespace OzonEdu.MerchApi.Infrastructure.Repositories.Implementation
{
    public class MerchRequestRepository : IMerchRequestRepository
    {
        public MerchRequestRepository()
        {
            var merchRequest1 = new MerchRequest(1, 1, new long[] {111, 222, 333});
            var merchRequest2 = new MerchRequest(1, 2, new long[] {111, 222, 333});
            merchRequest1.ChangeId(1);
            merchRequest2.ChangeId(2);
            
            _merchRequests = new List<MerchRequest> { merchRequest1, merchRequest2 };
        }

        private readonly List<MerchRequest> _merchRequests;

        public async Task<MerchRequest> CreateAsync(MerchRequest itemToCreate, CancellationToken cancellationToken = default)
        {
            itemToCreate.ChangeId(_merchRequests[^1].Id + 1);
            _merchRequests.Add(itemToCreate);

            return itemToCreate;
        }

        public Task<MerchRequest> UpdateAsync(MerchRequest itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchRequest> FindByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<MerchRequest>> FindByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default)
        {
            return _merchRequests.Where(merchRequest => merchRequest.EmployeeId == employeeId).ToList();
        }

        public async Task<List<MerchRequest>> GetByEmployeeIdWithMerchPackIdAsync(long employeeId, long merchPackId,
            CancellationToken cancellationToken = default)
        {
            var merchRequests = _merchRequests
                .Where(merchRequest => merchRequest.EmployeeId == employeeId)
                .Where(merchRequest => merchRequest.MerchPackId == merchPackId)
                .ToList();

            return merchRequests;
        }

        public async Task<List<MerchRequest>> GetAllRequestsAsync(CancellationToken cancellationToken = default)
        {
            return _merchRequests;
        }
    }
}