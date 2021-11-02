using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.ValueObjects;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate
{
    public class MerchRequest : Entity
    {
        public MerchRequest(MerchRequestStatus merchRequestStatus, Employee employee, MerchPack merchPack)
        {
            MerchRequestStatus = merchRequestStatus;
            Employee = employee;
            MerchPack = merchPack;
        }

        public MerchRequestStatus MerchRequestStatus { get; }
        public Employee Employee { get; }
        public MerchPack MerchPack { get; }
    }
}