using IngetMori.Domain.Sales;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IngetMori.Persistence.Configuration.Sales;
internal sealed class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable(nameof(Sale));

        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).HasConversion(
            ValueConverters.GetEntityKeyConverter<SaleKey>());

        builder.OwnsOne(s => s.Price, builder =>
        {
            builder.Property(p => p.Value).HasColumnName("Price").IsRequired();
            builder.Property(p => p.CurrencyCode).HasColumnName("Currency").IsRequired();
        });
    }
}
