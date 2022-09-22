using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCatalogue.DataAccess.Entites.Abstract;


namespace ProductCatalogue.DataAccess.Entites.Concrete
{
    public class Product : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string Color { get; set; }
        public virtual string Brand { get; set; }
        public virtual double Price { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual int UserId { get; set; }
        public virtual bool IsOfferable { get; set; }
        public virtual bool IsSold { get; set; }
    }
}
