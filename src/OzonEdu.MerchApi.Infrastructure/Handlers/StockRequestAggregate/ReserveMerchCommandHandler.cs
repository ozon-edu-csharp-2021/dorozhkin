using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Infrastructure.Commands.ReserveMerchInStockCommand;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.StockRequestAggregate
{
    public class ReserveMerchCommandHandler : IRequestHandler<ReserveMerchInStockCommand, ReserveMerchInStockCommandResponse>
    {
        public async Task<ReserveMerchInStockCommandResponse> Handle(ReserveMerchInStockCommand request, CancellationToken cancellationToken)
        {
            //todo тут должен быть запрос на резевер мерч на склад через запрос к stock-api, но допустим он есть

            var reserveMerchInStockCommandResponse = new ReserveMerchInStockCommandResponse
            {
                ReserveCodeStatus = 555
            };

            return reserveMerchInStockCommandResponse;
        }
    }
}