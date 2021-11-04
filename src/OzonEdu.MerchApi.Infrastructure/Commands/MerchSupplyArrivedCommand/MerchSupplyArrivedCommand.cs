using System.Collections.Generic;
using MediatR;

namespace OzonEdu.MerchApi.Infrastructure.Commands.MerchSupplyArrivedCommand
{
    public class MerchSupplyArrivedCommand : IRequest
    {
        public IReadOnlyCollection<long> SkuCollection { get; set; }
        public int Quantity { get; set; }
    }
}