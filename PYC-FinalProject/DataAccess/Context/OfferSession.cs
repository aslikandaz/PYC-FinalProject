using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NHibernate;
using ProductCatalogue.DataAccess.Entites.Concrete;

namespace ProductCatalogue.DataAccess.Context
{
    public class OfferSession : IMapperSession<Offer>
    {
        private readonly ISession session;
        private ITransaction transaction;
        public OfferSession(ISession session)
        {
            this.session = session;
        }

        public IQueryable<Offer> Entites => session.Query<Offer>();

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

        public void Delete(Offer entity)
        {
            session.Delete(entity);
        }


        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Save(Offer entity)
        {
            session.Save(entity);
        }

        public void Update(Offer entity)
        {
            session.Update(entity);
        }

        public List<Offer> GetAll()
        {
            return session.Query<Offer>().ToList();
        }

        public Offer GetById(int id)
        {
            var entity = session.Get<Offer>(id);
            return entity;
        }

        public IEnumerable<Offer> Where(Expression<Func<Offer, bool>> where)
        {
            return session.Query<Offer>().Where(where).AsQueryable();
        }

        public IEnumerable<Offer> Find(Expression<Func<Offer, bool>> expression)
        {
            return session.Query<Offer>().Where(expression).ToList();
        }
    }
}

