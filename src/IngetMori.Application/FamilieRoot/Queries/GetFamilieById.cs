using IngetMori.Application.Common.Abstractions.Messaging;
using IngetMori.Application.Contract.FamilieRoot.OutputDtos;
using IngetMori.Domain.Common.Primitives.Result;
using IngetMori.Domain.Core.ValueObjects.Keys;
using Microsoft.Extensions.Logging;
using IngetMori.Application.FamilieRoot.Mappers;
using IngetMori.Domain.Core.Errors;
using IngetMori.Domain.Common.Extensions;
using FluentValidation;
using IngetMori.Domain.FamilieRoot;

namespace IngetMori.Application.FamilieRoot.Queries;

public static class GetFamilieById
{
    public record Query(FamilieId Id) : IQuery<FamilieDetailResult>;

    public class Validator : AbstractValidator<Query>
    {
        public Validator()
        {
            RuleFor(q => q.Id.Value).NotEmpty().WithError(DomainErrors<Familie>.NoIdProvided);
        }

    }

    public class Handler : IQueryHandler<Query, FamilieDetailResult>
    {
        private readonly IFamilieRepository _repository;
        private readonly ILogger<Handler> _logger;

        public Handler(IFamilieRepository repository, ILogger<Handler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Result<FamilieDetailResult>> Handle(Query request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Querying for familie with id {id}", request.Id);
            var familie = await _repository.GetFamilieByIdAsync(request.Id, cancellationToken);
            if (familie is null)
            {
                return Result<FamilieDetailResult>.Failure(DomainErrors<Familie>.NotFound);
            }
            var result = FamilieMapper.MapToDetailDto(familie);
            return Result.SuccessIfNotNull(result, DomainErrors<Familie>.NotFound);
        }
    }
}
