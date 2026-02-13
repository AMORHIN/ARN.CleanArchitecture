
using ARN.Pedido.Api.ApiKey;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ARN.Pedido.Api.Controllers
{
    [ApikeyAuthorization]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //private readonly IUsuarioServices _usuarioServices;

        //public UserController(IUsuarioServices usuarioServices)
        //{
        //    _usuarioServices = usuarioServices;
        //}

        [HttpGet]
        public async Task<IActionResult> ListaUsuario(string? nombre)
        {
            var _listUsuario = ""; //await _usuarioServices.ListaUsuarios(nombre);
            return Ok(_listUsuario);
        }
    }
}
