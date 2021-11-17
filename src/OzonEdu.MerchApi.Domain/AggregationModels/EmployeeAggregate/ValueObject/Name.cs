using System.Collections.Generic;

namespace OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.ValueObject
{
    public class Name : Models.ValueObject
    {
        public string Value { get; }
        
        public Name(string name)
        {
            Value = name;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}