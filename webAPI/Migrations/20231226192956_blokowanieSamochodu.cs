using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations
{
    /// <inheritdoc />
    public partial class blokowanieSamochodu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CzyZablokowany",
                table: "Samochody",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CzyZablokowany",
                table: "Samochody");
        }
    }
}
