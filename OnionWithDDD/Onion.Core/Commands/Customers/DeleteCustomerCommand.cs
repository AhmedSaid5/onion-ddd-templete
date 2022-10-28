using MediatR;

namespace Onion.Core.Commands.Customers
{
    public class DeleteCustomerCommand : IRequest<bool>
        {
            public Guid Id { get; set; }
        }

}
