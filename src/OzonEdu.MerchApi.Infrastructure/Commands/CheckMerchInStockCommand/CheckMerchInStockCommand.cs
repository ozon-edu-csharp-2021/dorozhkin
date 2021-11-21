using System.Collections.Generic;
using MediatR;
using OzonEdu.MerchApi.Infrastructure.Commands.CreateAvailabilityMerchInStockRequestCommand;

namespace OzonEdu.MerchApi.Infrastructure.Commands.CheckMerchInStockCommand
{
    public class CheckMerchInStockCommand : IRequest<CheckMerchInStockCommandResponse>
    {
        public IEnumerable<long> SkuCollection { get; set; }
    }
}