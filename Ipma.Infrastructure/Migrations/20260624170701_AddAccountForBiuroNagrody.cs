using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ipma.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountForBiuroNagrody : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BiuraNagrody");

            migrationBuilder.AddColumn<string>(
                name: "AdresEmail",
                table: "KontoUżytkownika",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdresKorespondencyjny",
                table: "KontoUżytkownika",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EdycjaKonkursuId",
                table: "KontoUżytkownika",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_KontoUżytkownika_EdycjaKonkursuId",
                table: "KontoUżytkownika",
                column: "EdycjaKonkursuId",
                unique: true,
                filter: "[EdycjaKonkursuId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_KontoUżytkownika_EdycjeKonkursu_EdycjaKonkursuId",
                table: "KontoUżytkownika",
                column: "EdycjaKonkursuId",
                principalTable: "EdycjeKonkursu",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KontoUżytkownika_EdycjeKonkursu_EdycjaKonkursuId",
                table: "KontoUżytkownika");

            migrationBuilder.DropIndex(
                name: "IX_KontoUżytkownika_EdycjaKonkursuId",
                table: "KontoUżytkownika");

            migrationBuilder.DropColumn(
                name: "AdresEmail",
                table: "KontoUżytkownika");

            migrationBuilder.DropColumn(
                name: "AdresKorespondencyjny",
                table: "KontoUżytkownika");

            migrationBuilder.DropColumn(
                name: "EdycjaKonkursuId",
                table: "KontoUżytkownika");

            migrationBuilder.CreateTable(
                name: "BiuraNagrody",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EdycjaKonkursuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AdresEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdresKorespondencyjny = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BiuraNagrody", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BiuraNagrody_EdycjeKonkursu_EdycjaKonkursuId",
                        column: x => x.EdycjaKonkursuId,
                        principalTable: "EdycjeKonkursu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BiuraNagrody_EdycjaKonkursuId",
                table: "BiuraNagrody",
                column: "EdycjaKonkursuId",
                unique: true);
        }
    }
}
