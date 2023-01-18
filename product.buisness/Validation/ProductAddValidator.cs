using FluentValidation;
using production.Database.Dtos.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace production.buisness.Validation
{
    public class ProductAddValidator : AbstractValidator<AddProductRequestDto>
    {
        public ProductAddValidator()
        {
            RuleFor(x => x.ProductName).MaximumLength(100).WithMessage("maximum length 100");
            RuleFor(x => x.Price).Must(ValidatePrice).WithMessage("Invalid price");
            RuleFor(x => x.Tax).Must(ValidateTax).WithMessage("Invalid Tax");

        }

        private bool ValidatePrice(double Price)
        {
            if (Price > 0)
                return true;
            else
                return false;
        }

        private bool ValidateTax(double tax)
        {
            if (tax >= 0 && tax <= 100)
                return true;
            else
                return false;
        }

    }

}

