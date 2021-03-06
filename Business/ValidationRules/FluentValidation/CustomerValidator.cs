using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.CustomerName).NotEmpty();
            RuleFor(p => p.CustomerName).MinimumLength(2);
            RuleFor(p => p.CompanyName).NotEmpty();
            RuleFor(p => p.CompanyName).MinimumLength(2);
        }
    }
}
