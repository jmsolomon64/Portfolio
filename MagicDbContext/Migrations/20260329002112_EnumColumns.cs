using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicDbContext.Migrations
{
    /// <inheritdoc />
    public partial class EnumColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlanetEnum",
                schema: "base",
                table: "Planet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Value",
                schema: "base",
                table: "Number",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ElementEnum",
                schema: "element",
                table: "Element",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlanetEnum",
                schema: "base",
                table: "Planet");

            migrationBuilder.DropColumn(
                name: "Value",
                schema: "base",
                table: "Number");

            migrationBuilder.DropColumn(
                name: "ElementEnum",
                schema: "element",
                table: "Element");
        }
    }
}
