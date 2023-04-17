using FluentValidation;
using IngetMori.Application.Common.Abstractions.Messaging;
using IngetMori.Application.Common.Abstractions.Services;
using IngetMori.Application.Common.Extensions;
using IngetMori.Application.Contract.Sale;
using IngetMori.Domain.Common.Primitives.Result;
using IngetMori.Domain.Sales;
using Microsoft.Extensions.Logging;
using IngetMori.Domain.Core.Errors;
using IngetMori.Domain.Core.ValueObjects;

namespace IngetMori.Application.Commands.Sales;
public class CreateSale
{
    public record Command(CreateSaleRequest Dto) : ICommand<SaleResult>;

    public class Validator : AbstractValidator<Command>
    {
        public Validator()
        {
            ClassLevelCascadeMode = CascadeMode.Stop;
            RuleFor(command => command.Dto).NotNull();
            RuleFor(command => command.Dto.Value).GreaterThan(decimal.Zero).WithError(DomainErrors.Money.ValueNotNegative);
            RuleFor(command => command.Dto.Currency).NotEmpty().WithError(DomainErrors.Money.CurrencyCodeNotEmpty);
        }
    }

    public class Handler : ICommandHandler<Command, SaleResult>
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger<Handler> _logger;

        public Handler(IDbContext dbContext, ILogger<Handler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Result<SaleResult>> Handle(Command request, CancellationToken cancellationToken)
        {
            var inputDto = request.Dto;

            var sale = Sale.Create(inputDto.Title, new Money(inputDto.Value, inputDto.Currency));
            _dbContext.Insert<Sale, SaleKey>(sale);
            _logger.LogInformation("Added new sale with Id {id}", sale.Id.Value);
            await _dbContext.SaveChangesAsync(cancellationToken);
            var result = new SaleResult(sale.Id, sale.Description, sale.Price);
            return result;
        }
    }
}
