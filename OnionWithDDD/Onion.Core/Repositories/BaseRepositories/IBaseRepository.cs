using Onion.Core.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Core.Repositories.BaseRepositories
{
    public interface IBaseRepository<TEntity> : IBaseReadRepository<TEntity> where TEntity : class
    {
        #region Insert

        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        #endregion Insert

        #region Update

        void Edit(TEntity entity);

        #endregion Update

        #region Delete

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        #endregion Delete
    }
}
