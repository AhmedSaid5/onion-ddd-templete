using MediatR;

namespace Onion.Core.Commands.Customers
{
    public class SuspendCustomerCommand : IRequest<bool>
        {
            public Guid Id { get; set; }
        }

}
