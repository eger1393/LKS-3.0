using Microsoft.EntityFrameworkCore.Migrations;

namespace LKS.DAL.Migrations
{
    public partial class migr2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VkName",
                table: "Cycles");

            migrationBuilder.DropColumn(
                name: "VuzName",
                table: "Cycles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VkName",
                table: "Cycles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VuzName",
                table: "Cycles",
                nullable: true);
        }
    }
}
