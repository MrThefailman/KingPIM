using Microsoft.EntityFrameworkCore.Migrations;

namespace KingPIM.Data.Migrations
{
    public partial class updated_Predefines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PreDefine_ProductAttributes_ProductAttributeId",
                table: "PreDefine");

            migrationBuilder.DropForeignKey(
                name: "FK_PreDifinedOptions_PreDefine_PreDefineId",
                table: "PreDifinedOptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PreDifinedOptions",
                table: "PreDifinedOptions");

            migrationBuilder.DropIndex(
                name: "IX_PreDefine_ProductAttributeId",
                table: "PreDefine");

            migrationBuilder.DropColumn(
                name: "ProductAttributeId",
                table: "PreDefine");

            migrationBuilder.RenameTable(
                name: "PreDifinedOptions",
                newName: "preDifinedOptions");

            migrationBuilder.RenameIndex(
                name: "IX_PreDifinedOptions_PreDefineId",
                table: "preDifinedOptions",
                newName: "IX_preDifinedOptions_PreDefineId");

            migrationBuilder.AddColumn<int>(
                name: "PreDefinedId",
                table: "ProductAttributes",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_preDifinedOptions",
                table: "preDifinedOptions",
                column: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_preDifinedOptions_PreDefine_PreDefineId",
                table: "preDifinedOptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_PreDefine_PreDefinedId",
                table: "ProductAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttributes_PreDefinedId",
                table: "ProductAttributes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_preDifinedOptions",
                table: "preDifinedOptions");

            migrationBuilder.DropColumn(
                name: "PreDefinedId",
                table: "ProductAttributes");

            migrationBuilder.RenameTable(
                name: "preDifinedOptions",
                newName: "PreDifinedOptions");

            migrationBuilder.RenameIndex(
                name: "IX_preDifinedOptions_PreDefineId",
                table: "PreDifinedOptions",
                newName: "IX_PreDifinedOptions_PreDefineId");

            migrationBuilder.AddColumn<int>(
                name: "ProductAttributeId",
                table: "PreDefine",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PreDifinedOptions",
                table: "PreDifinedOptions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PreDefine_ProductAttributeId",
                table: "PreDefine",
                column: "ProductAttributeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PreDefine_ProductAttributes_ProductAttributeId",
                table: "PreDefine",
                column: "ProductAttributeId",
                principalTable: "ProductAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PreDifinedOptions_PreDefine_PreDefineId",
                table: "PreDifinedOptions",
                column: "PreDefineId",
                principalTable: "PreDefine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
