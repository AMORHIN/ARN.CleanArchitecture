using ARN.Pedido.Api.ApiKey;
using ARN.Pedidos.Application.UseCases.Pedidos.Commands.CreatePedido;
using ARN.Pedidos.Application.UseCases.Pedidos.Queries.GetAllPedido;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ARN.Pedido.Api.Controllers
{
    //[ApikeyAuthorization]
    [Authorize]
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

        [HttpGet("ListaPedido")]
        public async Task<IActionResult> ListaPedido(string? Nombre, string? Codigo)
        {
            var query = new GetAllPedidoQuery(Nombre, Codigo);
            var response = await _mediator.Send(query);
            return Ok(response);
        }
      
        [HttpGet("ListaPorIdPedido")]
        public async Task<IActionResult> ListaPorIdPedido([Required] long PedidoId)
        {
            //var query = new GetByIdAllPedidoQuery(PedidoId);
            var response = await _mediator.Send(1);
            return Ok(response);
        }

    }
}