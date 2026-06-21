using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ipma.Migrations
{
    /// <inheritdoc />
    public partial class UpdateKontoUzytkownika : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aplikant_KontoUżytkownika_Id",
                table: "Aplikant");

            migrationBuilder.DropForeignKey(
                name: "FK_Asesor_KontoUżytkownika_Id",
                table: "Asesor");

            migrationBuilder.DropForeignKey(
                name: "FK_CzlonekJury_KontoUżytkownika_Id",
                table: "CzlonekJury");

            migrationBuilder.DropForeignKey(
                name: "FK_Projekty_Aplikant_AplikantId",
                table: "Projekty");

            migrationBuilder.DropForeignKey(
                name: "FK_Projekty_KontoUżytkownika_UtworzonyPrzezId",
                table: "Projekty");

            migrationBuilder.DropForeignKey(
                name: "FK_Projekty_KontoUżytkownika_ZmodyfikowanyPrzezId",
                table: "Projekty");

            migrationBuilder.DropForeignKey(
                name: "FK_PrzedstawicielBiuraNagrody_KontoUżytkownika_Id",
                table: "PrzedstawicielBiuraNagrody");

            migrationBuilder.DropForeignKey(
                name: "FK_RaportyAplikacyjne_KontoUżytkownika_UtworzonyPrzezId",
                table: "RaportyAplikacyjne");

            migrationBuilder.DropForeignKey(
                name: "FK_RaportyAplikacyjne_KontoUżytkownika_ZmodyfikowanyPrzezId",
                table: "RaportyAplikacyjne");

            migrationBuilder.DropForeignKey(
                name: "FK_RaportyZWizyty_KontoUżytkownika_UtworzonyPrzezId",
                table: "RaportyZWizyty");

            migrationBuilder.DropForeignKey(
                name: "FK_RaportyZWizyty_KontoUżytkownika_ZmodyfikowanyPrzezId",
                table: "RaportyZWizyty");

            migrationBuilder.DropForeignKey(
                name: "FK_WnioskiAplikacyjne_KontoUżytkownika_UtworzonyPrzezId",
                table: "WnioskiAplikacyjne");

            migrationBuilder.DropForeignKey(
                name: "FK_WnioskiAplikacyjne_KontoUżytkownika_ZmodyfikowanyPrzezId",
                table: "WnioskiAplikacyjne");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KontoUżytkownika",
                table: "KontoUżytkownika");

            migrationBuilder.DropColumn(
                name: "Rola",
                table: "KontoUżytkownika");

            migrationBuilder.DropColumn(
                name: "StatusKonta",
                table: "KontoUżytkownika");

            migrationBuilder.RenameTable(
                name: "KontoUżytkownika",
                newName: "Użytkownicy");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Użytkownicy",
                table: "Użytkownicy",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aplikant_Użytkownicy_Id",
                table: "Aplikant",
                column: "Id",
                principalTable: "Użytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asesor_Użytkownicy_Id",
                table: "Asesor",
                column: "Id",
                principalTable: "Użytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CzlonekJury_Użytkownicy_Id",
                table: "CzlonekJury",
                column: "Id",
                principalTable: "Użytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projekty_Aplikant_AplikantId",
                table: "Projekty",
                column: "AplikantId",
                principalTable: "Aplikant",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Projekty_Użytkownicy_UtworzonyPrzezId",
                table: "Projekty",
                column: "UtworzonyPrzezId",
                principalTable: "Użytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projekty_Użytkownicy_ZmodyfikowanyPrzezId",
                table: "Projekty",
                column: "ZmodyfikowanyPrzezId",
                principalTable: "Użytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrzedstawicielBiuraNagrody_Użytkownicy_Id",
                table: "PrzedstawicielBiuraNagrody",
                column: "Id",
                principalTable: "Użytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RaportyAplikacyjne_Użytkownicy_UtworzonyPrzezId",
                table: "RaportyAplikacyjne",
                column: "UtworzonyPrzezId",
                principalTable: "Użytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaportyAplikacyjne_Użytkownicy_ZmodyfikowanyPrzezId",
                table: "RaportyAplikacyjne",
                column: "ZmodyfikowanyPrzezId",
                principalTable: "Użytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaportyZWizyty_Użytkownicy_UtworzonyPrzezId",
                table: "RaportyZWizyty",
                column: "UtworzonyPrzezId",
                principalTable: "Użytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaportyZWizyty_Użytkownicy_ZmodyfikowanyPrzezId",
                table: "RaportyZWizyty",
                column: "ZmodyfikowanyPrzezId",
                principalTable: "Użytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WnioskiAplikacyjne_Użytkownicy_UtworzonyPrzezId",
                table: "WnioskiAplikacyjne",
                column: "UtworzonyPrzezId",
                principalTable: "Użytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WnioskiAplikacyjne_Użytkownicy_ZmodyfikowanyPrzezId",
                table: "WnioskiAplikacyjne",
                column: "ZmodyfikowanyPrzezId",
                principalTable: "Użytkownicy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aplikant_Użytkownicy_Id",
                table: "Aplikant");

            migrationBuilder.DropForeignKey(
                name: "FK_Asesor_Użytkownicy_Id",
                table: "Asesor");

            migrationBuilder.DropForeignKey(
                name: "FK_CzlonekJury_Użytkownicy_Id",
                table: "CzlonekJury");

            migrationBuilder.DropForeignKey(
                name: "FK_Projekty_Aplikant_AplikantId",
                table: "Projekty");

            migrationBuilder.DropForeignKey(
                name: "FK_Projekty_Użytkownicy_UtworzonyPrzezId",
                table: "Projekty");

            migrationBuilder.DropForeignKey(
                name: "FK_Projekty_Użytkownicy_ZmodyfikowanyPrzezId",
                table: "Projekty");

            migrationBuilder.DropForeignKey(
                name: "FK_PrzedstawicielBiuraNagrody_Użytkownicy_Id",
                table: "PrzedstawicielBiuraNagrody");

            migrationBuilder.DropForeignKey(
                name: "FK_RaportyAplikacyjne_Użytkownicy_UtworzonyPrzezId",
                table: "RaportyAplikacyjne");

            migrationBuilder.DropForeignKey(
                name: "FK_RaportyAplikacyjne_Użytkownicy_ZmodyfikowanyPrzezId",
                table: "RaportyAplikacyjne");

            migrationBuilder.DropForeignKey(
                name: "FK_RaportyZWizyty_Użytkownicy_UtworzonyPrzezId",
                table: "RaportyZWizyty");

            migrationBuilder.DropForeignKey(
                name: "FK_RaportyZWizyty_Użytkownicy_ZmodyfikowanyPrzezId",
                table: "RaportyZWizyty");

            migrationBuilder.DropForeignKey(
                name: "FK_WnioskiAplikacyjne_Użytkownicy_UtworzonyPrzezId",
                table: "WnioskiAplikacyjne");

            migrationBuilder.DropForeignKey(
                name: "FK_WnioskiAplikacyjne_Użytkownicy_ZmodyfikowanyPrzezId",
                table: "WnioskiAplikacyjne");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Użytkownicy",
                table: "Użytkownicy");

            migrationBuilder.RenameTable(
                name: "Użytkownicy",
                newName: "KontoUżytkownika");

            migrationBuilder.AddColumn<int>(
                name: "Rola",
                table: "KontoUżytkownika",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "StatusKonta",
                table: "KontoUżytkownika",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_KontoUżytkownika",
                table: "KontoUżytkownika",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aplikant_KontoUżytkownika_Id",
                table: "Aplikant",
                column: "Id",
                principalTable: "KontoUżytkownika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Asesor_KontoUżytkownika_Id",
                table: "Asesor",
                column: "Id",
                principalTable: "KontoUżytkownika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CzlonekJury_KontoUżytkownika_Id",
                table: "CzlonekJury",
                column: "Id",
                principalTable: "KontoUżytkownika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projekty_Aplikant_AplikantId",
                table: "Projekty",
                column: "AplikantId",
                principalTable: "Aplikant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Projekty_KontoUżytkownika_UtworzonyPrzezId",
                table: "Projekty",
                column: "UtworzonyPrzezId",
                principalTable: "KontoUżytkownika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projekty_KontoUżytkownika_ZmodyfikowanyPrzezId",
                table: "Projekty",
                column: "ZmodyfikowanyPrzezId",
                principalTable: "KontoUżytkownika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrzedstawicielBiuraNagrody_KontoUżytkownika_Id",
                table: "PrzedstawicielBiuraNagrody",
                column: "Id",
                principalTable: "KontoUżytkownika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RaportyAplikacyjne_KontoUżytkownika_UtworzonyPrzezId",
                table: "RaportyAplikacyjne",
                column: "UtworzonyPrzezId",
                principalTable: "KontoUżytkownika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaportyAplikacyjne_KontoUżytkownika_ZmodyfikowanyPrzezId",
                table: "RaportyAplikacyjne",
                column: "ZmodyfikowanyPrzezId",
                principalTable: "KontoUżytkownika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaportyZWizyty_KontoUżytkownika_UtworzonyPrzezId",
                table: "RaportyZWizyty",
                column: "UtworzonyPrzezId",
                principalTable: "KontoUżytkownika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaportyZWizyty_KontoUżytkownika_ZmodyfikowanyPrzezId",
                table: "RaportyZWizyty",
                column: "ZmodyfikowanyPrzezId",
                principalTable: "KontoUżytkownika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WnioskiAplikacyjne_KontoUżytkownika_UtworzonyPrzezId",
                table: "WnioskiAplikacyjne",
                column: "UtworzonyPrzezId",
                principalTable: "KontoUżytkownika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WnioskiAplikacyjne_KontoUżytkownika_ZmodyfikowanyPrzezId",
                table: "WnioskiAplikacyjne",
                column: "ZmodyfikowanyPrzezId",
                principalTable: "KontoUżytkownika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
