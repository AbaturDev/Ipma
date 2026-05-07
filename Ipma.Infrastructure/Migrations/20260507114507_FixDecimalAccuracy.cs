using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ipma.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixDecimalAccuracy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OcenyWstępne_Projekty_ProjektId",
                table: "OcenyWstępne");

            migrationBuilder.DropTable(
                name: "OcenyIndywidualne");

            migrationBuilder.DropTable(
                name: "OcenyKońcowe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OcenyWstępne",
                table: "OcenyWstępne");

            migrationBuilder.DropIndex(
                name: "IX_OcenyWstępne_ProjektId",
                table: "OcenyWstępne");

            migrationBuilder.RenameTable(
                name: "OcenyWstępne",
                newName: "OcenaProjektu");

            migrationBuilder.AlterColumn<decimal>(
                name: "SkonsolidowanyWynikPunktowy",
                table: "OcenaProjektu",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjektId",
                table: "OcenaProjektu",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<bool>(
                name: "CzyOsiągniętoKonsensus",
                table: "OcenaProjektu",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<Guid>(
                name: "AsesorId",
                table: "OcenaProjektu",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CzyZatwierdzona",
                table: "OcenaProjektu",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "OcenaProjektu",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "OcenaKońcowa_ProjektId",
                table: "OcenaProjektu",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OcenaWstępna_ProjektId",
                table: "OcenaProjektu",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OstatecznaNotaPunktowa",
                table: "OcenaProjektu",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RekomendacjaFinałowa",
                table: "OcenaProjektu",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OcenaProjektu",
                table: "OcenaProjektu",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OcenaProjektu_AsesorId",
                table: "OcenaProjektu",
                column: "AsesorId");

            migrationBuilder.CreateIndex(
                name: "IX_OcenaProjektu_OcenaKońcowa_ProjektId",
                table: "OcenaProjektu",
                column: "OcenaKońcowa_ProjektId",
                unique: true,
                filter: "[ProjektId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OcenaProjektu_OcenaWstępna_ProjektId",
                table: "OcenaProjektu",
                column: "OcenaWstępna_ProjektId",
                unique: true,
                filter: "[ProjektId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OcenaProjektu_ProjektId",
                table: "OcenaProjektu",
                column: "ProjektId");

            migrationBuilder.AddForeignKey(
                name: "FK_OcenaProjektu_KontoUżytkownika_AsesorId",
                table: "OcenaProjektu",
                column: "AsesorId",
                principalTable: "KontoUżytkownika",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OcenaProjektu_Projekty_OcenaKońcowa_ProjektId",
                table: "OcenaProjektu",
                column: "OcenaKońcowa_ProjektId",
                principalTable: "Projekty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OcenaProjektu_Projekty_OcenaWstępna_ProjektId",
                table: "OcenaProjektu",
                column: "OcenaWstępna_ProjektId",
                principalTable: "Projekty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OcenaProjektu_Projekty_ProjektId",
                table: "OcenaProjektu",
                column: "ProjektId",
                principalTable: "Projekty",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OcenaProjektu_KontoUżytkownika_AsesorId",
                table: "OcenaProjektu");

            migrationBuilder.DropForeignKey(
                name: "FK_OcenaProjektu_Projekty_OcenaKońcowa_ProjektId",
                table: "OcenaProjektu");

            migrationBuilder.DropForeignKey(
                name: "FK_OcenaProjektu_Projekty_OcenaWstępna_ProjektId",
                table: "OcenaProjektu");

            migrationBuilder.DropForeignKey(
                name: "FK_OcenaProjektu_Projekty_ProjektId",
                table: "OcenaProjektu");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OcenaProjektu",
                table: "OcenaProjektu");

            migrationBuilder.DropIndex(
                name: "IX_OcenaProjektu_AsesorId",
                table: "OcenaProjektu");

            migrationBuilder.DropIndex(
                name: "IX_OcenaProjektu_OcenaKońcowa_ProjektId",
                table: "OcenaProjektu");

            migrationBuilder.DropIndex(
                name: "IX_OcenaProjektu_OcenaWstępna_ProjektId",
                table: "OcenaProjektu");

            migrationBuilder.DropIndex(
                name: "IX_OcenaProjektu_ProjektId",
                table: "OcenaProjektu");

            migrationBuilder.DropColumn(
                name: "AsesorId",
                table: "OcenaProjektu");

            migrationBuilder.DropColumn(
                name: "CzyZatwierdzona",
                table: "OcenaProjektu");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "OcenaProjektu");

            migrationBuilder.DropColumn(
                name: "OcenaKońcowa_ProjektId",
                table: "OcenaProjektu");

            migrationBuilder.DropColumn(
                name: "OcenaWstępna_ProjektId",
                table: "OcenaProjektu");

            migrationBuilder.DropColumn(
                name: "OstatecznaNotaPunktowa",
                table: "OcenaProjektu");

            migrationBuilder.DropColumn(
                name: "RekomendacjaFinałowa",
                table: "OcenaProjektu");

            migrationBuilder.RenameTable(
                name: "OcenaProjektu",
                newName: "OcenyWstępne");

            migrationBuilder.AlterColumn<decimal>(
                name: "SkonsolidowanyWynikPunktowy",
                table: "OcenyWstępne",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProjektId",
                table: "OcenyWstępne",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "CzyOsiągniętoKonsensus",
                table: "OcenyWstępne",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OcenyWstępne",
                table: "OcenyWstępne",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "OcenyIndywidualne",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AsesorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjektId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CzyOcenaSpozniona = table.Column<bool>(type: "bit", nullable: false),
                    CzyZatwierdzona = table.Column<bool>(type: "bit", nullable: false),
                    PlanowanaDataOpracowania = table.Column<DateOnly>(type: "date", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UzasadnienieOceniajacego = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WynikObszarLudzieICel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WynikObszarProcesyIZasoby = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WynikObszarRezultaty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcenyIndywidualne", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OcenyIndywidualne_KontoUżytkownika_AsesorId",
                        column: x => x.AsesorId,
                        principalTable: "KontoUżytkownika",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OcenyIndywidualne_Projekty_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekty",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OcenyKońcowe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjektId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CzyOcenaSpozniona = table.Column<bool>(type: "bit", nullable: false),
                    OstatecznaNotaPunktowa = table.Column<double>(type: "float", nullable: false),
                    PlanowanaDataOpracowania = table.Column<DateOnly>(type: "date", nullable: false),
                    RekomendacjaFinałowa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UzasadnienieOceniajacego = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WynikObszarLudzieICel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WynikObszarProcesyIZasoby = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WynikObszarRezultaty = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OcenyKońcowe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OcenyKońcowe_Projekty_ProjektId",
                        column: x => x.ProjektId,
                        principalTable: "Projekty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OcenyWstępne_ProjektId",
                table: "OcenyWstępne",
                column: "ProjektId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OcenyIndywidualne_AsesorId",
                table: "OcenyIndywidualne",
                column: "AsesorId");

            migrationBuilder.CreateIndex(
                name: "IX_OcenyIndywidualne_ProjektId",
                table: "OcenyIndywidualne",
                column: "ProjektId");

            migrationBuilder.CreateIndex(
                name: "IX_OcenyKońcowe_ProjektId",
                table: "OcenyKońcowe",
                column: "ProjektId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OcenyWstępne_Projekty_ProjektId",
                table: "OcenyWstępne",
                column: "ProjektId",
                principalTable: "Projekty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
