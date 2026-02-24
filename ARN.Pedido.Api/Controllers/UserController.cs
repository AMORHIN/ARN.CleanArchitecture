
using ARN.Pedido.Api.ApiKey;
using ARN.Pedidos.Application.UseCases.Usuario.Command.Create;
using ARN.Pedidos.Application.UseCases.Usuario.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARN.Pedido.Api.Controllers
{
    //[ApikeyAuthorization]
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) => _mediator = mediator;


        [HttpPost("CrearUsuario")]
        public async Task<ActionResult<int>> CrearUsuario([FromBody] CreateUserCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> ListaUsuario(string? nombre)
        {
            var _user = "";
            return Ok(_user);
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginQuerie query)
        {
            var user = await _mediator.Send(query);
            return Ok(user);
        }
    }
}
