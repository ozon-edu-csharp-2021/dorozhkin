using System.Collections.Generic;
using MediatR;

namespace OzonEdu.MerchApi.Infrastructure.Commands.ReserveMerchInStockCommand
{
    public class ReserveMerchInStockCommand : IRequest<ReserveMerchInStockCommandResponse>
    {
        public IEnumerable<long> SkuCollection { get; set; }
    }
}