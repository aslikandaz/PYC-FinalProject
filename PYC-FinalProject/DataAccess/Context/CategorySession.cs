using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FluentValidation.Results;
using NHibernate;
using ProductCatalogue.DataAccess.Entites.Concrete;

namespace ProductCatalogue.DataAccess.Context
{
    public class CategorySession : IMapperSession<Category>
    {
        private readonly ISession session;
        private ITransaction transaction;
        
        public CategorySession(ISession session)
        {
            this.session = session;
            
        }

        public IQueryable<Category> Entites => session.Query<Category>();

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

        public void Delete(Category entity)
        {
            session.Delete(entity);
        }


        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Save(Category entity)
        {
            session.Save(entity);
        }

        public void Update(Category entity)
        {
            session.Update(entity);
        }

        public List<Category> GetAll()
        {
            return session.Query<Category>().ToList();
        }

        public Category GetById(int id)
        {
            var entity = session.Get<Category>(id);
            return entity;
        }

        public IEnumerable<Category> Where(Expression<Func<Category, bool>> where)
        {
            return session.Query<Category>().Where(where).AsQueryable();
        }

        public IEnumerable<Category> Find(Expression<Func<Category, bool>> expression)
        {
            return session.Query<Category>().Where(expression).ToList();
        }
    }
}
