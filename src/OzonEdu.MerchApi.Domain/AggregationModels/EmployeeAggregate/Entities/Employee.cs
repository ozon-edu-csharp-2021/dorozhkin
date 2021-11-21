using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.ValueObject;
using OzonEdu.MerchApi.Domain.Contracts;
using OzonEdu.MerchApi.Domain.Models;

namespace OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.Entities
{
    public class Employee : Entity, IAggregateRoot
    {
        public Employee(Name name, EmailAddress emailAddress, Phone phone)
        {
            Name = name;
            EmailAddress = emailAddress;
            Phone = phone;
        }

        public Name Name { get; }
        public EmailAddress EmailAddress { get; }
        public Phone Phone { get; }

        public void SetId(long id)
        {
            Id = id;
        }
    }
}