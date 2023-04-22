using FluentValidation;
using IngetMori.Application.Common.Abstractions.Messaging;
using IngetMori.Application.Contract.FamilieRoot.InputDtos;
using IngetMori.Application.Contract.FamilieRoot.OutputDtos;
using IngetMori.Application.FamilieRoot.Mappers;
using IngetMori.Domain.Common.Primitives.Result;
using IngetMori.Domain.Common.Extensions;
using IngetMori.Domain.Core.Errors;
using IngetMori.Domain.Core.ValueObjects;
using IngetMori.Domain.Core.ValueObjects.Keys;
using Microsoft.Extensions.Logging;
using IngetMori.Domain.Core.ValueObjectValidators;
using IngetMori.Domain.FamilieRoot;

namespace IngetMori.Application.FamilieRoot.Commands;

public static class UpdateFamilie
{
    public record Command : ICommand<FamilieDetailResult>
    {
        public Command(FamilieId id, UpdateFamilieRequest request)
        {
            Id = id;
            AanspreekNaam = request.AanspreekNaam;
            Adres = new Adres(request.Straat, request.Huisnummer, request.Toevoegsel, request.Postcode, request.Woonplaats, request.Land);
        }
        public FamilieId Id { get; init; }
        public string? AanspreekNaam { get; init; }
        public Adres Adres { get; init; }
    }

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(c => c.Id.Value).NotEmpty().WithError(DomainErrors<Familie>.NoIdProvided);
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

        public async Task<Result<FamilieDetailResult>> Handle(Command command, CancellationToken cancellationToken)
        {
            var id = command.Id;
            var adres = command.Adres;
            _logger.LogInformation("Updating values for familie with Id {id}", id);

            var familie = await _repository.GetFamilieByIdAsync(id, cancellationToken);
            if (familie is null)
            {
                _logger.LogInformation("Can't find familie with Id {id}", id);
                return Result<FamilieDetailResult>.Failure(DomainErrors<Familie>.NotFound);
            }

            familie.Update(command.AanspreekNaam, adres);
            await _repository.SaveChangesAsync(cancellationToken);

            var result = FamilieMapper.MapToDetailDto(familie);
            return Result.SuccessIfNotNull(result, DomainErrors<Familie>.NotFound);
        }
    
    }
}
