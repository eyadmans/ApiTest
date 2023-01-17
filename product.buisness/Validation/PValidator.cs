using FluentValidation;
using Production.Database.Dtos.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace production.buisness.Validation
{
    public class PValidator : AbstractValidator<PEditRequest>
    {
        public PValidator()
        {
            RuleFor(x => x.ProductName).MaximumLength(100).WithMessage("maximum length 100");
            RuleFor(x => x.Price).Must(ValidatePrice).WithMessage("Invalid price");

        }

        private bool ValidatePrice(double Price, Double tax)
        {
            if (Price > 0 && tax >= 0 && tax <= 100)
                return true;
            else
                return false;
        }
    }

}
