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

        //todo add summary
        Task<MerchItem> CreateMerchItemByIdAsync(MerchItem merchItemToSave,
            CancellationToken cancellationToken = default);
    }
}