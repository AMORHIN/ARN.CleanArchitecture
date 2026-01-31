using FluentValidation;

namespace ARN.Pedidos.Application.UseCases.Pedidos.Commands.CreatePedido
{
    public class CreatePedidoValidator : AbstractValidator<CreatePedidoCommand>
    {
        public CreatePedidoValidator()
        {
            RuleFor(cp => cp.Nombre)
                .MinimumLength(5).WithMessage("El campo, minimo de caracteres es 3.")
                .NotEmpty().WithMessage("No puede ser campo vacio")
                .NotNull().WithMessage("No puede ser campo nulo")
                .MaximumLength(15)
                ;

            RuleFor(cp => cp.Codigo).MaximumLength(20).WithMessage("")
                .MinimumLength(5).WithMessage("");
        }
    }
}
