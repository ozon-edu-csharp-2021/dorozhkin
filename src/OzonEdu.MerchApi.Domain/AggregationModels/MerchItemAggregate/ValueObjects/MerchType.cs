using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchType : Enumeration
    {
        public static MerchType WelcomePack = new(1, nameof(WelcomePack), new Sku(228));

        public Sku Sku;
        
        public MerchType(int id, string name, Sku sku) : base(id, name)
        {
            Sku = sku;
        }
    }
}