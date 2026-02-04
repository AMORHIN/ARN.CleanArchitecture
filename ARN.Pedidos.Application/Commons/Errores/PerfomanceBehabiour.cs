using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.Json;

namespace ARN.Pedidos.Application.Commons.Errores
{
    public class PerfomanceBehabiour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public PerfomanceBehabiour(Stopwatch timer, ILogger<TRequest> logger)
        => (_timer, _logger) = (timer, logger);

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();
            var response = await next();
            _timer.Stop();

            var timerMilliseconds = _timer.ElapsedMilliseconds;
            if (timerMilliseconds > 30)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogInformation("Clean Architecture Running: {@Name} {ElapsedMilliseconds} {@request}",
                requestName, timerMilliseconds, JsonSerializer.Serialize(request));
            }
            return response;
        }
    }
}