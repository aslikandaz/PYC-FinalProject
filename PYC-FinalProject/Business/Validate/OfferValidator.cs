using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProductCatalogue.DataAccess.Entites.Concrete;

namespace ProductCatalogue.Business.Validate
{
    public class OfferValidator : AbstractValidator<Offer>
    {
        public OfferValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().NotNull().WithMessage("ürünid boş geçilemez");
            RuleFor(x => x.UserId).NotEmpty().NotNull().WithMessage("UserId boş geçilemez");
            RuleFor(x => x.Proffer).NotEmpty().GreaterThan(0).NotNull().WithMessage("teklif boş geçilemez");
            RuleFor(x => x.Status).NotEmpty().NotNull().WithMessage("status boş geçilemez");
            RuleFor(x => x.Status).GreaterThanOrEqualTo(1).LessThanOrEqualTo(3).WithMessage("Status için geçerli değer giriniz");
        }
    }
}
