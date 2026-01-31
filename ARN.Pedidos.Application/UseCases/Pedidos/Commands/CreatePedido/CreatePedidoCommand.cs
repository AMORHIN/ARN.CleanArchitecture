using MediatR;

namespace ARN.Pedidos.Application.UseCases.Pedidos.Commands.CreatePedido
{
    //public class CreatePedidoCommandd : IRequest<int>
    //{
    //    public string? Codigo { get; set; }
    //    public string? Nombre { get; set; }
    //    public string? Direccion { get; set; }

    //    public CreatePedidoCommandd(string? codigo, string? nombre, string? direccion)
    //    {
    //        Codigo = codigo;
    //        Nombre = nombre;
    //        Direccion = direccion;
    //    }
    //}


    public record CreatePedidoCommand(
        string? Codigo,
        string? Nombre,
        string? Direccion
    ) : IRequest<int>;
    
}