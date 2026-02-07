using ARN.Pedidos.Application.DTOS.PedidosDTO.PedidoQuerieDTO;
using ARN.Pedidos.Application.Interfaces.Repository.Pedidos;
using ARN.Pedidos.Infrastructure.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;

namespace ARN.Pedidos.Infrastructure.Persistence.Repository.Pedidos
{
    internal class PedidoQuerieRepository : IPedidoQuerieRepository
    {
        protected DataBasePedioServices _context;

        public PedidoQuerieRepository(DataBasePedioServices context) => _context = context;

        public async Task<IEnumerable<GetAllPedidoDTO>> GetAllPedido()
        {
            var result = await (from t1 in _context.Pediddos
                                join t2 in _context.PedidoDetalles on t1.PedidoId equals t2.PedidoId
                                where t1.Estado.Equals(true) && t2.Estado == true
                                select new GetAllPedidoDTO
                                {
                                    PedidoId = t1.PedidoId,
                                    Codigo = t1.Codigo,
                                    Nombre = t1.Nombre,
                                    Direccion = t1.Direccion,
                                    //camelCase
                                    //PascalCase
                                    //Snake_case
                                }).ToListAsync();
            return result;
        }

        public Task<GetByIdPedidoDTO> GetByIdPedido(long PedidoId)
        {
            throw new NotImplementedException();
        }
    }
}
