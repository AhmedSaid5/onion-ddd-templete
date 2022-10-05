using MediatR;

namespace Onion.App.Commands.Customers
{
    public class DeleteCustomerCommand : IRequest<bool>
        {
            public Guid Id { get; set; }
        }

}
