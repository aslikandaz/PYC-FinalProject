using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProductCatalogue.DataAccess.Entites.Concrete;

namespace ProductCatalogue.Business.Validate
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Kategori boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(20).NotNull().WithMessage(" Bir kategori seçiniz");
        }
    }
}
