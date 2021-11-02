using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OzonEdu.MerchApi.Domain.Events;

namespace OzonEdu.MerchApi.Infrastructure.Handlers.DomainEvents
{
    public class TestDomainEventHandler : INotificationHandler<TestingEvent>
    {
        public Task Handle(TestingEvent notification, CancellationToken cancellationToken)
        {
            var message = $"LOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOG! = {notification.Sku}";
            return Task.CompletedTask;
        }
    }
}