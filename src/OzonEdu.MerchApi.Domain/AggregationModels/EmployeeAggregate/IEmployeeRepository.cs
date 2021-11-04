using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate.Entities;
using OzonEdu.MerchApi.Domain.Contracts;

namespace OzonEdu.MerchApi.Domain.AggregationModels.EmployeeAggregate
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        /// <summary>
        /// Найти запрос на мерч по идентфикатору сотрудника
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Сотрудник</returns>
        Task<Employee> FindByIdAsync(long employeeId, CancellationToken cancellationToken = default);
        
        //todo summary
        Task<Employee> FindByNameAsync(string employeeName, CancellationToken cancellationToken = default);

    }
}