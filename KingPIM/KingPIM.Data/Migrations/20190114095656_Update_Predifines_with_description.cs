using Microsoft.EntityFrameworkCore.Migrations;

namespace KingPIM.Data.Migrations
{
    public partial class Update_Predifines_with_description : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PreDefine",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PreDefine");
        }
    }
}
