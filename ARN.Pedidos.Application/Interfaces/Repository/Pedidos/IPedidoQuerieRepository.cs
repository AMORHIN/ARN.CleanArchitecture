using ARN.Pedidos.Application.DTOS.PedidosDTO.PedidoQuerieDTO;

namespace ARN.Pedidos.Application.Interfaces.Repository.Pedidos
{
    public interface IPedidoQuerieRepository
    {
        Task<IEnumerable<GetAllPedidoDTO>> GetAllPedido();
        Task<GetByIdPedidoDTO> GetByIdPedido(long PedidoId);
    }
}
