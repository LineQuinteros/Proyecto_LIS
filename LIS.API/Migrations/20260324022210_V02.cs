using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LIS.API.Migrations
{
    /// <inheritdoc />
    public partial class V02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especialidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    espe_nombre = table.Column<string>(type: "text", nullable: false),
                    espe_descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Examenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    exam_nombre = table.Column<string>(type: "text", nullable: false),
                    exam_unidad = table.Column<string>(type: "text", nullable: false),
                    exam_referencia = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examenes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pacientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pac_cedula = table.Column<string>(type: "text", nullable: false),
                    pac_nombres = table.Column<string>(type: "text", nullable: false),
                    pac_apellidos = table.Column<string>(type: "text", nullable: false),
                    Paciente_Fecha_Nac = table.Column<DateOnly>(type: "date", nullable: false),
                    pac_telefono = table.Column<string>(type: "text", nullable: false),
                    pac_correo = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    med_cedula = table.Column<string>(type: "text", nullable: false),
                    med_nombres = table.Column<string>(type: "text", nullable: false),
                    med_apellidos = table.Column<string>(type: "text", nullable: false),
                    med_telefono = table.Column<string>(type: "text", nullable: false),
                    med_correo = table.Column<string>(type: "text", nullable: false),
                    med_password = table.Column<string>(type: "text", nullable: false),
                    especialidadId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicos_Especialidades_especialidadId",
                        column: x => x.especialidadId,
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    orden_fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    orden_estado = table.Column<bool>(type: "boolean", nullable: false),
                    MedicoId = table.Column<int>(type: "integer", nullable: false),
                    PacienteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordenes_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordenes_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Resultados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    res_valor = table.Column<string>(type: "text", nullable: false),
                    res_comentario = table.Column<string>(type: "text", nullable: false),
                    OrdenId = table.Column<int>(type: "integer", nullable: false),
                    ExamenId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resultados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resultados_Examenes_ExamenId",
                        column: x => x.ExamenId,
                        principalTable: "Examenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resultados_Ordenes_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Ordenes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicos_especialidadId",
                table: "Medicos",
                column: "especialidadId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_MedicoId",
                table: "Ordenes",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_PacienteId",
                table: "Ordenes",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_ExamenId",
                table: "Resultados",
                column: "ExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_Resultados_OrdenId",
                table: "Resultados",
                column: "OrdenId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Resultados");

            migrationBuilder.DropTable(
                name: "Examenes");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropTable(
                name: "Pacientes");

            migrationBuilder.DropTable(
                name: "Especialidades");
        }
    }
}
