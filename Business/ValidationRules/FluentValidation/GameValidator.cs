using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class GameValidator : AbstractValidator<Game>
    {
        public GameValidator()
        {
            RuleFor(p => p.GameName).NotEmpty();
            RuleFor(p => p.GameName).MinimumLength(2);
            RuleFor(p => p.Descriptions).NotEmpty();
            RuleFor(p => p.Descriptions).MinimumLength(2);
            RuleFor(p => p.ReleaseDate).NotEmpty();
        }
    }
}
