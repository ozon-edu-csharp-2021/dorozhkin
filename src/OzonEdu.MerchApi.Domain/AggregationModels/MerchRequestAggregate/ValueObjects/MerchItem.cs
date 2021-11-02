using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.ValueObjects
{
    public class MerchItem : ValueObject
    {
        public MerchItem(Name name)
        {
            Name = name;
        }

        public Name Name { get; }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}