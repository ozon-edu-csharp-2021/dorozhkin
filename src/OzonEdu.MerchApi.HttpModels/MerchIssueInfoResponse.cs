using System.Collections.Generic;

namespace OzonEdu.MerchApi.HttpModels
{
    public class MerchIssueInfoResponse
    {
        public List<MerchIssueInfo> MerchIssuesInfo { get; set; }
    }

    public class MerchIssueInfo
    {
        public string MerchPack { get; set; }
        public string Status { get; set; }
    }
}