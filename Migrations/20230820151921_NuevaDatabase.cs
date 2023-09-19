using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_ComponenteCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class NuevaDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ordenadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ordenadores_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "componentes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoComponente = table.Column<int>(type: "INTEGER", nullable: false),
                    Serie = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Calor = table.Column<int>(type: "INTEGER", nullable: false),
                    Almacenamiento = table.Column<long>(type: "INTEGER", nullable: false),
                    Cores = table.Column<int>(type: "INTEGER", nullable: false),
                    OrdenadorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_componentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_componentes_ordenadores_OrdenadorId",
                        column: x => x.OrdenadorId,
                        principalTable: "ordenadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_componentes_OrdenadorId",
                table: "componentes",
                column: "OrdenadorId");

            migrationBuilder.CreateIndex(
                name: "IX_ordenadores_PedidoId",
                table: "ordenadores",
                column: "PedidoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "componentes");

            migrationBuilder.DropTable(
                name: "ordenadores");

            migrationBuilder.DropTable(
                name: "Pedidos");
        }
    }
}
