using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KingPIM.Data.Migrations
{
    public partial class Pre_Defined_List : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PreDifinedId",
                table: "ProductAttributes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PreDefine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProductAttributeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreDefine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreDefine_ProductAttributes_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "ProductAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreDifinedOptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    PreDefineId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreDifinedOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PreDifinedOptions_PreDefine_PreDefineId",
                        column: x => x.PreDefineId,
                        principalTable: "PreDefine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PreDefine_ProductAttributeId",
                table: "PreDefine",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_PreDifinedOptions_PreDefineId",
                table: "PreDifinedOptions",
                column: "PreDefineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PreDifinedOptions");

            migrationBuilder.DropTable(
                name: "PreDefine");

            migrationBuilder.DropColumn(
                name: "PreDifinedId",
                table: "ProductAttributes");
        }
    }
}
