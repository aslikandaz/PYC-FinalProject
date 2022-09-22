using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NHibernate;
using ProductCatalogue.DataAccess.Entites.Concrete;

namespace ProductCatalogue.DataAccess.Context
{
    public class ProductSession : IMapperSession<Product>
    {
        private readonly ISession session;
        private ITransaction transaction;
        public ProductSession(ISession session)
        {
            this.session = session;
        }

        public IQueryable<Product> Entites => session.Query<Product>();

        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Delete(Product entity)
        {
            session.Delete(entity);
        }


        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Save(Product entity)
        {
            session.Save(entity);
        }

        public void Update(Product entity)
        {
            session.Update(entity);
        }

        public List<Product> GetAll()
        {
            return session.Query<Product>().ToList();
        }

        public Product GetById(int id)
        {
            var entity = session.Get<Product>(id);
            return entity;
        }

        public IEnumerable<Product> Where(Expression<Func<Product, bool>> where)
        {
            return session.Query<Product>().Where(where).AsQueryable();
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> expression)
        {
            return session.Query<Product>().Where(expression).ToList();
        }
    }
}
