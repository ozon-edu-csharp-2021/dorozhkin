using System.Collections.Generic;

namespace OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.ValueObject
{
    public class Phone : Models.ValueObject
    {
        public string Value { get; }
        
        public Phone(string name)
        {
            Value = name;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}