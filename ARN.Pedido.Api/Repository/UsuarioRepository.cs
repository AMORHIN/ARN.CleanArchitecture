using ARN.Pedido.Api.Interfaces;
using ARN.Pedido.Api.Model;

namespace ARN.Pedido.Api.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Task<int> CrearUsuario(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> ListaIdUsuarios(int UsuarioId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> ListaUsuarios(string? nombre)
        {
            return new List<UserModel>()
            {
                new UserModel
                {
                    UserId = 1,
                    User = "Amorhin",
                    Password = "",
                    Gmail = "amorhin@gmail.com"
                },
                new UserModel
                {
                    UserId = 1,
                    User = "alex",
                    Password = "",
                    Gmail = "ales@gmail.com"
                }
            };
        }
    }
}
