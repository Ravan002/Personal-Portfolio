using Entities.Dtos.AboutMeDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.FluentValidation
{
    public class AboutMeDtoValidator : AbstractValidator<AboutMeDto>
    {
        public AboutMeDtoValidator()
        {
            RuleFor(x=>x.FirstName).NotEmpty().WithMessage("Can not be empty").NotNull().MinimumLength(3).WithMessage("Name must at least 3 charachter");
            RuleFor(x=>x.LastName).NotEmpty().WithMessage("Can not be empty").NotNull().MinimumLength(5).WithMessage("Surname must at least 3 charachter");
        }
    }
}
