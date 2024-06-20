using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Paging;

namespace Core.Persistence.Repositories
{
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>, IAsyncRepository<TEntity>

        where TContext : DbContext
        where TEntity : Entity
    {
        private readonly TContext Context;

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }
        public IQueryable<TEntity> Query() => Context.Set<TEntity>();

        public void Add(TEntity entity)
        {
            Context.Add(entity);
            Context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            Context.Remove(entity);
            Context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            Context.Update(entity);
            Context.SaveChanges();
        }

        // Filter ✅
        // OrderBy ?
        public List<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null,
                                     Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();

            if (predicate != null)
                data = data.Where(predicate);
            if (include != null)
                data = include(data);

            return data.ToList();
        }

        // Filter ✅
        // OrderBy ?
        public TEntity? Get(Expression<Func<TEntity, bool>> predicate,
                           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();

            if (include != null)
                data = include(data);

            return data.FirstOrDefault(predicate);
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate,
                                     Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            IQueryable<TEntity> data = Context.Set<TEntity>();

            if (include != null)
                data = include(data);

            return await data.FirstOrDefaultAsync(predicate);
        }

        public async Task<IPaginate<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>>? predicate = null, 
            Func<IQueryable<TEntity>, 
            IIncludableQueryable<TEntity, object>>? include = null,
            int index =0,
            int size=10,
            CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query();

            if (predicate != null)
                queryable = queryable.Where(predicate);
            if (include != null)
                queryable = include(queryable);

            return await queryable.ToPaginateAsync(index, size,from:0, cancellationToken);
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity entity)
        {
            Context.Remove(entity);
            await Context.SaveChangesAsync();
        }
    }

}
