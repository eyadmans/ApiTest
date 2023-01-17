using FluentValidation;
using Production.Database.Dtos.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace production.buisness.Validation
{
    public class Validator:AbstractValidator<EditRequestDto>
    {
        public Validator()
        {
            RuleFor(x => x.CompanyName).MaximumLength(100).WithMessage("maximum length 100");
            RuleFor(x => x.StartDate).Must(Date).WithMessage("Invalid date");
        }
        public bool Date(DateTime startdate)
        {
            DateTime a = new DateTime(2020, 1, 1);
            DateTime b = DateTime.Now;
            if (companyDto.StartDate >= a & companyDto.StartDate <= b)
                return true;
        }
    }
}
