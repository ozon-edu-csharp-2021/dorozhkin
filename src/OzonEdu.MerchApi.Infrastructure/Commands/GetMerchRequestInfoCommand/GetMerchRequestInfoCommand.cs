using MediatR;

namespace OzonEdu.MerchApi.Infrastructure.Commands.GetMerchRequestInfoCommand
{
    public class GetMerchRequestInfoCommand : IRequest<GetMerchRequestInfoCommandResponse>
    {
        public string EmployeeName { get; set; }
    }
}