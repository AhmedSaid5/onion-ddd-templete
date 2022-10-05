using Onion.Core.Repositories.BaseRepositories;
using Onion.Domain.BusinessDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Core.Repositories.CustomRepositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
    }
}
