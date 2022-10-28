using MediatR;
using Onion.Core.Commands.Customers;
using Onion.Core.Services.CustomerServices;
using Onion.Domain.BusinessDomain;

namespace Onion.App.CommandHandelers
{

    public class UpdateCustomerCommandHandeler : IRequestHandler<UpdateCustomerCommand, bool>
    {

        private readonly ICustomerService _customerService;

        public UpdateCustomerCommandHandeler(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await _customerService.GetByIdAsync(request.Id);

            customer.ModifyName(request.Name);
            customer.SetCustomerAddess(new Address(request.Street, request.City, request.Street, request.Country, request.Zipcode));

            customer.RemoveAllContacts();

            if (request.CustomerContacts != null && request.CustomerContacts.Any())
                request.CustomerContacts.ForEach(c =>
                {
                    customer.AddContact(c.Name, c.ContactType, c.ContactInfo);
                });

            await _customerService.EditAsync(customer);

            return true;
        }
    }
}
