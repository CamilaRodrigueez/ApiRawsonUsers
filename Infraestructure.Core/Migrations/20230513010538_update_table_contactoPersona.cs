using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class update_table_contactoPersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactoPersona_IdPersona",
                table: "ContactoPersona");

            migrationBuilder.CreateIndex(
                name: "Index_IdPersona",
                table: "ContactoPersona",
                column: "IdPersona",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_IdPersona",
                table: "ContactoPersona");

            migrationBuilder.CreateIndex(
                name: "IX_ContactoPersona_IdPersona",
                table: "ContactoPersona",
                column: "IdPersona");
        }
    }
}
