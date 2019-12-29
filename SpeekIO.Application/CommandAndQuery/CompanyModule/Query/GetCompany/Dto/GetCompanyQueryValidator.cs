using FluentValidation;
using SpeekIO.Application.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyBooking.Application.CommandAndQuery.CompanyModule.Query.GetCompany.Dto
{
    public class GetCompanyQueryValidator : BaseValidator<GetCompanyQuery>
    {
        public GetCompanyQueryValidator()
        {
            RuleFor(t => t.Id).NotEmpty().WithMessage("Company id is missing.");
        }
    }
}
