using Microsoft.EntityFrameworkCore;
using Onion.Core.Models.Infrastructure;
using Onion.Core.Repositories.BaseRepositories;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Onion.Infra.Repositories.BaseRepository
{
    public class BaseReadRepository<TEntity> : IBaseReadRepository<TEntity> where TEntity : class
    {
        #region Fields

        private readonly DbContext _databaseContext;
        private readonly DbSet<TEntity> _entitiesSet;

        #endregion Fields

        #region ctor

        public BaseReadRepository(DbContext databaseContext)
        {
            _databaseContext = databaseContext;
            _entitiesSet = _databaseContext.Set<TEntity>();
        }

        #endregion ctor

        #region select

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _entitiesSet.Any(predicate);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate, params string[] includingTables)
        {
            IQueryable<TEntity> entitiesList = _entitiesSet.AsQueryable();

            if (includingTables != null)
                for (int i = 0; i < includingTables.Length; i++)
                    entitiesList = entitiesList.Include(includingTables[i]);

            return entitiesList.Any(predicate);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _entitiesSet.AnyAsync(predicate);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, params string[] includingTables)
        {
            IQueryable<TEntity> entitiesList = _entitiesSet.AsQueryable();

            if (includingTables != null)
                for (int i = 0; i < includingTables.Length; i++)
                    entitiesList = entitiesList.Include(includingTables[i]);

            return entitiesList.AnyAsync(predicate);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _entitiesSet.Where(predicate).AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params string[] includingTables)
        {
            IQueryable<TEntity> entitiesList = _entitiesSet.AsNoTracking().AsQueryable();

            if (includingTables != null)
                for (int i = 0; i < includingTables.Length; i++)
                    entitiesList = entitiesList.Include(includingTables[i]);

            return entitiesList
                .Where(predicate)
                .ToList();
        }

        public IEnumerable<TEntity> Find(BaseSearchModel searchModel, Expression<Func<TEntity, bool>> predicate)
        {
            int start = (searchModel.CurrentPage - 1) * searchModel.PageSize;

            var entitiesList = _entitiesSet
                .Where(predicate)
                .OrderBy(searchModel.SortBy)
                .Skip(start)
                .Take(searchModel.PageSize)
                .ToList();

            searchModel.TotalRowsCount = _entitiesSet.Count(predicate);
            searchModel.TotalPages = (int)Math.Ceiling((double)searchModel.TotalRowsCount / searchModel.PageSize);

            return entitiesList;
        }

        public IEnumerable<TEntity> Find(BaseSearchModel searchModel, Expression<Func<TEntity, bool>> predicate, params string[] includingTables)
        {
            int start = (searchModel.CurrentPage - 1) * searchModel.PageSize;

            IQueryable<TEntity> entitiesList = _entitiesSet.AsQueryable();

            if (includingTables != null)
                for (int i = 0; i < includingTables.Length; i++)
                    entitiesList = entitiesList.Include(includingTables[i]);

            entitiesList = entitiesList
                .Where(predicate)
                .OrderBy(searchModel.SortBy)
                .Skip(start)
                .Take(searchModel.PageSize);

            searchModel.TotalRowsCount = _entitiesSet.Count(predicate);
            searchModel.TotalPages = (int)Math.Ceiling((double)searchModel.TotalRowsCount / searchModel.PageSize);

            return entitiesList.ToList();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entitiesSet
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, params string[] includingTables)
        {
            IQueryable<TEntity> entitiesList = _entitiesSet.AsQueryable();

            if (includingTables != null)
                for (int i = 0; i < includingTables.Length; i++)
                    entitiesList = entitiesList.Include(includingTables[i]);

            return await entitiesList
                    .AsNoTracking()
                    .Where(predicate)
                    .ToListAsync();

        }

        public async Task<IEnumerable<TEntity>> FindAsync(BaseSearchModel searchModel, Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> entitiesList = _entitiesSet.AsQueryable();

            int start = (searchModel.CurrentPage - 1) * searchModel.PageSize;

            entitiesList = entitiesList
                .Where(predicate)
                .OrderBy(searchModel.SortBy)
                .Skip(start)
                .Take(searchModel.PageSize);

            searchModel.TotalRowsCount = _entitiesSet.Count(predicate);
            searchModel.TotalPages = (int)Math.Ceiling((double)searchModel.TotalRowsCount / searchModel.PageSize);

            return await entitiesList.ToListAsync();

        }

        public async Task<IEnumerable<TEntity>> FindAsync(BaseSearchModel searchModel, Expression<Func<TEntity, bool>> predicate, params string[] includingTables)
        {
            IQueryable<TEntity> entitiesList = _entitiesSet.AsQueryable();

            if (includingTables != null)
                for (int i = 0; i < includingTables.Length; i++)
                    entitiesList = entitiesList.Include(includingTables[i]);

            int start = (searchModel.CurrentPage - 1) * searchModel.PageSize;

            entitiesList = entitiesList
                .Where(predicate)
                .OrderBy(searchModel.SortBy)
                .Skip(start)
                .Take(searchModel.PageSize);

            searchModel.TotalRowsCount = _entitiesSet.Count(predicate);
            searchModel.TotalPages = (int)Math.Ceiling((double)searchModel.TotalRowsCount / searchModel.PageSize);

            return await entitiesList.ToListAsync();

        }

        public IEnumerable<TEntity> Get(BaseSearchModel searchModel)
        {
            int start = (searchModel.CurrentPage - 1) * searchModel.PageSize;

            var entitiesList = _entitiesSet
                .OrderBy(searchModel.SortBy)
                .Skip(start)
                .Take(searchModel.PageSize)
                .ToList();

            searchModel.TotalRowsCount = _entitiesSet.Count();
            searchModel.TotalPages = (int)Math.Ceiling((double)searchModel.TotalRowsCount / searchModel.PageSize);

            return entitiesList.ToList();
        }

        public IEnumerable<TEntity> Get(BaseSearchModel searchModel, params string[] includingTables)
        {
            int start = (searchModel.CurrentPage - 1) * searchModel.PageSize;

            IQueryable<TEntity> entitiesList = _entitiesSet.AsQueryable();

            if (includingTables != null)
                for (int i = 0; i < includingTables.Length; i++)
                    entitiesList = entitiesList.Include(includingTables[i]);

            entitiesList = entitiesList
                .OrderBy(searchModel.SortBy)
                .Skip(start)
                .Take(searchModel.PageSize);

            searchModel.TotalRowsCount = _entitiesSet.Count();
            searchModel.TotalPages = (int)Math.Ceiling((double)searchModel.TotalRowsCount / searchModel.PageSize);

            return entitiesList.ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entitiesSet.ToList();
        }

        public IEnumerable<TEntity> GetAll(params string[] includingTables)
        {
            IQueryable<TEntity> entitiesList = _entitiesSet.AsQueryable();

            if (includingTables != null)
                for (int i = 0; i < includingTables.Length; i++)
                    entitiesList = entitiesList.Include(includingTables[i]);

            return entitiesList.ToList();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entitiesSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(params string[] includingTables)
        {
            IQueryable<TEntity> entitiesList = _entitiesSet.AsQueryable();

            if (includingTables != null)
                for (int i = 0; i < includingTables.Length; i++)
                    entitiesList = entitiesList.Include(includingTables[i]);

            return await entitiesList.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAsync(BaseSearchModel searchModel)
        {
            int start = (searchModel.CurrentPage - 1) * searchModel.PageSize;

            var entitiesList = await _entitiesSet
                .OrderBy(searchModel.SortBy)
                .Skip(start)
                .Take(searchModel.PageSize)
                .ToListAsync();

            searchModel.TotalRowsCount = _entitiesSet.Count();
            searchModel.TotalPages = (int)Math.Ceiling((double)searchModel.TotalRowsCount / searchModel.PageSize);

            return entitiesList;
        }

        public async Task<IEnumerable<TEntity>> GetAsync(BaseSearchModel searchModel, params string[] includingTables)
        {

            int start = (searchModel.CurrentPage - 1) * searchModel.PageSize;
            IQueryable<TEntity> entitiesList = _entitiesSet.AsQueryable();

            if (includingTables != null)
                for (int i = 0; i < includingTables.Length; i++)
                    entitiesList = entitiesList.Include(includingTables[i]);

            entitiesList = entitiesList
                .OrderBy(searchModel.SortBy)
                .Skip(start)
                .Take(searchModel.PageSize);

            searchModel.TotalRowsCount = _entitiesSet.Count();
            searchModel.TotalPages = (int)Math.Ceiling((double)searchModel.TotalRowsCount / searchModel.PageSize);

            return await entitiesList.ToListAsync();
        }

        public TEntity GetById(object id)
        {
            return _entitiesSet.Find(id);
        }

        public async Task<TEntity> GetByIdAsync(object id)
        {
            return await _entitiesSet.FindAsync(id);
        }

        public int Count()
        {
            return _entitiesSet.Count();
        }

        public async Task<int> CountAsync()
        {
            return await _entitiesSet.CountAsync();
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _entitiesSet.Count(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entitiesSet.CountAsync(predicate);
        }

        public T Max<T>(Expression<Func<TEntity, T>> predicate)
        {
            if (!_entitiesSet.Any())
                return default;

            return _entitiesSet.Max(predicate);
        }

        public T Max<T>(Expression<Func<TEntity, T>> predicate, Expression<Func<TEntity, bool>> predicateCondition)
        {
            if (!_entitiesSet.Any(predicateCondition))
                return default;

            return _entitiesSet.Where(predicateCondition).Max(predicate);
        }

        public async Task<T> MaxAsync<T>(Expression<Func<TEntity, T>> predicate, Expression<Func<TEntity, bool>> predicateCondition)
        {
            if (!await _entitiesSet.AnyAsync(predicateCondition))
                return default;

            return await _entitiesSet.Where(predicateCondition).MaxAsync(predicate);
        }

        public async Task<T> MaxAsync<T>(Expression<Func<TEntity, T>> predicate)
        {
            if (!await _entitiesSet.AnyAsync())
                return default;

            return await _entitiesSet.MaxAsync(predicate);
        }

        #endregion select
    }
}
