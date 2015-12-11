using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public interface IGenericRepository<T> where T : class, new()
    {

        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        List<T> GetList(Expression<Func<T, bool>> filter,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int? page = null,
            int? pageSize = null);

        int GetCount(Expression<Func<T, bool>> filter);
    }
}
