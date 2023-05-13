using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Core.Migrations
{
    public partial class DropIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "Index_IdPersona",
                table: "ContactoPersona");

            migrationBuilder.DropIndex(
                name: "Index_IdTipoContacto",
                table: "ContactoPersona");

            migrationBuilder.CreateIndex(
                name: "IX_ContactoPersona_IdPersona",
                table: "ContactoPersona",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_ContactoPersona_IdTipoContacto",
                table: "ContactoPersona",
                column: "IdTipoContacto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ContactoPersona_IdPersona",
                table: "ContactoPersona");

            migrationBuilder.DropIndex(
                name: "IX_ContactoPersona_IdTipoContacto",
                table: "ContactoPersona");

            migrationBuilder.CreateIndex(
                name: "Index_IdPersona",
                table: "ContactoPersona",
                column: "IdPersona",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Index_IdTipoContacto",
                table: "ContactoPersona",
                column: "IdTipoContacto",
                unique: true);
        }
    }
}
