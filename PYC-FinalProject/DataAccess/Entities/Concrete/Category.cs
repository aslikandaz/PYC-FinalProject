using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductCatalogue.DataAccess.Entites.Abstract;


namespace ProductCatalogue.DataAccess.Entites.Concrete
{
    public class Category : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
    }
}
