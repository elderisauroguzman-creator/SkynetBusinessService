using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessService.Migrations
{
    /// <inheritdoc />
    public partial class AddLatitudVisita : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "LatitudVisita",
                table: "VisitaTecnica",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "LongitudVisita",
                table: "VisitaTecnica",
                type: "float",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longitud",
                table: "Clientes",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Latitud",
                table: "Clientes",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatitudVisita",
                table: "VisitaTecnica");

            migrationBuilder.DropColumn(
                name: "LongitudVisita",
                table: "VisitaTecnica");

            migrationBuilder.AlterColumn<decimal>(
                name: "Longitud",
                table: "Clientes",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitud",
                table: "Clientes",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
