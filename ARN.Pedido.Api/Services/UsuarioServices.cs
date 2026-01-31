using ARN.Pedido.Api.Interfaces;
using ARN.Pedido.Api.Model;

namespace ARN.Pedido.Api.Services
{
    public class UsuarioServices : IUsuarioServices
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioServices(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public async Task<int> CrearUsuario(UserModel userModel)
        {
            if(userModel.User != "")
            {

            }

            if (userModel.User == null)
            {

            }


            var usuario = await _usuarioRepository.ListaUsuarios(userModel.User);

            if (usuario.Count == 0)
            {
                int idNew = await _usuarioRepository.CrearUsuario(userModel);
                return idNew;
            }

            return 0;
        }

        public Task<int> ActualizarUsuario(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> ListaIdUsuarios(int UsuarioId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> ListaUsuarios(string? nombre)
        {
            var listUsuario = await _usuarioRepository.ListaUsuarios(nombre);

            var result = listUsuario.Where(x => x.User == nombre).Select(x => new UserModel
            {
                UserId = x.UserId,
                User = x.User,
                Password = x.Password,
                Gmail = x.Gmail
            }).ToList();

            return result;
        }
    }
}
