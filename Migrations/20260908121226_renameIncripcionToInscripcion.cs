using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2026web3.Migrations
{
    /// <inheritdoc />
    public partial class renameIncripcionToInscripcion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incripcion_Materia_MateriasId",
                table: "Incripcion");

            migrationBuilder.DropForeignKey(
                name: "FK_Incripcion_Personas_PersonasId",
                table: "Incripcion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Incripcion",
                table: "Incripcion");

            migrationBuilder.RenameTable(
                name: "Incripcion",
                newName: "Inscripcion");

            migrationBuilder.RenameIndex(
                name: "IX_Incripcion_PersonasId",
                table: "Inscripcion",
                newName: "IX_Inscripcion_PersonasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inscripcion",
                table: "Inscripcion",
                columns: new[] { "MateriasId", "PersonasId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripcion_Materia_MateriasId",
                table: "Inscripcion",
                column: "MateriasId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inscripcion_Personas_PersonasId",
                table: "Inscripcion",
                column: "PersonasId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inscripcion_Materia_MateriasId",
                table: "Inscripcion");

            migrationBuilder.DropForeignKey(
                name: "FK_Inscripcion_Personas_PersonasId",
                table: "Inscripcion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inscripcion",
                table: "Inscripcion");

            migrationBuilder.RenameTable(
                name: "Inscripcion",
                newName: "Incripcion");

            migrationBuilder.RenameIndex(
                name: "IX_Inscripcion_PersonasId",
                table: "Incripcion",
                newName: "IX_Incripcion_PersonasId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Incripcion",
                table: "Incripcion",
                columns: new[] { "MateriasId", "PersonasId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Incripcion_Materia_MateriasId",
                table: "Incripcion",
                column: "MateriasId",
                principalTable: "Materia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Incripcion_Personas_PersonasId",
                table: "Incripcion",
                column: "PersonasId",
                principalTable: "Personas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
