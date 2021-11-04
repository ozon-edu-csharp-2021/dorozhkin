using System.Collections.Generic;
using MediatR;

namespace OzonEdu.MerchApi.Infrastructure.Commands.CreateAvailabilityMerchInStockRequestCommand
{
    public class CheckMerchInStockCommand : IRequest<CheckMerchInStockCommandResponse>
    {
        public IReadOnlyCollection<long> SkuCollection { get; set; }
    }
}