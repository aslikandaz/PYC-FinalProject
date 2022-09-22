using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCatalogue.DataAccess.Entites.Abstract;


namespace ProductCatalogue.DataAccess.Entites.Concrete
{
    public class User : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual byte[] PasswordSalt { get; set; }
        public virtual  byte[] PasswordHash { get; set; }
        public virtual bool Status { get; set; }

    }
}
