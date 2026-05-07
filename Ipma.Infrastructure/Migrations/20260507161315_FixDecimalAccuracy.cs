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
                name: "FK_Projekty_KontoUżytkownika_AplikantId",
                table: "Projekty");

            migrationBuilder.AddForeignKey(
                name: "FK_Projekty_KontoUżytkownika_AplikantId",
                table: "Projekty",
                column: "AplikantId",
                principalTable: "KontoUżytkownika",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projekty_KontoUżytkownika_AplikantId",
                table: "Projekty");

            migrationBuilder.AddForeignKey(
                name: "FK_Projekty_KontoUżytkownika_AplikantId",
                table: "Projekty",
                column: "AplikantId",
                principalTable: "KontoUżytkownika",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
