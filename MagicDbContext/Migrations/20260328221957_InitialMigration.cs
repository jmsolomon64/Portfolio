using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicDbContext.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "base");

            migrationBuilder.EnsureSchema(
                name: "element");

            migrationBuilder.CreateTable(
                name: "Alias",
                schema: "base",
                columns: table => new
                {
                    AliasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alias", x => x.AliasId);
                });

            migrationBuilder.CreateTable(
                name: "Number",
                schema: "base",
                columns: table => new
                {
                    NumberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Number", x => x.NumberId);
                });

            migrationBuilder.CreateTable(
                name: "Symbol",
                schema: "base",
                columns: table => new
                {
                    SymbolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NVARCHAR255 = table.Column<string>(name: "NVARCHAR(255)", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbol", x => x.SymbolId);
                });

            migrationBuilder.CreateTable(
                name: "Element",
                schema: "element",
                columns: table => new
                {
                    ElementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    MainSymbolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Element", x => x.ElementId);
                    table.ForeignKey(
                        name: "FK_Element_Symbol_MainSymbolId",
                        column: x => x.MainSymbolId,
                        principalSchema: "base",
                        principalTable: "Symbol",
                        principalColumn: "SymbolId");
                });

            migrationBuilder.CreateTable(
                name: "Planet",
                schema: "base",
                columns: table => new
                {
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsClassical = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    SymbolId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planet", x => x.PlanetId);
                    table.ForeignKey(
                        name: "FK_Planet_Symbol_SymbolId",
                        column: x => x.SymbolId,
                        principalSchema: "base",
                        principalTable: "Symbol",
                        principalColumn: "SymbolId");
                });

            migrationBuilder.CreateTable(
                name: "ElementAlias",
                schema: "element",
                columns: table => new
                {
                    ElementAliasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementId = table.Column<int>(type: "int", nullable: false),
                    AliasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementAlias", x => x.ElementAliasId);
                    table.ForeignKey(
                        name: "FK_ElementAlias_Alias_AliasId",
                        column: x => x.AliasId,
                        principalSchema: "base",
                        principalTable: "Alias",
                        principalColumn: "AliasId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementAlias_Element_ElementId",
                        column: x => x.ElementId,
                        principalSchema: "element",
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementSymbol",
                schema: "element",
                columns: table => new
                {
                    ElementSymbolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementId = table.Column<int>(type: "int", nullable: false),
                    SymbolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementSymbol", x => x.ElementSymbolId);
                    table.ForeignKey(
                        name: "FK_ElementSymbol_Element_ElementId",
                        column: x => x.ElementId,
                        principalSchema: "element",
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementSymbol_Symbol_SymbolId",
                        column: x => x.SymbolId,
                        principalSchema: "base",
                        principalTable: "Symbol",
                        principalColumn: "SymbolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElementPlanetaryCorrespondence",
                schema: "element",
                columns: table => new
                {
                    CorrespondenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElementId = table.Column<int>(type: "int", nullable: false),
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementPlanetaryCorrespondence", x => x.CorrespondenceId);
                    table.ForeignKey(
                        name: "FK_ElementPlanetaryCorrespondence_Element_ElementId",
                        column: x => x.ElementId,
                        principalSchema: "element",
                        principalTable: "Element",
                        principalColumn: "ElementId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementPlanetaryCorrespondence_Planet_PlanetId",
                        column: x => x.PlanetId,
                        principalSchema: "base",
                        principalTable: "Planet",
                        principalColumn: "PlanetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Element_MainSymbolId",
                schema: "element",
                table: "Element",
                column: "MainSymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementAlias_AliasId",
                schema: "element",
                table: "ElementAlias",
                column: "AliasId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementAlias_ElementId",
                schema: "element",
                table: "ElementAlias",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementPlanetaryCorrespondence_ElementId",
                schema: "element",
                table: "ElementPlanetaryCorrespondence",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementPlanetaryCorrespondence_PlanetId",
                schema: "element",
                table: "ElementPlanetaryCorrespondence",
                column: "PlanetId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementSymbol_ElementId",
                schema: "element",
                table: "ElementSymbol",
                column: "ElementId");

            migrationBuilder.CreateIndex(
                name: "IX_ElementSymbol_SymbolId",
                schema: "element",
                table: "ElementSymbol",
                column: "SymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_Planet_SymbolId",
                schema: "base",
                table: "Planet",
                column: "SymbolId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementAlias",
                schema: "element");

            migrationBuilder.DropTable(
                name: "ElementPlanetaryCorrespondence",
                schema: "element");

            migrationBuilder.DropTable(
                name: "ElementSymbol",
                schema: "element");

            migrationBuilder.DropTable(
                name: "Number",
                schema: "base");

            migrationBuilder.DropTable(
                name: "Alias",
                schema: "base");

            migrationBuilder.DropTable(
                name: "Planet",
                schema: "base");

            migrationBuilder.DropTable(
                name: "Element",
                schema: "element");

            migrationBuilder.DropTable(
                name: "Symbol",
                schema: "base");
        }
    }
}
