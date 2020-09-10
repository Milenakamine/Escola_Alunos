using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EscolaAluno.Migrations
{
    public partial class MigrationName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    DataNasc = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Escolas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EscolaAlunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    IdAluno = table.Column<Guid>(nullable: false),
                    IdEscola = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscolaAlunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EscolaAlunos_Alunos_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EscolaAlunos_Escolas_IdEscola",
                        column: x => x.IdEscola,
                        principalTable: "Escolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EscolaAlunos_IdAluno",
                table: "EscolaAlunos",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_EscolaAlunos_IdEscola",
                table: "EscolaAlunos",
                column: "IdEscola");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EscolaAlunos");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Escolas");
        }
    }
}
