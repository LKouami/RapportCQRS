using RapportCQRS.Model.Dtos;
using RapportCQRS.Model;
using RapportCQRS.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RapportCQRS.Data.IRepositories
{
    public interface IRepository<TEntity, TReturn> : IDisposable where TEntity : class
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Queryable(Expression<Func<TEntity, bool>> predicate);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        Task<int> SaveChangesAsync();

        Task<PagedResults<TReturn>> GetListPageAsync(QueryListBase<PagedResults<TReturn>> query
                                                        , Expression<Func<TEntity, bool>> predicate);
    }
}