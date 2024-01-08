using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations
{
    /// <inheritdoc />
    public partial class dodanoKierowcę : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adres",
                table: "Wypozyczenia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imie",
                table: "Wypozyczenia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KodPocztowy",
                table: "Wypozyczenia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Miejscowosc",
                table: "Wypozyczenia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nazwisko",
                table: "Wypozyczenia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefon",
                table: "Wypozyczenia",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adres",
                table: "Wypozyczenia");

            migrationBuilder.DropColumn(
                name: "Imie",
                table: "Wypozyczenia");

            migrationBuilder.DropColumn(
                name: "KodPocztowy",
                table: "Wypozyczenia");

            migrationBuilder.DropColumn(
                name: "Miejscowosc",
                table: "Wypozyczenia");

            migrationBuilder.DropColumn(
                name: "Nazwisko",
                table: "Wypozyczenia");

            migrationBuilder.DropColumn(
                name: "Telefon",
                table: "Wypozyczenia");
        }
    }
}
