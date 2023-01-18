using FluentValidation;
using production.Database.Dtos.Companies;
using Production.Database.Dtos.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace production.buisness.Validation
{
    public class CompanyAddValidator : AbstractValidator<AddCompanyRequestDto>
    {
        public CompanyAddValidator()
        {
            RuleFor(x => x.CompanyName).MaximumLength(100).WithMessage("maximum length 100");
            RuleFor(x => x.StartDate).Must(ValidateDate).WithMessage("Invalid date");
        }
        public bool ValidateDate(DateTime startdate)
        {
            DateTime a = new DateTime(2020, 1, 1);
            DateTime b = DateTime.Now;
            if (startdate < a || startdate > b)
                return true;
            else
                return false;
        }
    }
}
