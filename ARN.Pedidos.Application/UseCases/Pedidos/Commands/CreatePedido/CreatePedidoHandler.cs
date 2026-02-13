using ARN.Pedidos.Application.DTOS.PedidosDTO.PedidoComandDTO;
using ARN.Pedidos.Application.Interfaces.Repository.Pedidos;
using ARN.Pedidos.Application.Wrappers;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ARN.Pedidos.Application.UseCases.Pedidos.Commands.CreatePedido
{
    internal class CreatePedidoHandler : IRequestHandler<CreatePedidoCommand, Response<ResultData>>
    {
        private readonly IPedidoCommandRepository _pedidoCommandRepository;
        private readonly ILogger<CreatePedidoHandler> _logger;

        public CreatePedidoHandler(IPedidoCommandRepository pedidoCommandRepository, ILogger<CreatePedidoHandler> logger)
        {
            _pedidoCommandRepository = pedidoCommandRepository;
            _logger = logger;
        }

        public async Task<Response<ResultData>> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                TimeZoneInfo tz = TimeZoneInfo.FindSystemTimeZoneById("America/Lima");

                var addRequest = new CreatePedidoDTO
                {
                    Nombre = request.Nombre != null ? request.Nombre.ToUpper().Trim() : null,
                    Codigo = request.Codigo != null ? request.Codigo.ToUpper().Trim() : null,
                    Direccion = request.Direccion,
                    Estado = true,
                    CreateUserId = request.CreateUserId,
                    CreateFecha = TimeZoneInfo.ConvertTime(DateTime.Now, tz)
                };

                long idNew = await _pedidoCommandRepository.CreatePedido(addRequest);

                if (idNew > 0)
                {
                    var result = new ResultData
                    {
                        NewId = idNew,
                        Message = "EL pedido se creo correctamente.",
                        Error = new List<string>()
                    };
                    return new Response<ResultData>(result, 200);
                }

                var _result = new ResultData
                {
                    NewId = idNew,
                    Message = "EL pedido no se creo correctamente.",
                    Error = new List<string>()
                };
                return new Response<ResultData>(_result, 500);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar pedido. Request: {@Request} . Message: {@Message}", request, ex.Message);
                var _result = new ResultData
                {
                    NewId = 0,
                    Message = $"Error al procesar la colicitus de creacion de pedido. {ex.Source}",
                    Error = new List<string> { ex.Message }
                };
                return new Response<ResultData>(_result, 500);
            }
        }
    }
}
