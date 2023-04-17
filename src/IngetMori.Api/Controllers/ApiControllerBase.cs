using IngetMori.Domain.Common.Primitives;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IngetMori.Api.Controllers;

[Route("api")]
public class ApiControllerBase : ControllerBase
{
    protected ApiControllerBase(ISender sender) => Sender = sender;

    protected ISender Sender;

    // 400 Bad Request
    protected IActionResult BadRequest(Error error) => BadRequest(new ApiErrorResponse(new[] { error }));

    // 200 Ok
    protected new IActionResult Ok(object value) => base.Ok(value);

    // 404 Not Found
    protected new IActionResult NotFound() => NotFound("De opgevraagde gegevens konden niet worden gevonden.");
}
