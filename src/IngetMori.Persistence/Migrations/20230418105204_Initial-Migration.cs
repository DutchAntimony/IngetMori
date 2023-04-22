using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IngetMori.Persistence.Migrations;

/// <inheritdoc />
public partial class InitialMigration : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Familie",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                AanspreekNaam = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                Adres_Straat = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                Adres_Huisnummer = table.Column<int>(type: "INTEGER", nullable: false),
                Adres_Toevoegsel = table.Column<string>(type: "TEXT", maxLength: 6, nullable: true),
                Adres_Postcode = table.Column<string>(type: "TEXT", maxLength: 8, nullable: false),
                Adres_Woonplaats = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                Adres_Land = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true),
                Creator = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                CreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                LastModifiedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                ModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                DeletedUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                DeletedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true)
            },
            constraints: table 
            => table.PrimaryKey("PK_Familie", x => x.Id));

        migrationBuilder.CreateTable(
            name: "IncassoMandaad",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                Iban = table.Column<string>(type: "TEXT", maxLength: 24, nullable: false),
                Bic = table.Column<string>(type: "TEXT", maxLength: 9, nullable: true),
                Iban_TenNameVan = table.Column<string>(type: "TEXT", nullable: false),
                MandaadType = table.Column<int>(type: "INTEGER", nullable: true),
                MandaadDatum = table.Column<DateTime>(type: "TEXT", nullable: true)
            },
            constraints: table 
            => table.PrimaryKey("PK_IncassoMandaad", x => x.Id));

        migrationBuilder.CreateTable(
            name: "Lid",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                Lidnummer = table.Column<int>(type: "INTEGER", nullable: false),
                Personalia_Voornaam = table.Column<string>(type: "TEXT", nullable: false),
                Personalia_Tussenvoegsel = table.Column<string>(type: "TEXT", nullable: true),
                Personalia_Achternaam = table.Column<string>(type: "TEXT", nullable: false),
                Personalia_Geslacht = table.Column<int>(type: "INTEGER", nullable: false),
                Personalia_Geboortedatum = table.Column<DateTime>(type: "TEXT", nullable: false),
                FamilieId = table.Column<Guid>(type: "TEXT", nullable: false),
                Betaalwijze = table.Column<int>(type: "INTEGER", nullable: false),
                IncassoMandaadId = table.Column<Guid>(type: "TEXT", nullable: true),
                Uitschrijfreden = table.Column<int>(type: "INTEGER", nullable: true),
                Creator = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                CreatedUtc = table.Column<DateTime>(type: "TEXT", nullable: false),
                LastModifiedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                ModifiedUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                DeletedUtc = table.Column<DateTime>(type: "TEXT", nullable: true),
                DeletedBy = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Lid", x => x.Id);
                table.ForeignKey(
                    name: "FK_Lid_Familie_FamilieId",
                    column: x => x.FamilieId,
                    principalTable: "Familie",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Lid_IncassoMandaad_IncassoMandaadId",
                    column: x => x.IncassoMandaadId,
                    principalTable: "IncassoMandaad",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "EmailAdres",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                LidId = table.Column<Guid>(type: "TEXT", nullable: false),
                Value = table.Column<string>(type: "TEXT", maxLength: 255, nullable: false),
                MagPostVervangen = table.Column<bool>(type: "INTEGER", nullable: false),
                Volgnummer = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_EmailAdres", x => x.Id);
                table.ForeignKey(
                    name: "FK_EmailAdres_Lid_LidId",
                    column: x => x.LidId,
                    principalTable: "Lid",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "Notitie",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                Discriminator = table.Column<int>(type: "INTEGER", nullable: false),
                FamilieId = table.Column<Guid>(type: "TEXT", nullable: false),
                LidId = table.Column<Guid>(type: "TEXT", nullable: true),
                Value = table.Column<string>(type: "TEXT", nullable: true),
                Volgnummer = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Notitie", x => x.Id);
                table.ForeignKey(
                    name: "FK_Notitie_Familie_FamilieId",
                    column: x => x.FamilieId,
                    principalTable: "Familie",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Notitie_Lid_LidId",
                    column: x => x.LidId,
                    principalTable: "Lid",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "TelefoonNummer",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "TEXT", nullable: false),
                LidId = table.Column<Guid>(type: "TEXT", nullable: false),
                Nummer = table.Column<string>(type: "TEXT", maxLength: 24, nullable: false),
                Omschrijving = table.Column<string>(type: "TEXT", nullable: false),
                Volgnummer = table.Column<int>(type: "INTEGER", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TelefoonNummer", x => x.Id);
                table.ForeignKey(
                    name: "FK_TelefoonNummer_Lid_LidId",
                    column: x => x.LidId,
                    principalTable: "Lid",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_EmailAdres_LidId",
            table: "EmailAdres",
            column: "LidId");

        migrationBuilder.CreateIndex(
            name: "IX_Lid_FamilieId",
            table: "Lid",
            column: "FamilieId");

        migrationBuilder.CreateIndex(
            name: "IX_Lid_IncassoMandaadId",
            table: "Lid",
            column: "IncassoMandaadId");

        migrationBuilder.CreateIndex(
            name: "IX_Notitie_FamilieId",
            table: "Notitie",
            column: "FamilieId");

        migrationBuilder.CreateIndex(
            name: "IX_Notitie_LidId",
            table: "Notitie",
            column: "LidId");

        migrationBuilder.CreateIndex(
            name: "IX_TelefoonNummer_LidId",
            table: "TelefoonNummer",
            column: "LidId");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "EmailAdres");

        migrationBuilder.DropTable(
            name: "Notitie");

        migrationBuilder.DropTable(
            name: "TelefoonNummer");

        migrationBuilder.DropTable(
            name: "Lid");

        migrationBuilder.DropTable(
            name: "Familie");

        migrationBuilder.DropTable(
            name: "IncassoMandaad");
    }
}
