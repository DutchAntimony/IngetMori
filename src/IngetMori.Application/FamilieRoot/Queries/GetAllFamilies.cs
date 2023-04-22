using IngetMori.Application.Common.Abstractions.Messaging;
using IngetMori.Application.Contract.FamilieRoot.OutputDtos;
using IngetMori.Domain.Common.Primitives.Result;
using Microsoft.Extensions.Logging;
using IngetMori.Application.FamilieRoot.Mappers;
using IngetMori.Domain.Core.Errors;
using IngetMori.Domain.FamilieRoot;

namespace IngetMori.Application.FamilieRoot.Queries;
public static class GetAllFamilies
{
    public record Query() : IQuery<IEnumerable<FamilieResult>>;

    public class Handler : IQueryHandler<Query, IEnumerable<FamilieResult>>
    {
        private readonly IFamilieRepository _repository;
        private readonly ILogger<Handler> _logger;

        public Handler(IFamilieRepository repository, ILogger<Handler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<FamilieResult>>> Handle(Query request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Query for all families");
            var families = await _repository.GetAllFamiliesAsync(cancellationToken);

            if (families is null)
            {
                return Result<IEnumerable<FamilieResult>>.Failure(DomainErrors<Familie>.NonFound);
            }

            var result = families.Select(FamilieMapper.MapToDto);
            return Result.SuccessIfNotNull(result, DomainErrors<Familie>.NonFound);
        }
    }
}