using Microsoft.EntityFrameworkCore.Migrations;

namespace Consultorio.Migrations
{
    public partial class updateIdEspecialidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Especialidades_id_profissional",
                table: "Consultas");

            migrationBuilder.AddColumn<int>(
                name: "id_especialidade",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_id_especialidade",
                table: "Consultas",
                column: "id_especialidade");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Especialidades_id_especialidade",
                table: "Consultas",
                column: "id_especialidade",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Especialidades_id_especialidade",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_id_especialidade",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "id_especialidade",
                table: "Consultas");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Especialidades_id_profissional",
                table: "Consultas",
                column: "id_profissional",
                principalTable: "Especialidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
