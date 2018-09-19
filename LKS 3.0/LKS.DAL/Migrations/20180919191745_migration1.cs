using Microsoft.EntityFrameworkCore.Migrations;

namespace LKS.DAL.Migrations
{
    public partial class migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TroopId",
                table: "Students",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Prepod",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Coolness = table.Column<string>(nullable: true),
                    PrepodRank = table.Column<string>(nullable: true),
                    AdditionalInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prepod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Troops",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PlatoonCommanderId = table.Column<string>(nullable: true),
                    PrepodId = table.Column<string>(nullable: true),
                    NumberTroop = table.Column<string>(nullable: true),
                    StaffCount = table.Column<int>(nullable: false),
                    Vus = table.Column<string>(nullable: true),
                    SboriTroop = table.Column<bool>(nullable: false),
                    Day = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Troops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Troops_Prepod_PrepodId",
                        column: x => x.PrepodId,
                        principalTable: "Prepod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_TroopId",
                table: "Students",
                column: "TroopId");

            migrationBuilder.CreateIndex(
                name: "IX_Troops_PrepodId",
                table: "Troops",
                column: "PrepodId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Troops_TroopId",
                table: "Students",
                column: "TroopId",
                principalTable: "Troops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Troops_TroopId",
                table: "Students");

            migrationBuilder.DropTable(
                name: "Troops");

            migrationBuilder.DropTable(
                name: "Prepod");

            migrationBuilder.DropIndex(
                name: "IX_Students_TroopId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TroopId",
                table: "Students");
        }
    }
}
