using MediatR;

namespace Onion.Core.Commands.Customers
{
    public class UpdateCustomerCommand : IRequest<bool>
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string Zipcode { get; set; }

            public List<CustomerContactCommand> CustomerContacts { get; set; }

        }

}
