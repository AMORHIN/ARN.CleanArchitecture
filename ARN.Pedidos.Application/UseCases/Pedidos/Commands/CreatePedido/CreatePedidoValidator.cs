using FluentValidation;

namespace ARN.Pedidos.Application.UseCases.Pedidos.Commands.CreatePedido
{
    public class CreatePedidoValidator : AbstractValidator<CreatePedidoCommand>
    {
        public CreatePedidoValidator()
        {
            RuleFor(cp => cp.Nombre)
                .MinimumLength(5).WithMessage("El campo {PropertyName}, minimo de caracteres es 3.")
                .NotEmpty().WithMessage("No puede ser campo vacio")
                .NotNull().WithMessage("No puede ser campo nulo")
                .MaximumLength(50);

            RuleFor(cp => cp.Codigo).MaximumLength(20).WithMessage(" el campo {PropertyName}, maximo de caracteres es 20.")
                .MinimumLength(5).WithMessage("");
        }
    }
}