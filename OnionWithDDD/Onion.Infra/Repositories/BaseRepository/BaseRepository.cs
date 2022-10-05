using Microsoft.EntityFrameworkCore;
using Onion.Core.Models.Infrastructure;
using Onion.Core.Repositories.BaseRepositories;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Onion.Infra.Repositories.BaseRepository
{
    public class BaseRepository<TEntity> : BaseReadRepository<TEntity>, IBaseRepository<TEntity> where TEntity : class
    {
        #region Fields

        private readonly DbContext _databaseContext;
        private readonly DbSet<TEntity> _entitiesSet;

        #endregion Fields

        #region ctor

        public BaseRepository(DbContext databaseContext)
            :base(databaseContext)
        {
            _databaseContext = databaseContext;
            _entitiesSet = _databaseContext.Set<TEntity>();
        }

        #endregion ctor

        #region Repository

        #region Add

        public void Add(TEntity entity)
        {
            _entitiesSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _entitiesSet.AddRange(entities);
        }

        #endregion Add

        #region Edit

        public void Edit(TEntity entity)
        {
            _entitiesSet.Update(entity);
        }

        public void EditRange(IEnumerable<TEntity> entities)
        {
            _entitiesSet.UpdateRange(entities);
        }

        #endregion Edit

        #region Remove

        public void Remove(TEntity entity)
        {
            _entitiesSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _entitiesSet.RemoveRange(entities);
        }

        #endregion Remove

        #endregion Repository
    }
}
