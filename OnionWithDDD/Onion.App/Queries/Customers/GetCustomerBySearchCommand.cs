using MediatR;
using Onion.Core.Models.Enums;
using Onion.Core.Models.Infrastructure;
using Onion.Core.Models.ViewModels;
using Onion.Domain.BusinessDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.App.Queries.Customers
{

    public class GetCustomerBySearchCommand : BaseSearchModel, IRequest<PagedListModel<CustomerVm>>
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public CustomerStatuses? CustomerStatus { get; set; }

    }


}
