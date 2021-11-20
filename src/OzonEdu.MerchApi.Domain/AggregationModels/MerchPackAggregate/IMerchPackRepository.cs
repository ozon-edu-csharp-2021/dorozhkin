using System.Threading;
using System.Threading.Tasks;
using OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate.Entities;
using OzonEdu.MerchApi.Domain.Contracts;

namespace OzonEdu.MerchApi.Domain.AggregationModels.MerchPackAggregate
{
    public interface IMerchPackRepository : IRepository<MerchPack>
    {
        /// <summary>
        /// Найти набор мерча по идентфикатору
        /// </summary>
        /// <param name="merchPackId">Идентификатор набора мерча</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Набор Мерча</returns>
        Task<MerchPack> FindByIdAsync(long merchPackId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Создать товар для мерча
        /// </summary>
        /// <param name="merchItemToSave">Новый товар для мерча</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Товар для мерча</returns>
        Task<MerchItem> CreateMerchItemByIdAsync(MerchItem merchItemToSave,
            CancellationToken cancellationToken = default);
        
        /// <summary>
        /// Найти мерч по идентфикатору
        /// </summary>
        /// <param name="sku">Идентификатор мерча</param>
        /// <param name="cancellationToken">Токен для отмены операции. <see cref="CancellationToken"/></param>
        /// <returns>Мерч</returns>
        Task<MerchItem> FindMerchItemBySkuAsync(long sku, CancellationToken cancellationToken = default);
    }
}