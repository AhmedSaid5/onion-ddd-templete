using MediatR;

namespace Onion.App.Commands.Customers
{
    public class ActivateCustomerCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

}
