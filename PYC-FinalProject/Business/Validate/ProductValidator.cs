using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProductCatalogue.DataAccess.Entites.Concrete;

namespace ProductCatalogue.Business.Validate
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Ürün adı boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Ürünün adı en fazla 100 karakter olabilir.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Açıklama 500 karakterden fazla olamaz.");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Ürün fiyatı boş geçilemez");
            RuleFor(x => x.Brand).NotEmpty().NotNull().WithMessage("Marka boş geçilemez");
            RuleFor(x => x.Color).NotEmpty().NotNull().WithMessage("Renk boşş geçilemez");
            RuleFor(x => x.CategoryId).NotEmpty().NotNull().WithMessage("CategoryId boş geçilemez");
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage("UserId boş geçilemez");
        }
    }
}
