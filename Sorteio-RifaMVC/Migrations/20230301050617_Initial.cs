using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sorteio_RifaMVC.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concorrentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCelular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SorteioId = table.Column<int>(type: "int", nullable: false),
                    ConcorrenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concorrentes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumeroCelularOrganizador = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sorteios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataSorteio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Premio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sorteios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sorteios_Organizadores_OrganizadorId",
                        column: x => x.OrganizadorId,
                        principalTable: "Organizadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Concorrentes_Sorteios",
                columns: table => new
                {
                    ConcorrenteId = table.Column<int>(type: "int", nullable: false),
                    SorteioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concorrentes_Sorteios", x => new { x.ConcorrenteId, x.SorteioId });
                    table.ForeignKey(
                        name: "FK_Concorrentes_Sorteios_Concorrentes_ConcorrenteId",
                        column: x => x.ConcorrenteId,
                        principalTable: "Concorrentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Concorrentes_Sorteios_Sorteios_SorteioId",
                        column: x => x.SorteioId,
                        principalTable: "Sorteios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NumerosSorteados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    SorteioId = table.Column<int>(type: "int", nullable: false),
                    ConcorrenteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumerosSorteados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumerosSorteados_Concorrentes_ConcorrenteId",
                        column: x => x.ConcorrenteId,
                        principalTable: "Concorrentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NumerosSorteados_Sorteios_SorteioId",
                        column: x => x.SorteioId,
                        principalTable: "Sorteios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Concorrentes_Sorteios_SorteioId",
                table: "Concorrentes_Sorteios",
                column: "SorteioId");

            migrationBuilder.CreateIndex(
                name: "IX_NumerosSorteados_ConcorrenteId",
                table: "NumerosSorteados",
                column: "ConcorrenteId");

            migrationBuilder.CreateIndex(
                name: "IX_NumerosSorteados_SorteioId",
                table: "NumerosSorteados",
                column: "SorteioId");

            migrationBuilder.CreateIndex(
                name: "IX_Sorteios_OrganizadorId",
                table: "Sorteios",
                column: "OrganizadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Concorrentes_Sorteios");

            migrationBuilder.DropTable(
                name: "NumerosSorteados");

            migrationBuilder.DropTable(
                name: "Concorrentes");

            migrationBuilder.DropTable(
                name: "Sorteios");

            migrationBuilder.DropTable(
                name: "Organizadores");
        }
    }
}
