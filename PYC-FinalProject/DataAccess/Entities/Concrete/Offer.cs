using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCatalogue.DataAccess.Entites.Abstract;


namespace ProductCatalogue.DataAccess.Entites.Concrete
{
    public class Offer : IEntity
    {
        public virtual int Id { get; set; }
        public virtual int ProductId { get; set; }
        public virtual int UserId { get; set; }
        public virtual double Proffer { get; set; }
        public virtual int Status { get; set; } = 1;

    }
}
