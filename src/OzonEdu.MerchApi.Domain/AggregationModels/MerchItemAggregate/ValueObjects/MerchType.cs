using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchType : Enumeration
    {
        //MerchType это типа ВелкомПак, который хранит несколько Sku
        public static MerchType WelcomePack = new(1, nameof(WelcomePack), new Sku(228));

        public Sku Sku;
        
        public MerchType(int id, string name, Sku sku) : base(id, name)
        {
            Sku = sku;
        }
    }
}