using MediatR;
using Onion.Domain.DomainEvents;

namespace Onion.App.EventHandelers
{ 
    public class CustomerActivatedEventHandeler : INotificationHandler<CustomerActivatedNotification>
    {
        public async Task Handle(CustomerActivatedNotification notification, CancellationToken cancellationToken)
        {
            await Task.Run(() => Console.WriteLine(
                $"The customer {notification.CustomerName} with id : {notification.Id} has been activated."), 
                cancellationToken);
        }
    }
}
