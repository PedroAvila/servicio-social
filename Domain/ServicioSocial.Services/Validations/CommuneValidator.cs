using FluentValidation;
using ServicioSocial.Entities;

namespace ServicioSocial.Services.Validations
{
    public class CommuneValidator : AbstractValidator<Commune>
    {
        public CommuneValidator()
        {
            RuleFor(x => x.RegionId)
            .NotNull().WithMessage("RegionId cannot be null");

            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The name field cannot be empty")
            .MaximumLength(150).WithMessage("The name must have a maximum of 150 characters");
        }
    }
}