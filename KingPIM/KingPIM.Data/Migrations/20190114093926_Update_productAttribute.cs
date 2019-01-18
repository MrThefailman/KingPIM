using Microsoft.EntityFrameworkCore.Migrations;

namespace KingPIM.Data.Migrations
{
    public partial class Update_productAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_AttributeGroups_AttributeGroupId",
                table: "ProductAttributes");

            migrationBuilder.AlterColumn<int>(
                name: "AttributeGroupId",
                table: "ProductAttributes",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_AttributeGroups_AttributeGroupId",
                table: "ProductAttributes",
                column: "AttributeGroupId",
                principalTable: "AttributeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttributes_AttributeGroups_AttributeGroupId",
                table: "ProductAttributes");

            migrationBuilder.AlterColumn<int>(
                name: "AttributeGroupId",
                table: "ProductAttributes",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttributes_AttributeGroups_AttributeGroupId",
                table: "ProductAttributes",
                column: "AttributeGroupId",
                principalTable: "AttributeGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
