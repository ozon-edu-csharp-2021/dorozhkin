namespace OzonEdu.MerchApi.Models
{
    public class MerchIssueInfo
    {
        public string MerchName { get; }
        public int Quantity { get; }
        
        public MerchIssueInfo(int quantity, string merchName)
        {
            MerchName = merchName;
            Quantity = quantity;
        }
    }
}