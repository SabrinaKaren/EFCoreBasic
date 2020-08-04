using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCore.WebAPI.Migrations
{
    public partial class heroiBatalha_idSecreta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_herois_batalhas_batalhaId",
                table: "herois");

            migrationBuilder.DropIndex(
                name: "IX_herois_batalhaId",
                table: "herois");

            migrationBuilder.DropColumn(
                name: "batalhaId",
                table: "herois");

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
                name: "HeroisBatalhas");

            migrationBuilder.DropTable(
                name: "IdentidadesSecretas");

            migrationBuilder.AddColumn<int>(
                name: "batalhaId",
                table: "herois",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_herois_batalhaId",
                table: "herois",
                column: "batalhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_herois_batalhas_batalhaId",
                table: "herois",
                column: "batalhaId",
                principalTable: "batalhas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
