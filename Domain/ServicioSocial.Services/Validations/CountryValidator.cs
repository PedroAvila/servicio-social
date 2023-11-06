using FluentValidation;
using ServicioSocial.Entities;

namespace ServicioSocial.Services.Validations
{
    public class CountryValidator : AbstractValidator<Country>
    {
        public CountryValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The name field cannot be empty")
            .MaximumLength(50).WithMessage("The name must have a maximum of 50 characters");
        }
    }
}