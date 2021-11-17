using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Infrastructure.Commands.CheckMerchInStockCommand;
using OzonEdu.MerchApi.Infrastructure.Commands.CreateAvailabilityMerchInStockRequestCommand;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.StockRequestAggregate
{
    public class AvailabilityMerchInStockRequestCommandHandler : IRequestHandler<
        CheckMerchInStockCommand, CheckMerchInStockCommandResponse>
    {
        public async Task<CheckMerchInStockCommandResponse> Handle(
            CheckMerchInStockCommand request, CancellationToken cancellationToken)
        {
            //todo тут должно проверяться наличие данного мерча на складе через запрос к stock-api, но допустим он есть

            var createAvailabilityMerchInStockRequestCommandResponse = new CheckMerchInStockCommandResponse
            {
                InStock = true
            };
            
            return createAvailabilityMerchInStockRequestCommandResponse;
        }
    }
}