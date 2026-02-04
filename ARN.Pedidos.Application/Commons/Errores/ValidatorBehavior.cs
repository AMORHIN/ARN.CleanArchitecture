using FluentValidation;
using MediatR;
using ValidationException = ARN.Pedidos.Application.Exceptions.ValidationException;

namespace ARN.Pedidos.Application.Commons.Errores
{
    public class ValidatorBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validatioResult = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                var failures = validatioResult.Where(r => r.Errors.Any()).SelectMany(x => x.Errors).ToList();

                if (!failures.Any())
                    throw new ValidationException(failures);
            }

            return await next();
        }
    }
}
