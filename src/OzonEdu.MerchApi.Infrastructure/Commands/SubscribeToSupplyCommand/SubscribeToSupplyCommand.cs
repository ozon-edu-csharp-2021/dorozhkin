using System.Collections.Generic;
using MediatR;

namespace OzonEdu.MerchApi.Infrastructure.Commands.SubscribeToSupplyCommand
{
    public class SubscribeToSupplyCommand : IRequest<SubscribeToSupplyCommandResponse>
    {
        public IEnumerable<long> SkuCollection { get; set; }
    }
}