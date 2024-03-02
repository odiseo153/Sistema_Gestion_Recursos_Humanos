using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Negocio.Migrations
{
    public partial class migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreDepartamento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ClaveAcceso = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Rol = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "date", nullable: true),
                    Genero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CorreoElectronico = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaContratacion = table.Column<DateTime>(type: "date", nullable: true),
                    DepartamentoID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EstadoEmpleo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    DocumentosRelevantes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MensajesYAnuncios = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoID);
                    table.ForeignKey(
                        name: "FK__Empleados__Depar__267ABA7A",
                        column: x => x.DepartamentoID,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoID");
                });

            migrationBuilder.CreateTable(
                name: "Beneficios",
                columns: table => new
                {
                    BeneficioID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Cobertura = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Costos = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    EmpleadoID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficios", x => x.BeneficioID);
                    table.ForeignKey(
                        name: "FK__Beneficio__Emple__31EC6D26",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID");
                });

            migrationBuilder.CreateTable(
                name: "EvaluacionDesempeno",
                columns: table => new
                {
                    EvaluacionID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpleadoID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Objetivos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Responsabilidades = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompetenciasEvaluadas = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resultados = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaEvaluacion = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Evaluaci__99ABA8A56223E901", x => x.EvaluacionID);
                    table.ForeignKey(
                        name: "FK__Evaluacio__Emple__34C8D9D1",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID");
                });

            migrationBuilder.CreateTable(
                name: "Nomina",
                columns: table => new
                {
                    NominaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmpleadoID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PeriodoPago = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CalculosSalariales = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Deducciones = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Bonificaciones = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TotalPagar = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    FechaGeneracion = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nomina", x => x.NominaID);
                    table.ForeignKey(
                        name: "FK__Nomina__Empleado__2C3393D0",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID");
                });

            migrationBuilder.CreateTable(
                name: "TareasProyectos",
                columns: table => new
                {
                    TareaID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FechaAsignacion = table.Column<DateTime>(type: "date", nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "date", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    EmpleadoID = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TareasPr__5CD83671F2FBBFA2", x => x.TareaID);
                    table.ForeignKey(
                        name: "FK__TareasPro__Emple__29572725",
                        column: x => x.EmpleadoID,
                        principalTable: "Empleados",
                        principalColumn: "EmpleadoID");
                });

            migrationBuilder.CreateTable(
                name: "HistorialPagos",
                columns: table => new
                {
                    HistorialPagoID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NominaID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DetallesTransaccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPago = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialPagos", x => x.HistorialPagoID);
                    table.ForeignKey(
                        name: "FK__Historial__Nomin__2F10007B",
                        column: x => x.NominaID,
                        principalTable: "Nomina",
                        principalColumn: "NominaID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficios_EmpleadoID",
                table: "Beneficios",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_DepartamentoID",
                table: "Empleados",
                column: "DepartamentoID");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluacionDesempeno_EmpleadoID",
                table: "EvaluacionDesempeno",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialPagos_NominaID",
                table: "HistorialPagos",
                column: "NominaID");

            migrationBuilder.CreateIndex(
                name: "IX_Nomina_EmpleadoID",
                table: "Nomina",
                column: "EmpleadoID");

            migrationBuilder.CreateIndex(
                name: "IX_TareasProyectos_EmpleadoID",
                table: "TareasProyectos",
                column: "EmpleadoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beneficios");

            migrationBuilder.DropTable(
                name: "EvaluacionDesempeno");

            migrationBuilder.DropTable(
                name: "HistorialPagos");

            migrationBuilder.DropTable(
                name: "TareasProyectos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Nomina");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
