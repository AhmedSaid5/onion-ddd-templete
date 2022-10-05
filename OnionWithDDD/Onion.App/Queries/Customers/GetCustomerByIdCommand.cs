using MediatR;
using Onion.Core.Models.ViewModels;

namespace Onion.App.Queries.Customers
{
    public class GetCustomerByIdCommand : IRequest<CustomerVm>
    {
        public Guid Id { get; set; }
    }


}
