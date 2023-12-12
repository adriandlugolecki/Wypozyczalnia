using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations
{
    /// <inheritdoc />
    public partial class ZmienionoUbezpieczenie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "procent",
                table: "Ubezpieczenia");

            migrationBuilder.AddColumn<int>(
                name: "Kwota",
                table: "Ubezpieczenia",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kwota",
                table: "Ubezpieczenia");

            migrationBuilder.AddColumn<string>(
                name: "procent",
                table: "Ubezpieczenia",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
