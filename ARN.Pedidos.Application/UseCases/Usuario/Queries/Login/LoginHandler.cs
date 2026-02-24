using ARN.Pedidos.Application.DTOS.JwtDTO;
using ARN.Pedidos.Application.Interfaces.External.JwtToken;
using ARN.Pedidos.Application.Interfaces.Repository.UserRepo;
using ARN.Pedidos.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARN.Pedidos.Application.UseCases.Usuario.Queries.Login
{
    internal class LoginHandler : IRequestHandler<LoginQuerie, Response<LoginModel>>
    {
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly ITokenJwtService _tokenJwtService;

        public LoginHandler(IUserQueryRepository userQueryRepository, ITokenJwtService tokenJwtService)
        {
            _userQueryRepository = userQueryRepository;
            _tokenJwtService = tokenJwtService;
        }

        public async Task<Response<LoginModel>> Handle(LoginQuerie request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userQueryRepository.getUserPassword(request.Usuario);
                if (user == null)
                    return new Response<LoginModel>(null, 1043);

                var _userr = new UserPasswordDTO
                {
                    UsuarioId = user.UsuarioId,
                    Usuario = user.Usuario,
                    Rol = user.Rol
                };

                var _user = new LoginModel
                {
                    Token = string.Empty,
                };

                var validador = _tokenJwtService.Check(user.Password, request.Password);

                _user.Token = _tokenJwtService.GeradorTOken(_userr);

                return new Response<LoginModel>(_user, 200);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
