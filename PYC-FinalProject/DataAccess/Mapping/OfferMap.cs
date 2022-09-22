using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using ProductCatalogue.DataAccess.Entites.Concrete;

namespace ProductCatalogue.DataAccess.Mapping
{
    public class OfferMap : ClassMapping<Offer>
    {
        public OfferMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.ProductId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            Property(b => b.UserId, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });

            
            Property(b => b.Proffer, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.Double);
                x.NotNullable(true);
            });

            Property(b => b.Status, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.NotNullable(true);
            });


            Table("offer");
        }
    }
}
