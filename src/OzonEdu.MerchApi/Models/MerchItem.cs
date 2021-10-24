namespace OzonEdu.MerchApi.Models
{
    public class MerchItem
    {
        public long Id { get; }
        public string MerchName { get; }
        
        public MerchItem(long id, string merchName)
        {
            Id = id;
            MerchName = merchName;
        }
    }
}