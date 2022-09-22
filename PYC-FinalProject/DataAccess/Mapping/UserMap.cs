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
    public class UserMap : ClassMapping<User>
    {
        public UserMap()
        {
            Id(x => x.Id, x =>
            {
                x.Type(NHibernateUtil.Int32);
                x.Column("id");
                x.UnsavedValue(0);
                x.Generator(Generators.Increment);
            });

            Property(b => b.Name, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Surname, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.Email, x =>
            {
                x.Length(50);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.PasswordHash, x =>
            {
                x.Length(500);
                x.Type(NHibernateUtil.Binary);
                x.NotNullable(true);
            });

            Property(b => b.Password, x =>
            {
                x.Length(20);
                x.Type(NHibernateUtil.String);
                x.NotNullable(true);
            });

            Property(b => b.PasswordSalt, x =>
            {
                x.Length(500);
                x.Type(NHibernateUtil.Binary);
                x.NotNullable(true);
            });

            Property(b => b.Status, x =>
            {
                x.Type(NHibernateUtil.Boolean);
                x.NotNullable(true);
            });

            Table("user");
        }
    }
}
