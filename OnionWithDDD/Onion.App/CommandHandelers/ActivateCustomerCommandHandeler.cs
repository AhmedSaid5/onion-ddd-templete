using MediatR;
using Onion.Core.Commands.Customers;
using Onion.Core.Services.CustomerServices;
using Onion.Domain.BusinessDomain;

namespace Onion.App.CommandHandelers
{
    public class ActivateCustomerCommandHandeler : IRequestHandler<ActivateCustomerCommand, bool>
    {
        private readonly ICustomerService _customerService;

        public ActivateCustomerCommandHandeler(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public async Task<bool> Handle(ActivateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await _customerService.GetByIdAsync(request.Id);

            if (customer == null)
                throw new InvalidOperationException("Customer not found");

            customer.ActivateCustomer();

            await _customerService.EditAsync(customer);



            return true;
        }
    }
}

