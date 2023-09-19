using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVC_ComponenteCodeFirst.Migrations
{
    /// <inheritdoc />
    public partial class AddPrecioOrdenador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<double>(
                name: "Precio",
                table: "Ordenadores",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
