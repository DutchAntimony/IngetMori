using IngetMori.Domain.Common.Primitives.Result;
using MediatR;

namespace IngetMori.Application.Common.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{

}
