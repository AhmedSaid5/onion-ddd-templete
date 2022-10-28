using MediatR;

namespace Onion.Core.Commands.Customers
{
    public class CreateCustomerCommand : IRequest<Guid>
        {
            public string Name { get; set; }
            public string Street { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string Zipcode { get; set; }

            public List<CustomerContactCommand> CustomerContacts { get; set; }

        }

}
