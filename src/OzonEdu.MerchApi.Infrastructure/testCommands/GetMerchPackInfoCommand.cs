using MediatR;

namespace OzonEdu.MerchApi.Infrastructure.Commands
{
    public class GetMerchPackInfoCommand : IRequest<MerchPackInfoCommandResponse>
    {
        public string Name { get; set; }
    }
}