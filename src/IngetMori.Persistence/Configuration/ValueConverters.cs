using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IngetMori.Persistence.Configuration;
internal static class ValueConverters
{
    internal static readonly ValueConverter<DateTime, DateTime> UtcValueConverter =
        new(
            outside => outside, 
            inside => DateTime.SpecifyKind(inside, DateTimeKind.Utc));

    internal static readonly ValueConverter<DateOnly, DateTime> DateOnlyValueConverter =
        new(
        modelDateOnly => modelDateOnly.ToDateTime(TimeOnly.MinValue),
        databaseDateTime => DateOnly.FromDateTime(databaseDateTime));

    internal static readonly ValueConverter<DateOnly?, DateTime?> NullableDateOnlyValueConverter =
        new(
            modelDateOnly => modelDateOnly.HasValue ? modelDateOnly.Value.ToDateTime(TimeOnly.MinValue) : null,
            databaseDateTime => databaseDateTime.HasValue ? DateOnly.FromDateTime(databaseDateTime.Value) : null);
}
