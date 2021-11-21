using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.Entities;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.ValueObject;
using OzonEdu.MerchApi.Infrastructure.Repositories.Infrastructure.Interfaces;

namespace OzonEdu.MerchApi.Infrastructure.Repositories.Implementation
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnectionFactory<NpgsqlConnection> _dbConnectionFactory;
        private readonly IChangeTracker _changeTracker;
        private const int Timeout = 5;   
        
        private readonly List<Employee> _employees;

        public EmployeeRepository(IDbConnectionFactory<NpgsqlConnection> dbConnectionFactory, IChangeTracker changeTracker)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _changeTracker = changeTracker;
        }

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
            const string sql = @"
                SELECT *
                FROM employees
                WHERE id = @Id;";
            
            var parameters = new
            {
                Id = employeeId,
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var employeeModel = await connection.QueryFirstAsync<Models.Employee>(commandDefinition);

            var employee = new Employee(
                new Name(employeeModel.Name),
                new EmailAddress(employeeModel.Email),
                new Phone(employeeModel.Phone));
            
            employee.SetId(employeeModel.Id);

            _changeTracker.Track(employee);
            return employee;
        }

        public async Task<Employee> FindByNameAsync(string employeeName, CancellationToken cancellationToken = default)
        {
            const string sql = @"
                SELECT *
                FROM employees
                WHERE name = @Name;";
            
            var parameters = new
            {
                Name = employeeName,
            };
            var commandDefinition = new CommandDefinition(
                sql,
                parameters: parameters,
                commandTimeout: Timeout,
                cancellationToken: cancellationToken);
            var connection = await _dbConnectionFactory.CreateConnection(cancellationToken);
            var employeeModel = await connection.QueryFirstAsync<Models.Employee>(commandDefinition);

            var employee = new Employee(
                new Name(employeeModel.Name),
                new EmailAddress(employeeModel.Email),
                new Phone(employeeModel.Phone));

            employee.SetId(employeeModel.Id);
            
            _changeTracker.Track(employee);
            return employee;
        }
    }
}