using ARN.Pedidos.Application.Wrappers;
using MediatR;

namespace ARN.Pedidos.Application.UseCases.Usuario.Command.Create
{
    public record CreateUserCommand
    (
        int RolId,
        string Usuario,
        string Password,
        string Correo,
        string Telefono
    ) : IRequest<Response<ResultData>>;
}
