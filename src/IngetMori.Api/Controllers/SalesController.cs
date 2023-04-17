using IngetMori.Api.Constants;
using IngetMori.Application.Commands.Sales;
using IngetMori.Application.Contract.Sale;
using IngetMori.Application.Queries.Sales;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IngetMori.Api.Controllers;

public sealed class SalesController : ApiControllerBase
{
    public SalesController(ISender sender) : base(sender) { }

    [HttpPost(ApiRoutes.Sales.CreateSale)]
    [ProducesResponseType(typeof(SaleResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSale([FromBody] CreateSaleRequest request)
    {
        var result = await Sender.Send(new CreateSale.Command(request));
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet(ApiRoutes.Sales.GetAllSales)]
    [ProducesResponseType(typeof(IEnumerable<SaleResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllSales()
    {
        var result = await Sender.Send(new GetAllSales.Query()); 
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
