using Onion.App.Services.BaseServices;
using Onion.Core.Repositories.CustomRepositories;
using Onion.Core.Services.CustomerServices;
using Onion.Core.UnitOfWork;
using Onion.Domain.BusinessDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.App.Services.CustomerServices
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork, ICustomerRepository customerRepository)
            : base(unitOfWork, customerRepository)
        {

        }
    }
}
