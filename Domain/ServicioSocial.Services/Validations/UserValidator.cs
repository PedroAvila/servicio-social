using FluentValidation;
using ServicioSocial.Entities;

namespace ServicioSocial.Services.Validations
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.CommuneId)
            .Must(x => x > 0).WithMessage("The value of CommuneId must be greater than zero");

            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("The name field cannot be empty")
            .MaximumLength(100).WithMessage("The name must have a maximum of 100 characters");

            RuleFor(x => x.Address)
            .NotEmpty().WithMessage("The Address field cannot be empty")
            .MaximumLength(200).WithMessage("The Address must have a maximum of 200 characters");

            RuleFor(x => x.RoleId)
            .IsInEnum()
            .WithMessage("The value of ProfileId must be within the allowed range of 1 to 2");

            RuleFor(x => x.Password)
            .NotEmpty().WithMessage("The Password field cannot be empty")
            .MaximumLength(8).WithMessage("The Password must have a maximum of 8 characters");

            RuleFor(x => x.Phone)
            .NotEmpty().WithMessage("The Phone field cannot be empty")
            .MaximumLength(10).WithMessage("The Phone must have a maximum of 8 characters");

            RuleFor(x => x.Email)
            .NotEmpty().WithMessage("The Email field cannot be empty")
            .EmailAddress().WithMessage("The e-mail address is invalid");
        }
    }
}