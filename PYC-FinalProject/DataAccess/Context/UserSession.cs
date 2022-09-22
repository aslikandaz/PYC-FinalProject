using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NHibernate;
using ProductCatalogue.DataAccess.Entites.Concrete;

namespace ProductCatalogue.DataAccess.Context
{
    public class UserSession : IMapperSession<User>
    {
        private readonly ISession session;
        private ITransaction transaction;
        public UserSession(ISession session)
        {
            this.session = session;
        }

        public IQueryable<User> Entites => session.Query<User>();

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

        public void Delete(User entity)
        {
            session.Delete(entity);
        }


        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Save(User entity)
        {
            session.Save(entity);
        }

        public void Update(User entity)
        {
            session.Update(entity);
        }

        public List<User> GetAll()
        {
            return session.Query<User>().ToList();
        }

        public User GetById(int id)
        {
            var entity = session.Get<User>(id);
            return entity;
        }

        public IEnumerable<User> Where(Expression<Func<User, bool>> where)
        {
            return session.Query<User>().Where(where).AsQueryable();
        }

        public IEnumerable<User> Find(Expression<Func<User, bool>> expression)
        {
            return session.Query<User>().Where(expression).ToList();
        }
    }
}
