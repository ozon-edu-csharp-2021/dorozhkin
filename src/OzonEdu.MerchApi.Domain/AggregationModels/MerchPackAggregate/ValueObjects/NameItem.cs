using System;
using System.Collections.Generic;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.ValueObjects
{
    public class NameItem : ValueObject
    {
        public string Value { get; }
        
        public NameItem(string name)
        {
            if (name == "")
                throw new Exception("Name is empty!");
            
            Value = name;
        }
        
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}