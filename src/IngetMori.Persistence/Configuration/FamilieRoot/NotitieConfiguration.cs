using IngetMori.Domain.Core.ValueObjects.Keys;
using IngetMori.Domain.FamilieRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IngetMori.Persistence.Configuration.FamilieRoot;

internal class NotitieConfiguration : IEntityTypeConfiguration<Notitie>
{
    public void Configure(EntityTypeBuilder<Notitie> builder)
    {
        builder.ToTable(nameof(Notitie));

        builder.HasKey(n => n.Id);
        builder.Property(n => n.Id).HasConversion(ValueConverters.GetEntityKeyConverter<NotitieId>());

        builder.Property(n => n.Discriminator).IsRequired(true);

        builder.Property(n => n.FamilieId).HasConversion(ValueConverters.GetEntityKeyConverter<FamilieId>()).IsRequired(true);
        builder.Property(n => n.LidId).HasConversion(ValueConverters.GetEntityKeyConverter<LidId>()).IsRequired(false);

        builder.Property(n => n.Value).IsRequired(false);

        builder.Property(n => n.Volgnummer);
    }
}