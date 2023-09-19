using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_ComponenteCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class PrecioNamePedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Pedidos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Pedidos",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Pedidos");
        }
    }
}
