
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public abstract class GenericRepository<TContext, TEntity> : IGenericRepository<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {

        private TContext _entities = new TContext();
        public TContext Context
        {

            get { return _entities; }
            set { _entities = value; }
        }

        public virtual IQueryable<TEntity> GetAll()
        {

            IQueryable<TEntity> query = _entities.Set<TEntity>();
            return query;
        }

        public IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {

            IQueryable<TEntity> query = _entities.Set<TEntity>().Where(predicate);
            return query;
        }

        public List<TEntity> GetList(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null,
                    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                    int? page = null, int? pageSize = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> query = context.Set<TEntity>().AsNoTracking();
                if (filter != null)
                    query = query.Where(filter);

                if (orderBy != null)
                    query = orderBy(query);

                if (page != null && pageSize != null && page > 0 && pageSize > 0)
                    query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);

                return query.ToList();
            }
        }

        public int GetCount(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where(filter).Count();
            }
        }

    }
}
