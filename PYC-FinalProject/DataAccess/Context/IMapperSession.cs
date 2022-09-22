using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ProductCatalogue.DataAccess.Context
{
    public interface IMapperSession<T>
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
        void Save(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
        T GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        IEnumerable<T> Where(Expression<Func<T, bool>> where);
        IQueryable<T> Entites { get; }
    }
}
