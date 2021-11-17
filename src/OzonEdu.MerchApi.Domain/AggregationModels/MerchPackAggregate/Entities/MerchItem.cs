using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.ValueObjects;
using OzonEdu.MerchApi.Domain.Events.MerchPackAggregate;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.Entities
{
    public class MerchItem : Entity
    {
        public MerchItem(NameItem nameItem, Sku sku)
        {
            NameItem = nameItem;
            Sku = sku;
        }

        public NameItem NameItem { get; }
        public Sku Sku { get; }

        public void SaveMerchItem()
        {
            var saveMerchItemEvent = new SaveMerchItemEvent(this);
            AddDomainEvent(saveMerchItemEvent);
        }
    }
}