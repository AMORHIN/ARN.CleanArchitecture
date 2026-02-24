using ARN.Pedidos.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARN.Pedidos.Application.UseCases.Usuario.Queries.Login
{
    public record  LoginQuerie(string Usuario, string Password) : IRequest<Response<LoginModel>>;
}
