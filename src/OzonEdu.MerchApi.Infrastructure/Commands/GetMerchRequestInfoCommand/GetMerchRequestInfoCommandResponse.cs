using System.Collections.Generic;

namespace OzonEdu.MerchApi.Infrastructure.Commands.GetMerchRequestInfoCommand
{
    public class GetMerchRequestInfoCommandResponse
    {
        public List<MerchIssueInfo> MerchIssuesInfo { get; set; }
    }
    
    public class MerchIssueInfo
    {
        public string MerchPack { get; set; }
        public string Status { get; set; }
    }
}