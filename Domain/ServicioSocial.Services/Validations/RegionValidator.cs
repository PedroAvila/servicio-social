using FluentValidation;
using ServicioSocial.Entities;

namespace ServicioSocial.Services.Validations
{
    public class RegionValidator : AbstractValidator<Region>
    {
        public RegionValidator()
        {
            RuleFor(x => x.CountryId)
            .Must(x => x > 0).WithMessage("The value of CountryId must be greater than zero");

            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The name field cannot be empty")
            .MaximumLength(80).WithMessage("The name must have a maximum of 80 characters");
        }
    }
}