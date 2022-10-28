using MediatR;
using Onion.Core.Commands.Customers;
using Onion.Core.Services.CustomerServices;
using Onion.Domain.BusinessDomain;

namespace Onion.App.CommandHandelers
{
    public class CreateCustomerCommandHandeler : IRequestHandler<CreateCustomerCommand, Guid>
    {
        private readonly ICustomerService _customerService;

        public CreateCustomerCommandHandeler(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<Guid> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer newCustomer = new Customer(request.Name);
            newCustomer.SetCustomerAddess(new Address(request.Street, request.City, request.Street, request.Country, request.Zipcode));

            if (request.CustomerContacts != null && request.CustomerContacts.Any())
                request.CustomerContacts.ForEach(c =>
                {
                    newCustomer.AddContact(c.Name, c.ContactType, c.ContactInfo);
                });

            await _customerService.AddAsync(newCustomer);

            return newCustomer.Id;
        }
    }
}

