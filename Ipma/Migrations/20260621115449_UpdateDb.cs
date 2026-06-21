using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ipma.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusDostępności",
                table: "EksperciIpma");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "EksperciIpma",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<bool>(
                name: "FlagaUprawnieńZarządczych",
                table: "Asesor",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "EksperciIpma");

            migrationBuilder.AddColumn<string>(
                name: "StatusDostępności",
                table: "EksperciIpma",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "FlagaUprawnieńZarządczych",
                table: "Asesor",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }
    }
}
