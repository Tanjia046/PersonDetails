using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PersonDetails.Repositories.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        #region LINQ
        IQueryable<TEntity> All();
        bool Any(Expression<Func<TEntity, bool>> predicate);
        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        #endregion
    }
}
