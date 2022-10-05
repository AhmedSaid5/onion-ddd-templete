using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
