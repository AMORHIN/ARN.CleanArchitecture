using ARN.Pedidos.Application.UseCases.Pedidos.Commands.CreatePedido;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ARN.Pedido.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator) => (_mediator) = (mediator);


        [HttpPost("CrearPedido")]
        public async Task<ActionResult<int>> CrearPedido(CreatePedidoCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

    }
}