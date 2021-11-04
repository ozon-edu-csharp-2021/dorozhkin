using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities;

namespace OzonEdu.MerchApi.Domain.Events.MerchRequestAggregate
{
    public class SaveMerchRequestEvent 
    {
        //todo add notification
        public SaveMerchRequestEvent(MerchRequest merchRequest)
        {
            MerchRequest = merchRequest;
        }

        public MerchRequest MerchRequest { get; }
    }
}