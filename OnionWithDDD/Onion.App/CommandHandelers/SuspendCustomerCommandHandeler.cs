using MediatR;
using Onion.Core.Commands.Customers;
using Onion.Core.Services.CustomerServices;
using Onion.Domain.BusinessDomain;

namespace Onion.App.CommandHandelers
{
    public class SuspendCustomerCommandHandeler : IRequestHandler<SuspendCustomerCommand, bool>
    {

        private readonly ICustomerService _customerService;

        public SuspendCustomerCommandHandeler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<bool> Handle(SuspendCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await _customerService.GetByIdAsync(request.Id);

            if (customer == null)
                throw new InvalidOperationException("Customer not found");

            customer.SuspendCustomer();

            await _customerService.EditAsync(customer);
            return true;
        }
    }
}

