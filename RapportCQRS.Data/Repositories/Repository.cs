using AutoMapper;
using AutoMapper.QueryableExtensions;
using RapportCQRS.Data.IRepositories;
using RapportCQRS.Model.Dtos;
using RapportCQRS.Domain.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RapportCQRS.Model.Models;
using RapportCQRS.Domain.Dxos.Common;

namespace RapportCQRS.Data.Repositories
{

    /// <summary>
    /// Generic Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class Repository<TEntity, TReturn, TDxos> : IRepository<TEntity, TReturn>
        where TEntity : class where TReturn : class where TDxos : IBaseDxos
    {

        #region Fields
        protected readonly ILogger _logger;


        protected IMapper _mapper;

        protected RapportCQRSDbContext _dbContext;

        protected readonly DbSet<TEntity> ModelDbSets;

        #endregion

        public Repository(RapportCQRSDbContext dbContext,
            ILogger logger,
            TDxos dxos)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException();
            _logger = logger ?? throw new ArgumentNullException();
            ModelDbSets = _dbContext.Set<TEntity>();
            _mapper = dxos.GetMapper();
        }

        #region Methods

        public async Task<PagedResults<TReturn>> GetListPageAsync
        (
          QueryListBase<PagedResults<TReturn>> query
        , Expression<Func<TEntity, bool>> predicate
        )
        {
            return await CreatePagedResults<TEntity>
                (
                    (predicate == null) ? ModelDbSets : ModelDbSets.Where(predicate)
                    , query.PageIndex
                    , query.PageSize
                    , query.Sort
                    , query.Direction
                );
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await ModelDbSets.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await ModelDbSets.Where(predicate).ToListAsync();
        }

        public IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate)
        {
            return ModelDbSets.Where(predicate).AsQueryable();
        }

        public void Add(TEntity entity)
        {
            //TODO: To be changed
            ModelDbSets.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            ModelDbSets.AddRange(entities);
        }

        public void Remove(TEntity entity)
        {
            if (entity != null)
            {
                if (_dbContext.Entry(entity).State == EntityState.Detached) ModelDbSets.Attach(entity);

                ModelDbSets.Remove(entity);
            }

        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (_dbContext.Entry(entity).State == EntityState.Detached) ModelDbSets.Attach(entity);

                ModelDbSets.Remove(entity);
            }
        }

        public void Update(TEntity entity)
        {
            ModelDbSets.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;

            if (_dbContext.Entry(entity).Property("CreatedBy") != null)
            {
                _dbContext.Entry(entity).Property("CreatedBy").IsModified = false;
            }

            if (_dbContext.Entry(entity).Property("CreatedAt") != null)
            {
                _dbContext.Entry(entity).Property("CreatedAt").IsModified = false;

            }

        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Creates a paged set of results.
        /// </summary>
        /// <typeparam name="T">The type of the source IQueryable.</typeparam>
        /// <typeparam name="TReturn">The type of the returned paged results.</typeparam>
        /// <param name="queryable">The source IQueryable.</param>
        /// <param name="page">The page number you want to retrieve.</param>
        /// <param name="pageSize">The size of the page.</param>
        /// <param name="orderBy">The field or property to order by.</param>
        /// <param name="ascending">Indicates whether or not the order should be ascending (true) or descending (false.)</param>
        /// <returns>Returns a paged set of results.</returns>
        public async Task<PagedResults<TReturn>> CreatePagedResults<T>(
            IQueryable<T> queryable,
            int page,
            int pageSize,
            string orderBy,
            string orderDirection)
        {
            var skipAmount = pageSize * (page - 1);

            bool ascending = orderDirection.ToLower().Equals("asc");

            var projection = queryable
                .OrderByPropertyOrField(orderBy, ascending)
                .Skip(skipAmount)
                .Take(pageSize).ProjectTo<TReturn>(_mapper.ConfigurationProvider);

            var totalNumberOfRecords = await queryable.CountAsync();

            var results = await projection.ToListAsync();

            var mod = totalNumberOfRecords % pageSize;
            var totalPageCount = (totalNumberOfRecords / pageSize) + (mod == 0 ? 0 : 1);

            return new PagedResults<TReturn>
            {
                Results = results,
                PageNumber = page,
                PageSize = pageSize,
                TotalNumberOfPages = totalPageCount,
                TotalNumberOfRecords = totalNumberOfRecords,
            };
        }

        #endregion


        #region IDisposable


        /// <summary>
        /// Dispose of all assets
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // free managed resources
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }

        ~Repository()
        {
            Dispose(false);
        }

        #endregion

    }
}