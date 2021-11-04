using MediatR;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.Entities;

namespace OzonEdu.MerchApi.Domain.Events.MerchPackAggregate
{
    public class SaveMerchPackEvent 
    {
        //todo add notification
        public SaveMerchPackEvent(MerchPack merchPack)
        {
            MerchPack = merchPack;
        }

        public MerchPack MerchPack { get; }
    }
}