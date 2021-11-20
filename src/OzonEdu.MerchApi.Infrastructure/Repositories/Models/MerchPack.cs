namespace OzonEdu.MerchApi.Infrastructure.Repositories.Models
{
    public class MerchPack
    {
        public long Id { get; set; }
        public string NamePack { get; set; }
        public long[] MerchSkus { get; set; }
    }
}