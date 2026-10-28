using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ParqueoApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PRQ_Automovil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    Anio = table.Column<int>(type: "INTEGER", nullable: false),
                    Fabricante = table.Column<string>(type: "TEXT", nullable: false),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRQ_Automovil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRQ_Parqueo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NombreProvincia = table.Column<string>(type: "TEXT", nullable: false),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    PrecioPorHora = table.Column<decimal>(type: "TEXT", precision: 10, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRQ_Parqueo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRQ_Ingreso",
                columns: table => new
                {
                    Consecutivo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParqueoId = table.Column<int>(type: "INTEGER", nullable: false),
                    AutomovilId = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaHoraEntrada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaHoraSalida = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRQ_Ingreso", x => x.Consecutivo);
                    table.ForeignKey(
                        name: "FK_PRQ_Ingreso_PRQ_Automovil_AutomovilId",
                        column: x => x.AutomovilId,
                        principalTable: "PRQ_Automovil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PRQ_Ingreso_PRQ_Parqueo_ParqueoId",
                        column: x => x.ParqueoId,
                        principalTable: "PRQ_Parqueo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "PRQ_Automovil",
                columns: new[] { "Id", "Anio", "Color", "Fabricante", "Tipo" },
                values: new object[,]
                {
                    { 1, 2020, "Rojo", "Toyota", "sedán" },
                    { 2, 2022, "Azul", "Honda", "sedán" },
                    { 3, 2019, "Negro", "Toyota", "4x4" },
                    { 4, 2023, "Blanco", "Hyundai", "sedán" },
                    { 5, 2021, "Gris", "Suzuki", "moto" },
                    { 6, 2018, "Verde", "Nissan", "4x4" },
                    { 7, 2024, "Plateado", "Kia", "sedán" },
                    { 8, 2022, "Amarillo", "Yamaha", "moto" }
                });

            migrationBuilder.InsertData(
                table: "PRQ_Parqueo",
                columns: new[] { "Id", "Nombre", "NombreProvincia", "PrecioPorHora" },
                values: new object[,]
                {
                    { 1, "Parqueo Central", "San José", 1200m },
                    { 2, "Parqueo Aeropuerto", "Alajuela", 1500m },
                    { 3, "Parqueo Basílica", "Cartago", 1000m },
                    { 4, "Parqueo del Café", "Heredia", 1100m },
                    { 5, "Parqueo Tamarindo", "Guanacaste", 1800m },
                    { 6, "Parqueo del Puerto", "Puntarenas", 1300m },
                    { 7, "Parqueo Caribe", "Limón", 1250m },
                    { 8, "Parqueo Escazú", "San José", 1600m }
                });

            migrationBuilder.InsertData(
                table: "PRQ_Ingreso",
                columns: new[] { "Consecutivo", "AutomovilId", "FechaHoraEntrada", "FechaHoraSalida", "ParqueoId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 10, 20, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 20, 10, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2026, 10, 20, 9, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 20, 11, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 3, new DateTime(2026, 10, 21, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 21, 9, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 4, new DateTime(2026, 10, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 10, 21, 13, 30, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 5, new DateTime(2026, 10, 22, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 5 },
                    { 6, 6, new DateTime(2026, 10, 22, 14, 45, 0, 0, DateTimeKind.Unspecified), null, 6 },
                    { 7, 7, new DateTime(2026, 10, 23, 8, 20, 0, 0, DateTimeKind.Unspecified), null, 7 },
                    { 8, 8, new DateTime(2026, 10, 23, 16, 10, 0, 0, DateTimeKind.Unspecified), null, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRQ_Ingreso_AutomovilId",
                table: "PRQ_Ingreso",
                column: "AutomovilId");

            migrationBuilder.CreateIndex(
                name: "IX_PRQ_Ingreso_ParqueoId",
                table: "PRQ_Ingreso",
                column: "ParqueoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRQ_Ingreso");

            migrationBuilder.DropTable(
                name: "PRQ_Automovil");

            migrationBuilder.DropTable(
                name: "PRQ_Parqueo");
        }
    }
}
