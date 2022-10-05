using AutoMapper;
using MediatR;
using Onion.App.Queries.Customers;
using Onion.Core.Models.ViewModels;
using Onion.Core.Repositories.CustomRepositories;
using Onion.Domain.BusinessDomain;

namespace Onion.App.QueryHandelers
{
    public class GetCustomerByIdCommandHandeler : IRequestHandler<GetCustomerByIdCommand, CustomerVm>
    {
        private readonly ICustomerReadonlyRepository _customerReadRepository;
        private readonly IMapper _mapper;

        public GetCustomerByIdCommandHandeler(ICustomerReadonlyRepository customerReadRepository, IMapper mapper)
        {
            _customerReadRepository = customerReadRepository;
            _mapper = mapper;
        }
        public async Task<CustomerVm> Handle(GetCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await _customerReadRepository.GetByIdAsync(request.Id);

            if (customer == null)
                throw new InvalidOperationException("Customer not found");

            CustomerVm retCustomer = _mapper.Map<CustomerVm>(customer);

            return retCustomer;
        }
    }


}
