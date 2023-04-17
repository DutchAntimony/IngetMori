using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using IngetMori.Persistence.Configuration;

namespace IngetMori.Persistence.Extensions;

internal static class ModelBuilderExtensions
{
    internal static void ApplyUtcDateTimeConverter(this ModelBuilder modelBuilder) =>
        modelBuilder.Model.GetEntityTypes()
            .ForEach(mutableEntityType => mutableEntityType
                .GetProperties()
                .Where(p => p.ClrType == typeof(DateTime) && p.Name.EndsWith("Utc", StringComparison.Ordinal))
                .ForEach(mutableProperty => mutableProperty.SetValueConverter(ValueConverters.UtcValueConverter)));
}
