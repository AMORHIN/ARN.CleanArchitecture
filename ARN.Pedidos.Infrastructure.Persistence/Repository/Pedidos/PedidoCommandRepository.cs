using ARN.Pedidos.Application.DTOS.PedidosDTO.PedidoComandDTO;
using ARN.Pedidos.Application.Interfaces.Repository.Pedidos;
using ARN.Pedidos.Damain.PedidoEntities;
using ARN.Pedidos.Infrastructure.Persistence.DataBase;

namespace ARN.Pedidos.Infrastructure.Persistence.Repository.Pedidos
{
    internal class PedidoCommandRepository : IPedidoCommandRepository
    {
        protected DataBasePedioServices _context;

        public PedidoCommandRepository(DataBasePedioServices context) => _context = context;

        public async Task<long> CreatePedido(CreatePedidoDTO createPedido)
        {
            var myTransaction = _context.Database.BeginTransaction();

            var cp = new Pediddos
            {
                Codigo = createPedido.Codigo,
                Nombre = createPedido.Nombre,
                Direccion = createPedido.Direccion,

                Estado = createPedido.Estado,
                CreateUserId = createPedido.CreateUserId,
                CreateFecha = createPedido.CreateFecha
            };
            await _context.Pediddos.AddAsync(cp);
            await _context.SaveChangesAsync();

            var cpd = new PedidoDetalles
            {
                PedidoId = cp.PedidoId,
                EstadoCourierId = 1,

                Estado = createPedido.Estado,
                CreateUserId = createPedido.CreateUserId,
                CreateFecha = createPedido.CreateFecha
            };

            await _context.PedidoDetalles.AddAsync(cpd);
            await _context.SaveChangesAsync();

            await myTransaction.CommitAsync();

            return cp.PedidoId;
        }

        public Task<long> DeletePedido(DeletePedidoDTO deletePedido)
        {
            throw new NotImplementedException();
        }

        public Task<long> UpdatePedido(UpdatePedidoDTO updatePedido)
        {
            throw new NotImplementedException();
        }
    }
}
