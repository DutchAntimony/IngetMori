using IngetMori.Domain.Common.Primitives;

namespace IngetMori.Api.Constants;

internal static class Errors
{
    internal static Error UnProcessableRequest => new (
        "API.UnProcessableRequest",
        "De server kan de gevraagde actie niet uitvoeren.");

    internal static Error ServerError => new (
        "API.ServerError", 
        "Er is een fatale fout opgetreden.");
}
