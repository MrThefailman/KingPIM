using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KingPIM.Data.Migrations
{
    public partial class updated_customAttribute_again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_preDifinedOptions_PreDefine_PreDefineId",
                table: "preDifinedOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_PreDefine_PreDefinedId",
                table: "ProductAttributes");

            migrationBuilder.DropTable(
                name: "PreDefine");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributes_PreDefinedId",
                table: "ProductAttributes");

            migrationBuilder.DropColumn(
                name: "PreDefinedId",
                table: "ProductAttributes");

            migrationBuilder.RenameColumn(
                name: "PreDifinedId",
                table: "ProductAttributes",
                newName: "PreDifinedOptionsId");

            migrationBuilder.RenameColumn(
                name: "PreDefineId",
                table: "preDifinedOptions",
                newName: "ProductAttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_preDifinedOptions_PreDefineId",
                table: "preDifinedOptions",
                newName: "IX_preDifinedOptions_ProductAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_preDifinedOptions_ProductAttributes_ProductAttributeId",
                table: "preDifinedOptions",
                column: "ProductAttributeId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_preDifinedOptions_ProductAttributes_ProductAttributeId",
                table: "preDifinedOptions");

            migrationBuilder.RenameColumn(
                name: "PreDifinedOptionsId",
                table: "ProductAttributes",
                newName: "PreDifinedId");

            migrationBuilder.RenameColumn(
                name: "ProductAttributeId",
                table: "preDifinedOptions",
                newName: "PreDefineId");

            migrationBuilder.RenameIndex(
                name: "IX_preDifinedOptions_ProductAttributeId",
                table: "preDifinedOptions",
                newName: "IX_preDifinedOptions_PreDefineId");

            migrationBuilder.AddColumn<int>(
                name: "PreDefinedId",
                table: "ProductAttributes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PreDefine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreDefine", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributes_PreDefinedId",
                table: "ProductAttributes",
                column: "PreDefinedId");

            migrationBuilder.AddForeignKey(
                name: "FK_preDifinedOptions_PreDefine_PreDefineId",
                table: "preDifinedOptions",
                column: "PreDefineId",
                principalTable: "PreDefine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_PreDefine_PreDefinedId",
                table: "ProductAttributes",
                column: "PreDefinedId",
                principalTable: "PreDefine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
