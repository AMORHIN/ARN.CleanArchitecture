using ARN.Pedidos.Application.Interfaces.Repository.Pedidos;
using ARN.Pedidos.Application.Wrappers;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARN.Pedidos.Application.UseCases.Pedidos.Queries.GetAllPedido
{
    internal class GetAllPedidoHandler : IRequestHandler<GetAllPedidoQuery, Response<List<GetAllPedidoModel>>>
    {
        private readonly IPedidoQuerieRepository _pedidoQuerieRepository;
        private readonly ILogger<GetAllPedidoHandler> _logger;

        public GetAllPedidoHandler(IPedidoQuerieRepository pedidoQuerieRepository, ILogger<GetAllPedidoHandler> logger)
        => (_pedidoQuerieRepository, _logger) = (pedidoQuerieRepository, logger);

        public async Task<Response<List<GetAllPedidoModel>>> Handle(GetAllPedidoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await _pedidoQuerieRepository.GetAllPedido();

                var resultData = result.Select(item => new GetAllPedidoModel
                {
                    PedidoId = item.PedidoId,
                    Codigo = item.Codigo,
                    Nombre = item.Nombre ?? "No tiene Nombre",
                    Direccion = item.Direccion,
                    FechaCreacion = item.FechaCreacion != null ? item.FechaCreacion.ToString("yyyy-MM-dd HH:mm:ss") : null,
                    PedidoDetalle = result.Select(item2 => new PedidoDetalleModel
                    {

                    }).ToList(),
                }).ToList();

                return new Response<List<GetAllPedidoModel>>(resultData, 200);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
