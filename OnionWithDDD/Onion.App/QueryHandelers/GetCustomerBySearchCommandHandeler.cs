using AutoMapper;
using MediatR;
using Onion.App.Queries.Customers;
using Onion.Core.Models.Infrastructure;
using Onion.Core.Models.ViewModels;
using Onion.Core.Repositories.CustomRepositories;
using Onion.Domain.BusinessDomain;

namespace Onion.App.QueryHandelers
{


    public class GetCustomerBySearchCommandHandeler : IRequestHandler<GetCustomerBySearchCommand, PagedListModel<CustomerVm>>
    {
        private readonly ICustomerReadonlyRepository _customerReadRepository;
        private readonly IMapper _mapper;

        public GetCustomerBySearchCommandHandeler(ICustomerReadonlyRepository customerReadRepository, IMapper mapper)
        {
            _customerReadRepository = customerReadRepository;
            _mapper = mapper;
        }

        public async Task<PagedListModel<CustomerVm>> Handle(GetCustomerBySearchCommand request, CancellationToken cancellationToken)
        {
            PagedListModel<CustomerVm> pagedList = new PagedListModel<CustomerVm>(request.CurrentPage, request.PageSize);
            pagedList.QueryOptions.SortField = request.SortBy ?? pagedList.QueryOptions.SortField;

            IEnumerable<Customer> customers = await _customerReadRepository.FindAsync(pagedList.QueryOptions,
                c =>
                    (request.Id == null || request.Id == c.Id) &&
                    (request.CustomerStatus == null || request.CustomerStatus.Equals(c.CustomerStatus)) &&
                    (string.IsNullOrWhiteSpace(request.Name) || c.Name.Contains(request.Name))
                    );

            pagedList.DataList = _mapper.Map<IEnumerable<CustomerVm>>(customers);


            return pagedList;
        }
    }


}
