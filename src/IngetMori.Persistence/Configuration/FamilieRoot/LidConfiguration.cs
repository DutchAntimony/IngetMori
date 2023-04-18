using IngetMori.Domain.Core.ValueObjects.Keys;
using IngetMori.Domain.FamilieRoot;
using IngetMori.Domain.IncassoMandaadRoot.IncassoMandaten;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IngetMori.Persistence.Configuration.FamilieRoot;

internal class LidConfiguration : IEntityTypeConfiguration<Lid>
{
    public void Configure(EntityTypeBuilder<Lid> builder)
    {
        builder.ToTable(nameof(Lid));

        builder.HasKey(l => l.Id);
        builder.Property(l => l.Id).HasConversion(ValueConverters.GetEntityKeyConverter<LidId>());

        builder.Property(l => l.Lidnummer).IsRequired(true);

        builder.OwnsOne(l => l.Personalia, builder =>
        {
            builder.Property(p => p.Voornaam).IsRequired(true);
            builder.Property(p => p.Tussenvoegsel).IsRequired(false);
            builder.Property(p => p.Achternaam).IsRequired(true);
            builder.Property(p => p.Geslacht).IsRequired(true);
            builder.Property(p => p.Geboortedatum).HasConversion(ValueConverters.DateOnlyValueConverter).IsRequired(true);
        });

        builder.HasMany(l => l.Telefoonnummers)
            .WithOne()
            .HasForeignKey(t => t.LidId);

        builder.HasMany(l => l.EmailAdressen)
            .WithOne()
            .HasForeignKey(e => e.LidId);

        builder.Property(l => l.Betaalwijze).IsRequired(true);

        builder.Property(l => l.IncassoMandaadId)
            .HasConversion(ValueConverters.GetEntityKeyConverter<IncassoMandaadId>())
            .IsRequired(false);

        builder.HasMany(l => l.Notities)
            .WithOne()
            .HasForeignKey(n => n.LidId);

        builder.OwnsOne(l => l.AuditInfo, builder =>
        {
            builder.Property(ai => ai.CreatedBy).HasColumnName("Creator").IsRequired(false).HasMaxLength(60);
            builder.Property(ai => ai.CreatedOnUtc).HasColumnName("CreatedUtc").HasConversion(ValueConverters.UtcValueConverter).IsRequired(true);
            builder.Property(ai => ai.LastModifiedBy).HasColumnName("LastModifiedBy").IsRequired(false).HasMaxLength(60);
            builder.Property(ai => ai.ModifiedOnUtc).HasColumnName("ModifiedUtc").HasConversion(ValueConverters.UtcValueConverter).IsRequired(false);
        });

        builder.OwnsOne(l => l.DeletionInfo, builder =>
        {
            builder.Property(di => di.IsDeleted).HasColumnName("IsDeleted").IsRequired(true);
            builder.Property(di => di.DeletedBy).HasColumnName("DeletedBy").IsRequired(false).HasMaxLength(60);
            builder.Property(di => di.DeletedOnUtc).HasColumnName("DeletedUtc").HasConversion(ValueConverters.UtcValueConverter).IsRequired(false);
        });
    }
}
