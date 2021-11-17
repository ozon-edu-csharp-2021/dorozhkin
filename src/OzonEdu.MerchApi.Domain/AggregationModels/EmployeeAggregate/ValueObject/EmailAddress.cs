using System.Collections.Generic;

namespace OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.ValueObject
{
    public class EmailAddress : Models.ValueObject
    {
        public string Value { get; }
        
        public EmailAddress(string name)
        {
            Value = name;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}