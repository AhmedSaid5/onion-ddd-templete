using Onion.Core.Repositories.CustomRepositories;
using Onion.Domain.BusinessDomain;
using Onion.Infra.DbContexts;
using Onion.Infra.Repositories.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Infra.Repositories.CustomRepository
{
    public class CustomerReadonlyRepository : BaseReadRepository<Customer>, ICustomerReadonlyRepository
    {
        public CustomerReadonlyRepository(ReedingDbContext dbContext)
            :base(dbContext)
        {

        }
    }
}
