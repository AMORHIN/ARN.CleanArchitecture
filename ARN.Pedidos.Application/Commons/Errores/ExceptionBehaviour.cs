using MediatR;
using Microsoft.Extensions.Logging;

namespace ARN.Pedidos.Application.Commons.Errores
{
    public class ExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public ExceptionBehaviour(ILogger<TRequest> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogInformation(ex, "Clean Architecture Request: Sucedio una excepcion {Name} {@Request}",
                requestName, request);
                throw;
            }
        }
    }
}
