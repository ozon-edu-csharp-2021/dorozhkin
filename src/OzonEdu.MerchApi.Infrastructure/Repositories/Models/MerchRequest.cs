namespace OzonEdu.MerchApi.Infrastructure.Repositories.Models
{
    public class MerchRequest
    {
        public long Id { get; set; }
        public long StatusId { get; set; }
        public long MerchPackId { get; set; }
        public long EmployeeId { get; set; }
        public long? SupplyCodeId { get; set; }
        public long? ReserveCodeId { get; set; }
        public long? DeliveryCodeId { get; set; }
    }
}