using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations
{
    /// <inheritdoc />
    public partial class DodanieOczekujace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UbezpieczenieId",
                table: "Wypozyczenia",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Oczekujace",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WypozyczenieId = table.Column<int>(type: "int", nullable: false),
                    DoKiedy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Zaakceptowane = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oczekujace", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oczekujace_Wypozyczenia_WypozyczenieId",
                        column: x => x.WypozyczenieId,
                        principalTable: "Wypozyczenia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wypozyczenia_UbezpieczenieId",
                table: "Wypozyczenia",
                column: "UbezpieczenieId");

            migrationBuilder.CreateIndex(
                name: "IX_Oczekujace_WypozyczenieId",
                table: "Oczekujace",
                column: "WypozyczenieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wypozyczenia_Ubezpieczenia_UbezpieczenieId",
                table: "Wypozyczenia",
                column: "UbezpieczenieId",
                principalTable: "Ubezpieczenia",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wypozyczenia_Ubezpieczenia_UbezpieczenieId",
                table: "Wypozyczenia");

            migrationBuilder.DropTable(
                name: "Oczekujace");

            migrationBuilder.DropIndex(
                name: "IX_Wypozyczenia_UbezpieczenieId",
                table: "Wypozyczenia");

            migrationBuilder.DropColumn(
                name: "UbezpieczenieId",
                table: "Wypozyczenia");
        }
    }
}
