using ARN.Pedidos.Application.Wrappers;
using MediatR;

namespace ARN.Pedidos.Application.UseCases.Pedidos.Queries.GetAllPedido
{
    //public class GetAllPedidoQuery : IRequest<Response<List<GetAllPedidoModel>>>
    //{
    //    public string? NombrePedido { get; set; }
    //    public string? Codigo { get; set; }

    //    public GetAllPedidoQuery(string? nombrePedido, string? codigo)
    //    {
    //        NombrePedido = nombrePedido;
    //        Codigo = codigo;
    //    }
    //}

    public record GetAllPedidoQuery
       (
        string? NombrePedido,
        string? Codigo
       ) : IRequest<Response<List<GetAllPedidoModel>>>;

}
