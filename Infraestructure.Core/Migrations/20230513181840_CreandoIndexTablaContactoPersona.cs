using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class CreandoIndexTablaContactoPersona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactoPersona_IdTipoContacto",
                table: "ContactoPersona");

            migrationBuilder.CreateIndex(
                name: "IX_ContactoPersona_IdTipoContacto_IdPersona",
                table: "ContactoPersona",
                columns: new[] { "IdTipoContacto", "IdPersona" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactoPersona_IdTipoContacto_IdPersona",
                table: "ContactoPersona");

            migrationBuilder.CreateIndex(
                name: "IX_ContactoPersona_IdTipoContacto",
                table: "ContactoPersona",
                column: "IdTipoContacto");
        }
    }
}
