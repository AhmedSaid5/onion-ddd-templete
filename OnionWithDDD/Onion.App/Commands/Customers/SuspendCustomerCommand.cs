using MediatR;

namespace Onion.App.Commands.Customers
{
    public class SuspendCustomerCommand : IRequest<bool>
        {
            public Guid Id { get; set; }
        }

}
