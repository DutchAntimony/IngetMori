using IngetMori.Domain.IncassoMandaadRoot;
using IngetMori.Domain.IncassoMandaadRoot.IncassoMandaten;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IngetMori.Persistence.Configuration.IncassoMandaadRoot;
internal class IncassoMandaadConfiguration : IEntityTypeConfiguration<IncassoMandaad>
{
    public void Configure(EntityTypeBuilder<IncassoMandaad> builder)
    {
        builder.ToTable(nameof(IncassoMandaad));

        builder.HasKey(im => im.Id);
        builder.Property(im => im.Id).HasConversion(ValueConverters.GetEntityKeyConverter<IncassoMandaadId>());

        builder.OwnsOne(im => im.Iban, builder =>
        {
            builder.Property(i => i.Nummer).HasColumnName("Iban").HasMaxLength(24).IsRequired(true);
            builder.Property(i => i.Bic).HasColumnName("Bic").HasMaxLength(9).IsRequired(false);
            builder.Property(i => i.TenNameVan).IsRequired(true);
        });

        builder.Property(im => im.MandaadType).IsRequired(false);
        builder.Property(im => im.MandaadDatum).IsRequired(false).HasConversion(ValueConverters.NullableDateOnlyValueConverter);
    }
}
