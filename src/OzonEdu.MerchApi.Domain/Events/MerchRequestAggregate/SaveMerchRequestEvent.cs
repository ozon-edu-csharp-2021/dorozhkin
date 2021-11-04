using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities;

namespace OzonEdu.MerchApi.Domain.Events.MerchRequestAggregate
{
    public class SaveMerchRequestEvent : INotification
    {
        public SaveMerchRequestEvent(MerchRequest merchRequest)
        {
            MerchRequest = merchRequest;
        }

        public MerchRequest MerchRequest { get; }
    }
}