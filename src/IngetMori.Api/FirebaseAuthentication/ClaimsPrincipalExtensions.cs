using System.Security.Claims;
using System.Text.Json;

namespace IngetMori.Api.FirebaseAuthentication;

public static class ClaimsPrincipalExtensions
{
    public static string GetFireBaseAuthEmailAddress(this ClaimsPrincipal principal)
    {
        var firebaseClaim = principal.Claims.FirstOrDefault(c => c.Type == "firebase")?.Value ?? "not found";
        var firebaseAuthResult = JsonSerializer.Deserialize<FirebaseAuthResult>(firebaseClaim);
        return firebaseAuthResult?.GetEmail() ?? "Not found";
    }

#pragma warning disable IDE1006 // Naming Styles -- justification: json deserialization
    public record FirebaseAuthResult(Identities identities, string sign_in_provider)
    {
        public string? GetEmail() => identities?.email?.FirstOrDefault();
    }

    public record Identities(string[] email);
#pragma warning restore IDE1006 // Naming Styles -- justification: json deserialization
}