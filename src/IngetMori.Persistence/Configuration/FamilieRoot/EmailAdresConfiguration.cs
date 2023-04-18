using IngetMori.Domain.Core.ValueObjects.Keys;
using IngetMori.Domain.FamilieRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IngetMori.Persistence.Configuration.FamilieRoot;

internal class EmailAdresConfiguration : IEntityTypeConfiguration<EmailAdres>
{
    public void Configure(EntityTypeBuilder<EmailAdres> builder)
    {
        builder.ToTable(nameof(EmailAdres));

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasConversion(ValueConverters.GetEntityKeyConverter<EmailAdresId>());

        builder.Property(t => t.LidId).HasConversion(ValueConverters.GetEntityKeyConverter<LidId>()).IsRequired(true);

        builder.Property(t => t.Value).HasMaxLength(255).IsRequired(true);

        builder.Property(t => t.Volgnummer);
    }
}