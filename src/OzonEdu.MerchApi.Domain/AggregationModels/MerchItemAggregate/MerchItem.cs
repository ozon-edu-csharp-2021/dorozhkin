using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchItemAggregate
{
    public class MerchItem : Entity
    {
        public MerchItem(Sku sku)
        {
            Sku = sku;
        }
        
        public Sku Sku { get; }
        public string Name { get; set; }
        public MerchType MerchType { get; set; }
        public int ClothingSize { get; set; }
        public int Quantity { get; set; }
    }
}