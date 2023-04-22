using IngetMori.Domain.Core.ValueObjects.Keys;
using IngetMori.Domain.FamilieRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IngetMori.Persistence.Configuration.FamilieRoot;
internal class FamilieConfiguration : IEntityTypeConfiguration<Familie>
{
    public void Configure(EntityTypeBuilder<Familie> builder)
    {
        builder.ToTable(nameof(Familie));

        builder.HasKey(x => x.Id);
        builder.Property(f => f.Id).HasConversion(ValueConverters.GetEntityKeyConverter<FamilieId>());

        builder.Property(f => f.AanspreekNaam).IsRequired(false).HasMaxLength(60);

        builder.OwnsOne(f => f.Adres, builder =>
        {
            builder.Property(a => a.Straat).IsRequired(true).HasMaxLength(60);
            builder.Property(a => a.Huisnummer).IsRequired(true);
            builder.Property(a => a.Toevoegsel).IsRequired(false).HasMaxLength(6);
            builder.Property(a => a.Postcode).IsRequired(true).HasMaxLength(8);
            builder.Property(a => a.Woonplaats).IsRequired(true).HasMaxLength(60);
            builder.Property(a => a.Land).IsRequired(false).HasMaxLength(3);
        });

        builder.HasMany(f => f.Leden)
            .WithOne()
            .HasForeignKey(l => l.FamilieId);

        builder.HasMany(f => f.Notities)
            .WithOne()
            .HasForeignKey(not => not.FamilieId);

        builder.OwnsOne(f => f.AuditInfo, builder =>
        {
            builder.Property(ai => ai.CreatedBy).HasColumnName("Creator").IsRequired(false).HasMaxLength(60);
            builder.Property(ai => ai.CreatedOnUtc).HasColumnName("CreatedUtc").HasConversion(ValueConverters.UtcValueConverter).IsRequired(true);
            builder.Property(ai => ai.LastModifiedBy).HasColumnName("LastModifiedBy").IsRequired(false).HasMaxLength(60);
            builder.Property(ai => ai.ModifiedOnUtc).HasColumnName("ModifiedUtc").HasConversion(ValueConverters.UtcValueConverter).IsRequired(false);
        });

        builder.OwnsOne(f => f.DeletionInfo, builder =>
        {
            builder.Property(di => di.IsDeleted).HasColumnName("IsDeleted").IsRequired(true);
            builder.Property(di => di.DeletedBy).HasColumnName("DeletedBy").IsRequired(false).HasMaxLength(60);
            builder.Property(di => di.DeletedOnUtc).HasColumnName("DeletedUtc").HasConversion(ValueConverters.UtcValueConverter).IsRequired(false);
        });
    }
}