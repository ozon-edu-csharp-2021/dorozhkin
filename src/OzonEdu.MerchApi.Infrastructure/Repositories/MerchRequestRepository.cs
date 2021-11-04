using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.ValueObjects;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities;
using OzonEdu.MerchApi.Domain.Contracts;

namespace OzonEdu.MerchApi.Infrastructure.Repositories
{
    public class MerchRequestRepository : IMerchRequestRepository
    {
        public MerchRequestRepository()
        {
            var merchRequest1 = new MerchRequest(new NamePack("WelcomePack"), 1, 1, new long[] {111, 222, 333});
            var merchRequest2 = new MerchRequest(new NamePack("WelcomePack"), 1, 2, new long[] {111, 222, 333});
            merchRequest1.ChangeId(1);
            merchRequest2.ChangeId(2);
            
            _merchRequests = new List<MerchRequest> { merchRequest1, merchRequest2 };
        }

        private readonly List<MerchRequest> _merchRequests;

        public IUnitOfWork UnitOfWork { get; }
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

        public async Task<MerchRequest> FindByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default)
        {
            return _merchRequests.FirstOrDefault(x => x.EmployeeId == employeeId);
        }

        public async Task<List<MerchRequest>> GetAllRequests(CancellationToken cancellationToken = default)
        {
            return _merchRequests;
        }
    }
}