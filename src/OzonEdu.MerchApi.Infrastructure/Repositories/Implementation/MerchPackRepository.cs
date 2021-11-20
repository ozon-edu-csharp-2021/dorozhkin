using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.ValueObjects;

namespace OzonEdu.MerchApi.Infrastructure.Repositories.Implementation
{
    public class MerchPackRepository : IMerchPackRepository
    {
        public MerchPackRepository()
        {
            var thirt = new MerchItem(new NameItem("T-Shirt"), new Sku(111));
            var socks = new MerchItem(new NameItem("Socks"), new Sku(222));
            var pen = new MerchItem(new NameItem("Pen"), new Sku(333));
            var cap = new MerchItem(new NameItem("Cap"), new Sku(444));
            var sweatshirt = new MerchItem(new NameItem("Sweatshirt"), new Sku(555));

            var welcomePack = new MerchPack(new NamePack("WelcomePack"), new[] {thirt, socks, pen});
            var conferenceListenerPack = new MerchPack(new NamePack("ConferenceListenerPack"), new[] {thirt, socks, pen, cap});
            var veteranPack = new MerchPack(new NamePack("VeteranPack"), new[] {thirt, socks, pen, cap, sweatshirt});

            welcomePack.ChangeId(1);
            conferenceListenerPack.ChangeId(2);
            veteranPack.ChangeId(3);

            _merchPacks = new List<MerchPack> {welcomePack, conferenceListenerPack, veteranPack};
        }

        private readonly List<MerchPack> _merchPacks;

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
            return _merchPacks.FirstOrDefault(x => x.Id == merchPackId);
        }

        public async Task<MerchItem> CreateMerchItemByIdAsync(MerchItem merchItemToSave,
            CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<MerchPack> FindMerchItemByIdAsync(long merchItemId, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}