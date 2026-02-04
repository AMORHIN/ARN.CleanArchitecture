using ARN.Pedidos.Application.DTOS.PedidosDTO.PedidoComandDTO;

namespace ARN.Pedidos.Application.Interfaces.Repository.Pedidos
{
    public interface IPedidoCommandRepository
    {
        Task<long> CreatePedido(CreatePedidoDTO createPedido);
        Task<long> UpdatePedido(UpdatePedidoDTO updatePedido);
        Task<long> DeletePedido(DeletePedidoDTO deletePedido);
    }
}