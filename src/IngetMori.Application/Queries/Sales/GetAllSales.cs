using IngetMori.Application.Common.Abstractions.Messaging;
using IngetMori.Application.Common.Abstractions.Services;
using IngetMori.Application.Contract.Sale;
using IngetMori.Domain.Common.Primitives;
using IngetMori.Domain.Common.Primitives.Result;
using IngetMori.Domain.Sales;
using Microsoft.Extensions.Logging;

namespace IngetMori.Application.Queries.Sales;
public class GetAllSales
{
    public record Query() : IQuery<IEnumerable<SaleResult>>;

    public class Handler : IQueryHandler<Query, IEnumerable<SaleResult>>
    {
        private readonly IDbContext _dbContext;
        private readonly ILogger<Handler> _logger;

        public Handler(IDbContext dbContext, ILogger<Handler> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<Result<IEnumerable<SaleResult>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var sales = await _dbContext.GetAllAsync<Sale, SaleKey>();
            _logger.LogInformation("Received {count} sales entries from the database", sales.Count());
            var result = sales.Select(sale => new SaleResult(sale.Id, sale.Description, sale.Price));
            return Result<IEnumerable<SaleResult>>.SuccessIfNotNull(result, new Error("a", "b"));
        }
    }
}
