using IngetMori.Domain.Common.Primitives.Result;
using MediatR;

namespace IngetMori.Application.Common.Abstractions.Messaging;
public interface ICommand : IRequest<Result>
{

}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{

}