using ARN.Pedidos.Application.Exceptions;
using ARN.Pedidos.Application.Wrappers;
using Newtonsoft.Json;
using System.Net;

namespace ARN.Pedido.Api.Midleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                bool success = false;
                context.Response.ContentType = "application/json";
                var statusCode = (int)HttpStatusCode.InternalServerError;
                var result = string.Empty;

                switch (ex)
                {
                    case NotFoundException notFoundException:
                        statusCode = (int)HttpStatusCode.NotFound;
                        result = JsonConvert.SerializeObject(new Response<string>(null, statusCode, ex.Message)
                        {
                            Success = false
                        });
                        break;

                    case ValidationException validationException:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        var validatioJson = JsonConvert.SerializeObject(validationException.Errors);
                        result = JsonConvert.SerializeObject(
                            new Response<IDictionary<string, string[]>>(
                                validationException.Errors,
                                statusCode,
                                validationException.Message
                            )
                            {
                                Success = false
                            });
                        break;

                    //case BadRequestException badRequestException:
                    //    statusCode = (int)HttpStatusCode.BadRequest;
                    //    result = JsonConvert.SerializeObject(
                    //        new Response<string>(null, statusCode, ex.Message)
                    //        {
                    //            Success = false
                    //        });
                    //    break;

                    default:
                        result = JsonConvert.SerializeObject(
                            new Response<string>(null, statusCode, ex.Message)
                            {
                                Success = false
                            });
                        break;
                }

                //if (string.IsNullOrEmpty(result))
                //{
                //    result = JsonConvert.SerializeObject(new CodeErrorException(success, statusCode, ex.Message, ex.Source));
                //}

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(result);
            }
        }
    }
}
