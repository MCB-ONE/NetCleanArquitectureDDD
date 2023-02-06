using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameOfFoodies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PuntuacionMediaValor = table.Column<double>(name: "PuntuacionMedia_Valor", type: "float", nullable: false),
                    PuntuacionMediaNumPuntuaciones = table.Column<int>(name: "PuntuacionMedia_NumPuntuaciones", type: "int", nullable: false),
                    HuespedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreadoFechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoFechaHora = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuCenaIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuCenaIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuCenaIds_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuResenaIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResenaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuResenaIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuResenaIds_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeccionesMenu",
                columns: table => new
                {
                    SeccionMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeccionesMenu", x => new { x.SeccionMenuId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_SeccionesMenu_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlatosMenu",
                columns: table => new
                {
                    PlatoMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SeccionMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlatosMenu", x => new { x.PlatoMenuId, x.SeccionMenuId, x.MenuId });
                    table.ForeignKey(
                        name: "FK_PlatosMenu_SeccionesMenu_SeccionMenuId_MenuId",
                        columns: x => new { x.SeccionMenuId, x.MenuId },
                        principalTable: "SeccionesMenu",
                        principalColumns: new[] { "SeccionMenuId", "MenuId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuCenaIds_MenuId",
                table: "MenuCenaIds",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuResenaIds_MenuId",
                table: "MenuResenaIds",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_PlatosMenu_SeccionMenuId_MenuId",
                table: "PlatosMenu",
                columns: new[] { "SeccionMenuId", "MenuId" });

            migrationBuilder.CreateIndex(
                name: "IX_SeccionesMenu_MenuId",
                table: "SeccionesMenu",
                column: "MenuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuCenaIds");

            migrationBuilder.DropTable(
                name: "MenuResenaIds");

            migrationBuilder.DropTable(
                name: "PlatosMenu");

            migrationBuilder.DropTable(
                name: "SeccionesMenu");

            migrationBuilder.DropTable(
                name: "Menus");
        }
    }
}
