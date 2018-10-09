using Microsoft.EntityFrameworkCore.Migrations;

namespace LKS.DAL.Migrations
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StaffCount",
                table: "Troops");

            migrationBuilder.DropColumn(
                name: "Vus",
                table: "Troops");

            migrationBuilder.DropColumn(
                name: "MobilePhonec",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "NumTroop",
                table: "Students",
                newName: "MobilePhone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MobilePhone",
                table: "Students",
                newName: "NumTroop");

            migrationBuilder.AddColumn<int>(
                name: "StaffCount",
                table: "Troops",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Vus",
                table: "Troops",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobilePhonec",
                table: "Students",
                nullable: true);
        }
    }
}
