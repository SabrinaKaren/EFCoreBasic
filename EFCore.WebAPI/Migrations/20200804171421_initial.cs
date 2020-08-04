using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.WebAPI.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "batalhas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    descricao = table.Column<string>(nullable: true),
                    dtInicio = table.Column<DateTime>(nullable: false),
                    dtFim = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_batalhas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "herois",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    batalhaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_herois", x => x.id);
                    table.ForeignKey(
                        name: "FK_herois_batalhas_batalhaId",
                        column: x => x.batalhaId,
                        principalTable: "batalhas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "armas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    heroiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_armas", x => x.id);
                    table.ForeignKey(
                        name: "FK_armas_herois_heroiId",
                        column: x => x.heroiId,
                        principalTable: "herois",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_armas_heroiId",
                table: "armas",
                column: "heroiId");

            migrationBuilder.CreateIndex(
                name: "IX_herois_batalhaId",
                table: "herois",
                column: "batalhaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "armas");

            migrationBuilder.DropTable(
                name: "herois");

            migrationBuilder.DropTable(
                name: "batalhas");
        }
    }
}
