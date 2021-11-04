using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.ValueObject;
using OzonEdu.MerchApi.Domain.Contracts;

namespace OzonEdu.MerchApi.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public EmployeeRepository()
        {
            var vasya = new Employee(new Name("Vasya Ivanov"), 
                new EmailAddress("vasya@ozon.ru"),
                new Phone("88005553535"));
            var stepan = new Employee(new Name("Stepan Chirochkin"), 
                new EmailAddress("stepan@ozon.ru"),
                new Phone("88005553535"));
            var mark = new Employee(new Name("Mark Zukerberg"), 
                new EmailAddress("mark@ozon.ru"),
                new Phone("88005553535"));

            vasya.ChangeId(1);
            stepan.ChangeId(2);
            mark.ChangeId(3);

            _employees = new List<Employee> {vasya, stepan, mark};
        }
        
        private readonly List<Employee> _employees;

        public IUnitOfWork UnitOfWork { get; }
        public Task<Employee> CreateAsync(Employee itemToCreate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Employee> UpdateAsync(Employee itemToUpdate, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Employee> FindByIdAsync(long employeeId, CancellationToken cancellationToken = default)
        {
            return _employees.FirstOrDefault(x => x.Id == employeeId);
        }

        public async Task<Employee> FindByNameAsync(string employeeName, CancellationToken cancellationToken = default)
        {
            return _employees.FirstOrDefault(x => x.Name.Value == employeeName);
        }
    }
}