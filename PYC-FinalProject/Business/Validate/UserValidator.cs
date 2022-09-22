using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProductCatalogue.DataAccess.Entites.Concrete;

namespace ProductCatalogue.Business.Validate
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Ad boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().NotNull().WithMessage("Ad boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail boş geçilemez."); ;
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez.");
            RuleFor(x => x.Password).MinimumLength(8).WithMessage("Şifre 8 karakterden büyük olmalı.");
            RuleFor(x => x.Password).MaximumLength(20).WithMessage("Şifre 20 karakterden küçük olmalı.");

        }
    }
}

