using IngetMori.Domain.Core.ValueObjects.Keys;
using IngetMori.Domain.FamilieRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IngetMori.Persistence.Configuration.FamilieRoot;

internal class TelefoonNummerConfiguration : IEntityTypeConfiguration<TelefoonNummer>
{
    public void Configure(EntityTypeBuilder<TelefoonNummer> builder)
    {
        builder.ToTable(nameof(TelefoonNummer));

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).HasConversion(ValueConverters.GetEntityKeyConverter<TelefoonNummerId>());

        builder.Property(t => t.LidId).HasConversion(ValueConverters.GetEntityKeyConverter<LidId>()).IsRequired(true);

        builder.Property(t => t.Nummer).HasMaxLength(24).IsRequired(true);

        builder.Property(t => t.Volgnummer);
    }
}
