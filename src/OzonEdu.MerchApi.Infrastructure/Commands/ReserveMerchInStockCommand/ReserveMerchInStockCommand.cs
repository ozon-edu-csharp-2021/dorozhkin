using System.Collections.Generic;
using MediatR;

namespace OzonEdu.MerchApi.Infrastructure.Commands.ReserveMerchInStockCommand
{
    public class ReserveMerchInStockCommand : IRequest<ReserveMerchInStockCommandResponse>
    {
        public IReadOnlyCollection<long> SkuCollection { get; set; }
    }
}