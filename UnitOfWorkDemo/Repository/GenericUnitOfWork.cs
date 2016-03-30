using System;
using System.Collections.Generic;
using System.Linq;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Repository
{
    public class GenericUnitOfWork : IDisposable
    {
        #region Private Members

        private UnitOfWorkContext context = null;

        private bool disposed = false;

        #endregion

        #region Constructors

        public GenericUnitOfWork()
        {
            context = new UnitOfWorkContext();
            repositories = new Dictionary<Type, object>();
        }

        #endregion

        #region Public Properties

        public Dictionary<Type, object> repositories = null;

        #endregion

        #region Public Methods

        /// <summary>
        /// Gettting the repository for database operations
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as IRepository<T>;
            }
            IRepository<T> repo = new GenericRepository<T>(context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        /// <summary>
        /// SaveChanges method of context
        /// </summary>
        public void SaveChanges()
        {
            context.SaveChanges();
        }

        #endregion

        #region Dispose Methods

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}