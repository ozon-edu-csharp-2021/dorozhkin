using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchItemAggregate
{
    public class Quantity : ValueObject
    {
        public Quantity(int value, int minValue)
        {
            Value = value;
            MinValue = minValue;
        }

        public int Value { get; }
        public int MinValue { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return MinValue;
        }
    }
}