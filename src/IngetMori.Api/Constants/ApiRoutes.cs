namespace IngetMori.Api.Constants;

public static class ApiRoutes
{
    public static class Families
    {
        internal const string CreateFamilie = "families";                           // Post
        internal const string GetAllFamilies = "families";                          // Get
        internal const string UpdateFamilie = "families/{id:Guid}";                 // Put
        internal const string GetFamilieById = "families/{id:Guid}";                // Get
    }
}
