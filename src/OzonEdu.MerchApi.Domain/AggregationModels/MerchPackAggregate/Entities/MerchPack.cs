using System.Collections.Generic;
using System.Linq;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.ValueObjects;
using OzonEdu.MerchApi.Domain.Contracts;
using OzonEdu.MerchApi.Domain.Events.MerchPackAggregate;
using OzonEdu.MerchApi.Domain.Models;
using Sku = OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.ValueObjects.Sku;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.Entities
{
    public class MerchPack : Entity, IAggregateRoot
    {
        public MerchPack(NamePack namePack, IEnumerable<MerchItem> merchItems)
        {
            NamePack = namePack;
            MerchItems = merchItems.ToList();
        }

        public NamePack NamePack { get; }
        public IReadOnlyList<MerchItem> MerchItems { get; private set; }

        public MerchPack AddMerchItem(NameItem nameItem, Sku sku)
        {
            var merchItems = MerchItems.ToList();
            var newMerchItem = new MerchItem(nameItem, sku);
            merchItems.Add(newMerchItem);
            MerchItems = merchItems;
            
            newMerchItem.SaveMerchItem();
            SaveMerchPackDomainEvent();
            
            return this;
        }

        private void SaveMerchPackDomainEvent()
        {
            var saveMerchPackEvent = new SaveMerchPackEvent(this);
            AddDomainEvent(saveMerchPackEvent);
        }
    }
}