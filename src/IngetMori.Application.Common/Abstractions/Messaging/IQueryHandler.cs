using IngetMori.Domain.Common.Primitives.Result;
using MediatR;

namespace IngetMori.Application.Common.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{

}