using MediatR;

namespace Onion.Core.Commands.Customers
{
    public class ActivateCustomerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

}
