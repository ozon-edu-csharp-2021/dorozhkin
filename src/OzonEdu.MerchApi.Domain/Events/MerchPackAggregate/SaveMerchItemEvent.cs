using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.Entities;

namespace OzonEdu.MerchApi.Domain.Events.MerchPackAggregate
{
    public class SaveMerchItemEvent : INotification
    {
        public SaveMerchItemEvent(MerchItem merchItem)
        {
            MerchItem = merchItem;
        }

        public MerchItem MerchItem { get; }
    }
}