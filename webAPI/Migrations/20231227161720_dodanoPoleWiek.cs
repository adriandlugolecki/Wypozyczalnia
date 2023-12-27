using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations
{
    /// <inheritdoc />
    public partial class dodanoPoleWiek : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "kwota",
                table: "Wypozyczenia",
                newName: "Kwota");

            migrationBuilder.AddColumn<int>(
                name: "Wiek",
                table: "Wypozyczenia",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Wiek",
                table: "Wypozyczenia");

            migrationBuilder.RenameColumn(
                name: "Kwota",
                table: "Wypozyczenia",
                newName: "kwota");
        }
    }
}
