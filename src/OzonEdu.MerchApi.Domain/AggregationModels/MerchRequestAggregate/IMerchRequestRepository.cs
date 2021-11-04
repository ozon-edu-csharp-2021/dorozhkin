using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate.Entities;
using OzonEdu.MerchApi.Domain.Contracts;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchRequestAggregate
{
    public interface IMerchRequestRepository : IRepository<MerchRequest>
    {
        /// <summary>
        /// Найти товарную позицию по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор товарной позиции</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Товарная позиция</returns>
        Task<MerchRequest> FindByIdAsync(long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Найти запрос на мерч по идентфикатору сотрудника
        /// </summary>
        /// <param name="employeeId">Идентификатор сотрудника</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Запрос на мерч</returns>
        Task<MerchRequest> FindByEmployeeIdAsync(long employeeId, CancellationToken cancellationToken = default);
    }
}