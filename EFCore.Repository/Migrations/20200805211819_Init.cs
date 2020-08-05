using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.Repository.Migrations
{
    public partial class Init : Migration
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
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_herois", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "HeroisBatalhas",
                columns: table => new
                {
                    heroiId = table.Column<int>(nullable: false),
                    batalhaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroisBatalhas", x => new { x.batalhaId, x.heroiId });
                    table.ForeignKey(
                        name: "FK_HeroisBatalhas_batalhas_batalhaId",
                        column: x => x.batalhaId,
                        principalTable: "batalhas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroisBatalhas_herois_heroiId",
                        column: x => x.heroiId,
                        principalTable: "herois",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IdentidadesSecretas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeReal = table.Column<string>(nullable: true),
                    heroiId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentidadesSecretas", x => x.id);
                    table.ForeignKey(
                        name: "FK_IdentidadesSecretas_herois_heroiId",
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
                name: "IX_HeroisBatalhas_heroiId",
                table: "HeroisBatalhas",
                column: "heroiId");

            migrationBuilder.CreateIndex(
                name: "IX_IdentidadesSecretas_heroiId",
                table: "IdentidadesSecretas",
                column: "heroiId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "armas");

            migrationBuilder.DropTable(
                name: "HeroisBatalhas");

            migrationBuilder.DropTable(
                name: "IdentidadesSecretas");

            migrationBuilder.DropTable(
                name: "batalhas");

            migrationBuilder.DropTable(
                name: "herois");
        }
    }
}
