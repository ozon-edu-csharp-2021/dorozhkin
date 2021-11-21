using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.ValueObjects
{
    public class MerchRequestStatus : Enumeration
    {
        public static MerchRequestStatus Created = new(1, nameof(Created));
        public static MerchRequestStatus InProcess = new(2, nameof(InProcess));
        public static MerchRequestStatus WaitingSupply = new(3, nameof(WaitingSupply));
        public static MerchRequestStatus Closed = new(4, nameof(Closed));
        
        public MerchRequestStatus(int id, string name) : base(id, name)
        {
        }
    }
}