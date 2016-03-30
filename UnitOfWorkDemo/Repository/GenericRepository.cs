using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Linq.Expressions;
using UnitOfWorkDemo.Models;

namespace UnitOfWorkDemo.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        #region Private Methods

        internal UnitOfWorkContext context;

        internal DbSet<T> dbSet;

        #endregion

        #region Contructor

        public GenericRepository(UnitOfWorkContext _context)
        {
            context = _context;
            dbSet = context.Set<T>();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Delete Method
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        /// <summary>
        /// Get Method
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
            string test = string.Empty;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        /// <summary>
        /// Method to get Entity By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual T GetById(object Id)
        {
            return dbSet.Find(Id);
        }

        /// <summary>
        /// Method to Delete Entity by Id
        /// </summary>
        /// <param name="Id"></param>
        public virtual void Delete(object Id)
        {
            T entity = dbSet.Find(Id);
            Delete(entity);
        }
        
        /// <summary>
        /// Method to add entity
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// Method to update entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        #endregion
    }
}