using System;

namespace OzonEdu.MerchApi.Models
{
    public class MerchIssueModel
    {
        public MerchIssueModel(string merchName, string employeeName)
        {
            MerchName = merchName;
            EmployeeName = employeeName;
        }

        public string MerchName { get; }
        public string EmployeeName { get; }
    }
}