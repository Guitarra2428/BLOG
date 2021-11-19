using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebAPP.AccesoDatos.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetT(int id);

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> Filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null

            );

        T GetTFirstDefault(
            Expression<Func<T, bool>> Filter = null,
            string includeProperties = null

            );

        void Add(T entity);

        void Remove(int id);

        void Remove(T entity);
    }
}
