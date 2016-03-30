using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace UnitOfWorkDemo.Repository
{
    interface IRepository<T> where T : class
    {
        #region Interface methods

        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        T GetById(object Id);
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Delete(object Id);

        #endregion
    }
}
