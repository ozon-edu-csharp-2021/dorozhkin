using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.ValueObjects;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities
{
    public class MerchItems : ValueObject
    {
        public MerchItems(List<MerchItem> items)
        {
            Items = items;
        }

        public List<MerchItem> Items { get; }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new System.NotImplementedException();
        }
    }
}