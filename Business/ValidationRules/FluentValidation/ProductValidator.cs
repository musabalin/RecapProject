using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ProductName).NotEmpty().WithMessage("Boş Geçilemez..");
            RuleFor(p => p.ProductId).NotEmpty().WithMessage("Boş Geçilemez..");
            RuleFor(p => p.ProductName).MinimumLength(3);

        }
    }
}
