using Onion.Core.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Onion.Core.Repositories.BaseRepositories
{
    public interface IBaseReadRepository<TEntity> where TEntity : class
    {
        #region Select

        TEntity GetById(object id);

        IEnumerable<TEntity> Get(BaseSearchModel searchModel);

        IEnumerable<TEntity> Get(BaseSearchModel searchModel, params string[] includingTables);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetAll(params string[] includingTables);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params string[] includingTables);

        IEnumerable<TEntity> Find(BaseSearchModel searchModel, Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> Find(BaseSearchModel searchModel, Expression<Func<TEntity, bool>> predicate, params string[] includingTables);

        bool Any(Expression<Func<TEntity, bool>> predicate);

        bool Any(Expression<Func<TEntity, bool>> predicate, params string[] includingTables);

        int Count();

        int Count(Expression<Func<TEntity, bool>> predicate);

        T Max<T>(Expression<Func<TEntity, T>> predicate);

        T Max<T>(Expression<Func<TEntity, T>> predicate, Expression<Func<TEntity, bool>> predicateCondition);

        #endregion Select

        #region Select Async

        Task<TEntity> GetByIdAsync(object id);

        Task<IEnumerable<TEntity>> GetAsync(BaseSearchModel searchModel);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> GetAllAsync(params string[] includingTables);

        Task<IEnumerable<TEntity>> GetAsync(BaseSearchModel searchModel, params string[] includingTables);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, params string[] includingTables);

        Task<IEnumerable<TEntity>> FindAsync(BaseSearchModel searchModel, Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> FindAsync(BaseSearchModel searchModel, Expression<Func<TEntity, bool>> predicate, params string[] includingTables);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, params string[] includingTables);

        Task<int> CountAsync();

        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);

        Task<T> MaxAsync<T>(Expression<Func<TEntity, T>> predicate);

        Task<T> MaxAsync<T>(Expression<Func<TEntity, T>> predicate, Expression<Func<TEntity, bool>> predicateCondition);

        #endregion Select Async

    }
}
