using ARN.Pedidos.Application.DTOS.UserDTO;
using ARN.Pedidos.Application.Interfaces.External.JwtToken;
using ARN.Pedidos.Application.Interfaces.Repository.UserRepo;
using ARN.Pedidos.Application.Wrappers;
using MediatR;

namespace ARN.Pedidos.Application.UseCases.Usuario.Command.Create
{
    internal class CreateUserHandler : IRequestHandler<CreateUserCommand, Response<ResultData>>
    {
        private readonly ITokenJwtService _tokenJwtService;
        private readonly IUserCommandRepository _userCommandRepository;
        private readonly IUserQueryRepository _userQuerieRepository;

        public CreateUserHandler(ITokenJwtService tokenJwtService, IUserCommandRepository userCommandRepository, IUserQueryRepository userQuerieRepository)
        {
            _tokenJwtService = tokenJwtService;
            _userCommandRepository = userCommandRepository;
            _userQuerieRepository = userQuerieRepository;
        }

        public async Task<Response<ResultData>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var userExiste = await _userQuerieRepository.GetUserDTO(request.Usuario);
                if (userExiste.Count > 0)
                {
                    var _error = new ResultData
                    {
                        NewId = 0,
                        Message = "Ya existe el usuario.",
                        Error = new List<string> { }
                    };

                    return new Response<ResultData> ( _error, 1025 );
                }

                var passwordIncreptado = _tokenJwtService.Hash(request.Password);
                var userRequest = new CreateUserDTO
                {
                    Usuario = request.Usuario,
                    RolId = request.RolId,
                    Password = passwordIncreptado,
                    Correo = request.Correo,
                    Telefono = request.Telefono
                };

                int idNew = await _userCommandRepository.CreateUser(userRequest);

                if (idNew == 0)
                {
                    var _error = new ResultData
                    {
                        NewId = 0,
                        Message = "No se registro el usuario.",
                        Error = new List<string> { }
                    };
                    return new Response<ResultData>(_error, 1025);
                }

                var _registro = new ResultData
                {
                    NewId = idNew,
                    Message = "Se registro correctamente el usuario.",
                    Error = new List<string> { }
                };
                return new Response<ResultData>(_registro, 200);

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
