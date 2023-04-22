using FluentValidation;
using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Domain.Common.Extensions;
public static class FluentValidationExtensions
{
    public static IRuleBuilderOptions<TType, TProperty> WithError<TType, TProperty>(
        this IRuleBuilderOptions<TType, TProperty> rule, Error error)
    {
        return error is null
            ? throw new ArgumentNullException(nameof(error), "The error is required")
            : rule.WithErrorCode(error.Code).WithMessage(error.Message);
    }
}