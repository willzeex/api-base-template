using FluentValidation;
using MediatR;
using Noazul.Domain.Core;
using Nudes.Retornator.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Noazul.Infra.CrossCutting.Bus.Behaviors;

public class FailFastRequestBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : Result
{
    private readonly IEnumerable<IValidator<TRequest>> validators;

    public FailFastRequestBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        this.validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var failedValidations = validators
             .Select(v => v.Validate(request))
             .Where(v => !v.IsValid)
             .ToList();

        if (failedValidations.Any())
        {
            var fieldErrors = new FieldErrors();
            var errors = failedValidations
                .SelectMany(f => f
                    .Errors
                    .Select(e => new ValidatorErrorDetail()
                    {
                        PropertyName = e.PropertyName,
                        ErrorMessage = e.ErrorMessage,
                        PropertyValue = e.FormattedMessagePlaceholderValues?["PropertyValue"]?.ToString() ?? "",
                    }))
                .GroupBy(d => d.PropertyName);

            foreach (var error in errors)
                fieldErrors.Add(error.Key, error.Select(d => d.ErrorMessage).ToArray());

            var result = System.Activator.CreateInstance<TResponse>();
            result.Error = new BadRequestError()
            {
                FieldErrors = fieldErrors
            };

            return result;
        }

        return await next();
    }
}

public class ValidatorErrorDetail
{
    public string PropertyName { get; set; }
    public string PropertyValue { get; set; }
    public string ErrorMessage { get; set; }
}

public class ValidatorErroDetailPropertyNameEqualityComparer : IEqualityComparer<ValidatorErrorDetail>
{
    public bool Equals(ValidatorErrorDetail x, ValidatorErrorDetail y)
    {
        if (y is null || x is null) return false;

        return x.PropertyName.Equals(y.PropertyName);
    }

    public int GetHashCode(ValidatorErrorDetail obj) => obj.PropertyName.GetHashCode();
}
