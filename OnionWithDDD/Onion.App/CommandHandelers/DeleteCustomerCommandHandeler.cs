using MediatR;
using Onion.Core.Commands.Customers;
using Onion.Core.Services.CustomerServices;
using Onion.Domain.BusinessDomain;

namespace Onion.App.CommandHandelers
{

    public class DeleteCustomerCommandHandeler : IRequestHandler<DeleteCustomerCommand, bool>
    {
        private readonly ICustomerService _customerService;

        public DeleteCustomerCommandHandeler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await _customerService.GetByIdAsync(request.Id);

            if (customer == null)
                throw new InvalidOperationException("Customer not found");

            await _customerService.RemoveAsync(customer);
            return true;
        }
    }
}

