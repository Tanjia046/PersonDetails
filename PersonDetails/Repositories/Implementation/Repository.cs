using PersonDetails.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace PersonDetails.Repositories.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region CONFIG
        private DbContext _context;//IAppDbContext
        private bool _shareContext;
        private bool _disposed;

        public bool ShareContext
        {
            get { return _shareContext; }
            set { _shareContext = value; }
        }

        public DbContext Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;

            }
        }

        public Repository(DbContext context)
        {
            Context = context;
            _context.Database.CommandTimeout = 100000;
        }

        protected DbSet<TEntity> DbSet
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }


        #endregion

        #region Disposed

        ~Repository()
        {
            Dispose(false);
        }

        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (ShareContext || _context == null) return;
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                        _context = null;
                    }
                }
            }
            _disposed = true;
        }

        #endregion

        #region LINQ

        public IQueryable<TEntity> All()
        {
            return DbSet.AsNoTracking().AsQueryable();
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }
    
        public TEntity Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.AsNoTracking().FirstOrDefault(predicate);
        }

        #endregion
    }
}
