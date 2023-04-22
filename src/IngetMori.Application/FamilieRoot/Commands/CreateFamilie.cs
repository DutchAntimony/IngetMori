using FluentValidation;
using IngetMori.Application.Common.Abstractions.Messaging;
using IngetMori.Application.Contract.FamilieRoot.InputDtos;
using IngetMori.Application.Contract.FamilieRoot.OutputDtos;
using IngetMori.Application.FamilieRoot.Mappers;
using IngetMori.Domain.Common.Primitives.Result;
using IngetMori.Domain.Core.Errors;
using IngetMori.Domain.Core.ValueObjects;
using IngetMori.Domain.Core.ValueObjectValidators;
using IngetMori.Domain.FamilieRoot;
using Microsoft.Extensions.Logging;

namespace IngetMori.Application.FamilieRoot.Commands;

public static class CreateFamilie
{
    public record Command : ICommand<FamilieDetailResult>
    {
        public Command(CreateFamilieRequest request)
        {
            Adres = new Adres(request.Straat, request.Huisnummer, request.Toevoegsel, request.Postcode, request.Woonplaats, request.Land);
        }
        public Adres Adres { get; init; }
    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            RuleFor(c => c.Adres).SetValidator(new AdresValidator());
        }
    }

    public class Handler : ICommandHandler<Command, FamilieDetailResult>
    {
        private readonly IFamilieRepository _repository;
        private readonly ILogger<Handler> _logger;

        public Handler(IFamilieRepository repository, ILogger<Handler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Result<FamilieDetailResult>> Handle(Command request, CancellationToken cancellationToken)
        {
            var adres = request.Adres;
            var familie = Familie.Create(adres);
            _logger.LogInformation("Created familie with id {id}", familie.Id);

            await _repository.InsertFamilieAsync(familie, cancellationToken);
            _logger.LogInformation("Saved created familie to the database");

            var result = FamilieMapper.MapToDetailDto(familie);
            return Result.SuccessIfNotNull(result, DomainErrors<Familie>.NotFound);
        }
    }
}