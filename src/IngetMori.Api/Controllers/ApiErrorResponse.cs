using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Api.Controllers;

public class ApiErrorResponse
{
    public ApiErrorResponse(IReadOnlyCollection<Error> errors) => Errors = errors;

    public IReadOnlyCollection<Error> Errors { get; }
}