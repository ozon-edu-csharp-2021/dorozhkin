using MediatR;

namespace OzonEdu.MerchApi.Domain.Events
{
    public class TestingEvent : INotification
    {
        public TestingEvent(long sku)
        {
            Sku = sku;
        }

        public long Sku { get; set; }
    }
}