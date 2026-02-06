using FluentValidation;

namespace ARN.Pedidos.Application.UseCases.Pedidos.Commands.CreatePedido
{
    public class CreatePedidoValidator : AbstractValidator<CreatePedidoCommand>
    {
        public CreatePedidoValidator()
        {
            RuleFor(cp => cp.Nombre)
                .NotNull().WithMessage("No puede ser campo nulo")
                .NotEmpty().WithMessage("No puede ser campo vacio")
                .MinimumLength(5).WithMessage("El campo {PropertyName}, minimo 5 caracteres.")
                .MaximumLength(50).WithMessage("El campo {PropertyName}, maximo de caracteres es 50.");

            RuleFor(cp => cp.Codigo).NotNull().WithMessage(" el campo {PropertyName}, es nulo.")
                .MinimumLength(5).WithMessage("el campo {PropertyName}, minimo 5 caracteres.");

            RuleFor(cp => cp.CreateUserId).GreaterThan(0).WithMessage("El campo {PropertyName} tiene que ser mayor a cero.");
        }
    }
}