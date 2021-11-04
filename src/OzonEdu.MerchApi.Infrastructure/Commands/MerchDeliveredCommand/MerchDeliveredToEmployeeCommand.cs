using MediatR;

namespace OzonEdu.MerchApi.Infrastructure.Commands.MerchDeliveredCommand
{
    public class MerchDeliveredToEmployeeCommand : IRequest
    {
        public long ReserveCodeStatus { get; set; }
        public long DeliveryCode { get; set; }
    }
}