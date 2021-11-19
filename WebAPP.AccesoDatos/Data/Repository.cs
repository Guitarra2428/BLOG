using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebAPP.AccesoDatos.Data.Repository;

namespace WebAPP.AccesoDatos.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Db;
        internal DbSet<T> dbSet;

        public Repository(DbContext context)
        {
            Db = context;
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }
        public T GetT(int id)
        {
            return dbSet.Find(id);
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> Filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (Filter != null)
            {
                query = query.Where(Filter);
            }
            //includ Properties separado por coma

            if (includeProperties != null)
            {
                foreach (var includproperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includproperty);
                }

            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }

            return query.ToList();

        }



        public T GetTFirstDefault(Expression<Func<T, bool>> Filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (Filter != null)
            {
                query = query.Where(Filter);
            }

            //includ Properties separado por coma

            if (includeProperties != null)
            {
                foreach (var includproperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includproperty);
                }

            }
            return query.FirstOrDefault();
        }

        public void Remove(int id)
        {
            T entityRemove = dbSet.Find(id);

            Remove(entityRemove);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }
    }
}
