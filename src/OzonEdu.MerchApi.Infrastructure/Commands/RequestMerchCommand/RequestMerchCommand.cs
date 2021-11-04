using MediatR;

namespace OzonEdu.MerchApi.Infrastructure.Commands.RequestMerchCommand
{
    public class RequestMerchCommand : IRequest<RequestMerchCommandResponse>
    {
        public long EmployeeId { get; set; }
        public int MerchPackId { get; set; }
        // public TestMerchPackEnum MerchPack { get; set; }
    }
}