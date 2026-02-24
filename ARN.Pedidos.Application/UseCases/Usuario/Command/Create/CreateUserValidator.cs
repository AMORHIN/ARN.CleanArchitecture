using FluentValidation;

namespace ARN.Pedidos.Application.UseCases.Usuario.Command.Create
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.RolId).GreaterThan(0).WithMessage("Rol Id debe ser mayor a 0.");
            RuleFor(x => x.Usuario)
                .NotEmpty().WithMessage("Usuario no puede ser vacio")
                .NotNull().WithMessage("Usuario no puede ser nulo")
                .MinimumLength(3).WithMessage("Usuario minimo de caracteres debe ser 3")
                .MaximumLength(15).WithMessage("Usuario maximo de caracteres debe ser 15")
                ;
        }
    }
}