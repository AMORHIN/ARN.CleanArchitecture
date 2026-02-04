using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace ARN.Pedidos.Application.Commons.Errores
{
    public class LogginBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LogginBehaviour<TRequest, TResponse>> _logger;

        public LogginBehaviour(ILogger<LogginBehaviour<TRequest, TResponse>> logger) => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var corelationId = Guid.NewGuid();
            _logger.LogInformation("Clean Architecture request Handling: {@corelationId} {name} {@request}",
                corelationId, typeof(TRequest).Name, JsonSerializer.Serialize(request));

            var response = await next();
            _logger.LogInformation("Clean Architecture request Handling: {@corelationId} {name} {@request}",
                corelationId, typeof(TRequest).Name, JsonSerializer.Serialize(request));

            return response;
        }
    }
}