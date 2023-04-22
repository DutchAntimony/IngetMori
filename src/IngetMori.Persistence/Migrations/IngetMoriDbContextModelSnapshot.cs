﻿// <auto-generated />
using System;
using IngetMori.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IngetMori.Persistence.Migrations;

[DbContext(typeof(IngetMoriDbContext))]
partial class IngetMoriDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

        modelBuilder.Entity("IngetMori.Domain.FamilieRoot.EmailAdres", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("TEXT");

                b.Property<Guid>("LidId")
                    .HasColumnType("TEXT");

                b.Property<bool>("MagPostVervangen")
                    .HasColumnType("INTEGER");

                b.Property<string>("Value")
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnType("TEXT");

                b.Property<int>("Volgnummer")
                    .HasColumnType("INTEGER");

                b.HasKey("Id");

                b.HasIndex("LidId");

                b.ToTable("EmailAdres", (string)null);
            });

        modelBuilder.Entity("IngetMori.Domain.FamilieRoot.Familie", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("TEXT");

                b.Property<string>("AanspreekNaam")
                    .HasMaxLength(60)
                    .HasColumnType("TEXT");

                b.HasKey("Id");

                b.ToTable("Familie", (string)null);
            });

        modelBuilder.Entity("IngetMori.Domain.FamilieRoot.Lid", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("TEXT");

                b.Property<int>("Betaalwijze")
                    .HasColumnType("INTEGER");

                b.Property<Guid>("FamilieId")
                    .HasColumnType("TEXT");

                b.Property<Guid?>("IncassoMandaadId")
                    .HasColumnType("TEXT");

                b.Property<int>("Lidnummer")
                    .HasColumnType("INTEGER");

                b.Property<int?>("Uitschrijfreden")
                    .HasColumnType("INTEGER");

                b.HasKey("Id");

                b.HasIndex("FamilieId");

                b.HasIndex("IncassoMandaadId");

                b.ToTable("Lid", (string)null);
            });

        modelBuilder.Entity("IngetMori.Domain.FamilieRoot.Notitie", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("TEXT");

                b.Property<int>("Discriminator")
                    .HasColumnType("INTEGER");

                b.Property<Guid>("FamilieId")
                    .HasColumnType("TEXT");

                b.Property<Guid?>("LidId")
                    .HasColumnType("TEXT");

                b.Property<string>("Value")
                    .HasColumnType("TEXT");

                b.Property<int>("Volgnummer")
                    .HasColumnType("INTEGER");

                b.HasKey("Id");

                b.HasIndex("FamilieId");

                b.HasIndex("LidId");

                b.ToTable("Notitie", (string)null);
            });

        modelBuilder.Entity("IngetMori.Domain.FamilieRoot.TelefoonNummer", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("TEXT");

                b.Property<Guid>("LidId")
                    .HasColumnType("TEXT");

                b.Property<string>("Nummer")
                    .IsRequired()
                    .HasMaxLength(24)
                    .HasColumnType("TEXT");

                b.Property<string>("Omschrijving")
                    .IsRequired()
                    .HasColumnType("TEXT");

                b.Property<int>("Volgnummer")
                    .HasColumnType("INTEGER");

                b.HasKey("Id");

                b.HasIndex("LidId");

                b.ToTable("TelefoonNummer", (string)null);
            });

        modelBuilder.Entity("IngetMori.Domain.IncassoMandaadRoot.IncassoMandaad", b =>
            {
                b.Property<Guid>("Id")
                    .HasColumnType("TEXT");

                b.Property<DateTime?>("MandaadDatum")
                    .HasColumnType("TEXT");

                b.Property<int?>("MandaadType")
                    .HasColumnType("INTEGER");

                b.HasKey("Id");

                b.ToTable("IncassoMandaad", (string)null);
            });

        modelBuilder.Entity("IngetMori.Domain.FamilieRoot.EmailAdres", b =>
            {
                b.HasOne("IngetMori.Domain.FamilieRoot.Lid", null)
                    .WithMany("EmailAdressen")
                    .HasForeignKey("LidId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

        modelBuilder.Entity("IngetMori.Domain.FamilieRoot.Familie", b =>
            {
                b.OwnsOne("IngetMori.Domain.Core.ValueObjects.Adres", "Adres", b1 =>
                    {
                        b1.Property<Guid>("FamilieId")
                            .HasColumnType("TEXT");

                        b1.Property<int>("Huisnummer")
                            .HasColumnType("INTEGER");

                        b1.Property<string>("Land")
                            .HasMaxLength(3)
                            .HasColumnType("TEXT");

                        b1.Property<string>("Postcode")
                            .IsRequired()
                            .HasMaxLength(8)
                            .HasColumnType("TEXT");

                        b1.Property<string>("Straat")
                            .IsRequired()
                            .HasMaxLength(60)
                            .HasColumnType("TEXT");

                        b1.Property<string>("Toevoegsel")
                            .HasMaxLength(6)
                            .HasColumnType("TEXT");

                        b1.Property<string>("Woonplaats")
                            .IsRequired()
                            .HasMaxLength(60)
                            .HasColumnType("TEXT");

                        b1.HasKey("FamilieId");

                        b1.ToTable("Familie");

                        b1.WithOwner()
                            .HasForeignKey("FamilieId");
                    });

                b.OwnsOne("IngetMori.Domain.Common.Primitives.AuditInfo", "AuditInfo", b1 =>
                    {
                        b1.Property<Guid>("FamilieId")
                            .HasColumnType("TEXT");

                        b1.Property<string>("CreatedBy")
                            .HasMaxLength(60)
                            .HasColumnType("TEXT")
                            .HasColumnName("Creator");

                        b1.Property<DateTime>("CreatedOnUtc")
                            .HasColumnType("TEXT")
                            .HasColumnName("CreatedUtc");

                        b1.Property<string>("LastModifiedBy")
                            .HasMaxLength(60)
                            .HasColumnType("TEXT")
                            .HasColumnName("LastModifiedBy");

                        b1.Property<DateTime?>("ModifiedOnUtc")
                            .HasColumnType("TEXT")
                            .HasColumnName("ModifiedUtc");

                        b1.HasKey("FamilieId");

                        b1.ToTable("Familie");

                        b1.WithOwner()
                            .HasForeignKey("FamilieId");
                    });

                b.OwnsOne("IngetMori.Domain.Common.Primitives.DeletionInfo", "DeletionInfo", b1 =>
                    {
                        b1.Property<Guid>("FamilieId")
                            .HasColumnType("TEXT");

                        b1.Property<string>("DeletedBy")
                            .HasMaxLength(60)
                            .HasColumnType("TEXT")
                            .HasColumnName("DeletedBy");

                        b1.Property<DateTime?>("DeletedOnUtc")
                            .HasColumnType("TEXT")
                            .HasColumnName("DeletedUtc");

                        b1.Property<bool>("IsDeleted")
                            .HasColumnType("INTEGER")
                            .HasColumnName("IsDeleted");

                        b1.HasKey("FamilieId");

                        b1.ToTable("Familie");

                        b1.WithOwner()
                            .HasForeignKey("FamilieId");
                    });

                b.Navigation("Adres")
                    .IsRequired();

                b.Navigation("AuditInfo")
                    .IsRequired();

                b.Navigation("DeletionInfo")
                    .IsRequired();
            });

        modelBuilder.Entity("IngetMori.Domain.FamilieRoot.Lid", b =>
            {
                b.HasOne("IngetMori.Domain.FamilieRoot.Familie", null)
                    .WithMany("Leden")
                    .HasForeignKey("FamilieId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("IngetMori.Domain.IncassoMandaadRoot.IncassoMandaad", null)
                    .WithMany("Leden")
                    .HasForeignKey("IncassoMandaadId");

                b.OwnsOne("IngetMori.Domain.Core.ValueObjects.Personalia", "Personalia", b1 =>
                    {
                        b1.Property<Guid>("LidId")
                            .HasColumnType("TEXT");

                        b1.Property<string>("Achternaam")
                            .IsRequired()
                            .HasColumnType("TEXT");

                        b1.Property<DateTime>("Geboortedatum")
                            .HasColumnType("TEXT");

                        b1.Property<int>("Geslacht")
                            .HasColumnType("INTEGER");

                        b1.Property<string>("Tussenvoegsel")
                            .HasColumnType("TEXT");

                        b1.Property<string>("Voornaam")
                            .IsRequired()
                            .HasColumnType("TEXT");

                        b1.HasKey("LidId");

                        b1.ToTable("Lid");

                        b1.WithOwner()
                            .HasForeignKey("LidId");
                    });

                b.OwnsOne("IngetMori.Domain.Common.Primitives.AuditInfo", "AuditInfo", b1 =>
                    {
                        b1.Property<Guid>("LidId")
                            .HasColumnType("TEXT");

                        b1.Property<string>("CreatedBy")
                            .HasMaxLength(60)
                            .HasColumnType("TEXT")
                            .HasColumnName("Creator");

                        b1.Property<DateTime>("CreatedOnUtc")
                            .HasColumnType("TEXT")
                            .HasColumnName("CreatedUtc");

                        b1.Property<string>("LastModifiedBy")
                            .HasMaxLength(60)
                            .HasColumnType("TEXT")
                            .HasColumnName("LastModifiedBy");

                        b1.Property<DateTime?>("ModifiedOnUtc")
                            .HasColumnType("TEXT")
                            .HasColumnName("ModifiedUtc");

                        b1.HasKey("LidId");

                        b1.ToTable("Lid");

                        b1.WithOwner()
                            .HasForeignKey("LidId");
                    });

                b.OwnsOne("IngetMori.Domain.Common.Primitives.DeletionInfo", "DeletionInfo", b1 =>
                    {
                        b1.Property<Guid>("LidId")
                            .HasColumnType("TEXT");

                        b1.Property<string>("DeletedBy")
                            .HasMaxLength(60)
                            .HasColumnType("TEXT")
                            .HasColumnName("DeletedBy");

                        b1.Property<DateTime?>("DeletedOnUtc")
                            .HasColumnType("TEXT")
                            .HasColumnName("DeletedUtc");

                        b1.Property<bool>("IsDeleted")
                            .HasColumnType("INTEGER")
                            .HasColumnName("IsDeleted");

                        b1.HasKey("LidId");

                        b1.ToTable("Lid");

                        b1.WithOwner()
                            .HasForeignKey("LidId");
                    });

                b.Navigation("AuditInfo")
                    .IsRequired();

                b.Navigation("DeletionInfo")
                    .IsRequired();

                b.Navigation("Personalia")
                    .IsRequired();
            });

        modelBuilder.Entity("IngetMori.Domain.FamilieRoot.Notitie", b =>
            {
                b.HasOne("IngetMori.Domain.FamilieRoot.Familie", null)
                    .WithMany("Notities")
                    .HasForeignKey("FamilieId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("IngetMori.Domain.FamilieRoot.Lid", null)
                    .WithMany("Notities")
                    .HasForeignKey("LidId");
            });

        modelBuilder.Entity("IngetMori.Domain.FamilieRoot.TelefoonNummer", b =>
            {
                b.HasOne("IngetMori.Domain.FamilieRoot.Lid", null)
                    .WithMany("Telefoonnummers")
                    .HasForeignKey("LidId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

        modelBuilder.Entity("IngetMori.Domain.IncassoMandaadRoot.IncassoMandaad", b =>
            {
                b.OwnsOne("IngetMori.Domain.Core.ValueObjects.Iban", "Iban", b1 =>
                    {
                        b1.Property<Guid>("IncassoMandaadId")
                            .HasColumnType("TEXT");

                        b1.Property<string>("Bic")
                            .HasMaxLength(9)
                            .HasColumnType("TEXT")
                            .HasColumnName("Bic");

                        b1.Property<string>("Nummer")
                            .IsRequired()
                            .HasMaxLength(24)
                            .HasColumnType("TEXT")
                            .HasColumnName("Iban");

                        b1.Property<string>("TenNameVan")
                            .IsRequired()
                            .HasColumnType("TEXT");

                        b1.HasKey("IncassoMandaadId");

                        b1.ToTable("IncassoMandaad");

                        b1.WithOwner()
                            .HasForeignKey("IncassoMandaadId");
                    });

                b.Navigation("Iban")
                    .IsRequired();
            });

        modelBuilder.Entity("IngetMori.Domain.FamilieRoot.Familie", b =>
            {
                b.Navigation("Leden");

                b.Navigation("Notities");
            });

        modelBuilder.Entity("IngetMori.Domain.FamilieRoot.Lid", b =>
            {
                b.Navigation("EmailAdressen");

                b.Navigation("Notities");

                b.Navigation("Telefoonnummers");
            });

        modelBuilder.Entity("IngetMori.Domain.IncassoMandaadRoot.IncassoMandaad", b =>
            {
                b.Navigation("Leden");
            });
#pragma warning restore 612, 618
    }
}
