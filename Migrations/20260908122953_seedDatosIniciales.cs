using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _2026web3.Migrations
{
    /// <inheritdoc />
    public partial class seedDatosIniciales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Materia",
                columns: new[] { "Id", "Creditos", "Name" },
                values: new object[,]
                {
                    { 1, 5, "Programación I" },
                    { 2, 4, "Bases de Datos" },
                    { 3, 5, "Desarrollo Web" },
                    { 4, 3, "Matemática Discreta" },
                    { 5, 4, "Redes de Computadoras" }
                });

            migrationBuilder.InsertData(
                table: "Pais",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Guatemala" },
                    { 2, "México" },
                    { 3, "España" },
                    { 4, "Estados Unidos" },
                    { 5, "Argentina" }
                });

            migrationBuilder.InsertData(
                table: "Personas",
                columns: new[] { "Id", "Name", "dob", "paisId" },
                values: new object[,]
                {
                    { 1, "Ana López", new DateOnly(2000, 3, 15), 1 },
                    { 2, "Carlos Ramírez", new DateOnly(1998, 7, 2), 2 },
                    { 3, "María Fernández", new DateOnly(2001, 11, 20), 3 },
                    { 4, "Jorge Castillo", new DateOnly(1999, 1, 8), 1 },
                    { 5, "Lucía Morales", new DateOnly(2002, 6, 30), 5 }
                });

            migrationBuilder.InsertData(
                table: "Inscripcion",
                columns: new[] { "MateriasId", "PersonasId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 5 },
                    { 3, 1 },
                    { 3, 4 },
                    { 3, 5 },
                    { 4, 3 },
                    { 4, 5 },
                    { 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "Pasaporte",
                columns: new[] { "Id", "Numero", "personaId" },
                values: new object[,]
                {
                    { 1, "GT1234567", 1 },
                    { 2, "MX7654321", 2 },
                    { 3, "ES1122334", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inscripcion",
                keyColumns: new[] { "MateriasId", "PersonasId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Inscripcion",
                keyColumns: new[] { "MateriasId", "PersonasId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Inscripcion",
                keyColumns: new[] { "MateriasId", "PersonasId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "Inscripcion",
                keyColumns: new[] { "MateriasId", "PersonasId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Inscripcion",
                keyColumns: new[] { "MateriasId", "PersonasId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "Inscripcion",
                keyColumns: new[] { "MateriasId", "PersonasId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Inscripcion",
                keyColumns: new[] { "MateriasId", "PersonasId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "Inscripcion",
                keyColumns: new[] { "MateriasId", "PersonasId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "Inscripcion",
                keyColumns: new[] { "MateriasId", "PersonasId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Inscripcion",
                keyColumns: new[] { "MateriasId", "PersonasId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "Inscripcion",
                keyColumns: new[] { "MateriasId", "PersonasId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pasaporte",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pasaporte",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pasaporte",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Materia",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Personas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pais",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
