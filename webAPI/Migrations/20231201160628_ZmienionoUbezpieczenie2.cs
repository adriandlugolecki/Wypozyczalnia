using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations
{
    /// <inheritdoc />
    public partial class ZmienionoUbezpieczenie2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Kradziez",
                table: "Ubezpieczenia",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UszkodzenieOpony",
                table: "Ubezpieczenia",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UszkodzeniePojazdu",
                table: "Ubezpieczenia",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UszkodzenieSzyby",
                table: "Ubezpieczenia",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kradziez",
                table: "Ubezpieczenia");

            migrationBuilder.DropColumn(
                name: "UszkodzenieOpony",
                table: "Ubezpieczenia");

            migrationBuilder.DropColumn(
                name: "UszkodzeniePojazdu",
                table: "Ubezpieczenia");

            migrationBuilder.DropColumn(
                name: "UszkodzenieSzyby",
                table: "Ubezpieczenia");
        }
    }
}
