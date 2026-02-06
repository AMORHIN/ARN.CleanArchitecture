using FluentValidation.Results;

namespace ARN.Pedidos.Application.Commons.Exceptions
{
    public class ValidationExceptionCustom : Exception
    {
        public List<string> Errors { get; }
        public ValidationExceptionCustom() : base("Se han presentado uno o más fallos de validación.")
        {
            Errors = [];
        }

        public ValidationExceptionCustom(IEnumerable<ValidationFailure> failures) : this()
        {
            var errors = failures.Select(f => f.ErrorMessage).ToList();
            Errors = errors;
        }
    }
}