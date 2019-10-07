using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonDetails.Repositories.Interface
{
    interface IRepository
    {
        #region LINQ
        IQueryable<TEntity> All();
        bool Any(Expression<Func<TEntity, bool>> predicate);
        IQueryable<string> Select(Expression<Func<TEntity, string>> predicate);
        TEntity Find(params object[] keys);
        IQueryable<TEntity> FindAllInclude
        (Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        IQueryable<TEntity> GetAllInclude
            (params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity FindInclude
        (Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);
        TEntity First(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        bool IsExist(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> predicate);
        int Count { get; }
        int CountFunc(Expression<Func<TEntity, bool>> predicate);
        string MaxFunc(Expression<Func<TEntity, string>> predicate, Expression<Func<TEntity, bool>> where);
        string Max(Expression<Func<TEntity, string>> predicate);
        string Min(Expression<Func<TEntity, string>> predicate);
        string MinFunc(Expression<Func<TEntity, string>> predicate, Expression<Func<TEntity, bool>> where);

        /// <summary>
        /// add a item in a table. item never be added untill call savechanges method.
        /// </summary>
        /// <param name="item">object of a class which will be added into corresponding DB table.</param>
        void Add(TEntity item);

        /// <summary>
        /// Modify a item in a table. item never be Modified untill call savechanges method.
        /// </summary>
        /// <param name="item">object of a class which will be Modified into corresponding DB table.</param>
        void Modify(TEntity item);
        TEntity Create(TEntity item);
        int Update(TEntity item);
        int Delete(TEntity item);
        TEntity CreateOrUpdate(Expression<Func<TEntity, bool>> predicate, TEntity newItem);
        TEntity CreateOrUpdate(TEntity item);

        int Delete(Expression<Func<TEntity, bool>> predicate);

        string ToId(Expression<Func<TEntity, string>> predicate, string prefix, int returnLength = 9, char fillValue = '0');

        string CreateId(Expression<Func<TEntity, string>> predicate, Expression<Func<TEntity, bool>> where, string prefix,
            int returnLength = 9, char fillValue = '0');
        #endregion
    }
}
