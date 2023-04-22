using IngetMori.Api.Constants;
using IngetMori.Application.Contract.FamilieRoot.OutputDtos;
using IngetMori.Application.Contract.FamilieRoot.InputDtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using IngetMori.Application.FamilieRoot.Commands;
using IngetMori.Application.FamilieRoot.Queries;
using IngetMori.Domain.Core.ValueObjects.Keys;

namespace IngetMori.Api.Controllers;

public sealed class FamilieController : ApiControllerBase
{
    public FamilieController(ISender sender) : base(sender) { }

    [HttpPost(ApiRoutes.Families.CreateFamilie)]
    [ProducesResponseType(typeof(FamilieDetailResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateFamilie([FromBody] CreateFamilieRequest request)
    {
        var result = await Sender.Send(new CreateFamilie.Command(request));
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet(ApiRoutes.Families.GetAllFamilies)]
    [ProducesResponseType(typeof(IEnumerable<FamilieResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllFamilies()
    {
        var result = await Sender.Send(new GetAllFamilies.Query());
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpGet(ApiRoutes.Families.GetFamilieById)]
    [ProducesResponseType(typeof(FamilieDetailResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetFamilieById(Guid id)
    {
        var result = await Sender.Send(new GetFamilieById.Query(new FamilieId(id)));
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }

    [HttpPut(ApiRoutes.Families.UpdateFamilie)]
    [ProducesResponseType(typeof(FamilieDetailResult), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateFamilie(Guid id, [FromBody] UpdateFamilieRequest request)
    {
        var result = await Sender.Send(new UpdateFamilie.Command(new FamilieId(id), request));
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
}
