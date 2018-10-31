using Microsoft.EntityFrameworkCore.Migrations;

namespace LKS.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cycles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    VUS = table.Column<string>(nullable: true),
                    SpecialityName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cycles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prepods",
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
                    table.PrimaryKey("PK_Prepods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Troops",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PlatoonCommanderId = table.Column<string>(nullable: true),
                    CycleId = table.Column<string>(nullable: true),
                    PrepodId = table.Column<string>(nullable: true),
                    NumberTroop = table.Column<string>(nullable: true),
                    SboriTroop = table.Column<bool>(nullable: false),
                    Day = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Troops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Troops_Cycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Troops_Prepods_PrepodId",
                        column: x => x.PrepodId,
                        principalTable: "Prepods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TroopId = table.Column<string>(nullable: false),
                    Collness = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Rank = table.Column<string>(nullable: true),
                    InstGroup = table.Column<string>(nullable: false),
                    Kurs = table.Column<int>(nullable: false),
                    Faculty = table.Column<string>(nullable: false),
                    SpecInst = table.Column<string>(nullable: false),
                    ConditionsOfEducation = table.Column<string>(nullable: true),
                    AvarageScore = table.Column<string>(nullable: true),
                    YearOfAddMAI = table.Column<string>(nullable: true),
                    YearOfEndMAI = table.Column<string>(nullable: true),
                    YearOfAddVK = table.Column<string>(nullable: true),
                    YearOfEndVK = table.Column<string>(nullable: true),
                    NumberOfOrder = table.Column<string>(nullable: true),
                    DateOfOrder = table.Column<string>(nullable: true),
                    Rectal = table.Column<string>(nullable: false),
                    Birthday = table.Column<string>(nullable: false),
                    PlaceBirthday = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Citizenship = table.Column<string>(nullable: true),
                    HomePhone = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: false),
                    PlaceOfResidence = table.Column<string>(nullable: true),
                    PlaceOfRegestration = table.Column<string>(nullable: true),
                    Military = table.Column<string>(nullable: true),
                    FamiliStatys = table.Column<string>(nullable: true),
                    School = table.Column<string>(nullable: true),
                    Two_MobilePhone = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    Skill1 = table.Column<bool>(nullable: false),
                    Skill2 = table.Column<bool>(nullable: false),
                    Skill3 = table.Column<bool>(nullable: false),
                    Skill4 = table.Column<bool>(nullable: false),
                    Skill5 = table.Column<bool>(nullable: false),
                    Skill6 = table.Column<bool>(nullable: false),
                    Zapas = table.Column<bool>(nullable: false),
                    Exhortation = table.Column<bool>(nullable: false),
                    ProjectOrder = table.Column<bool>(nullable: false),
                    WhoseOrder = table.Column<string>(nullable: true),
                    VO = table.Column<string>(nullable: true),
                    Fighting = table.Column<string>(nullable: true),
                    BloodType = table.Column<string>(nullable: true),
                    Growth = table.Column<string>(nullable: true),
                    ClothihgSize = table.Column<string>(nullable: true),
                    ShoeSize = table.Column<string>(nullable: true),
                    CapSize = table.Column<string>(nullable: true),
                    MaskSize = table.Column<string>(nullable: true),
                    ForeignLanguage = table.Column<string>(nullable: true),
                    LanguageRank = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: false),
                    AssessmentProtocolOneTheory = table.Column<int>(nullable: false),
                    AssessmentProtocolOnePractice = table.Column<int>(nullable: false),
                    AssessmentProtocolOneFinal = table.Column<int>(nullable: false),
                    AssessmentCharacteristicMilitaryTechnicalTraining = table.Column<int>(nullable: false),
                    AssessmentCharacteristicTacticalSpecialTraining = table.Column<int>(nullable: false),
                    AssessmentCharacteristicMilitarySpeialTraining = table.Column<int>(nullable: false),
                    AssessmentCharacteristicFinal = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Troops_TroopId",
                        column: x => x.TroopId,
                        principalTable: "Troops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Relatives",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StudentId = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MaidenName = table.Column<string>(nullable: true),
                    RelationDegree = table.Column<string>(nullable: true),
                    Birthday = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
                    PlaceOfResidence = table.Column<string>(nullable: true),
                    PlaceOfRegestration = table.Column<string>(nullable: true),
                    HealthStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Relatives_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relatives_StudentId",
                table: "Relatives",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_TroopId",
                table: "Students",
                column: "TroopId");

            migrationBuilder.CreateIndex(
                name: "IX_Troops_CycleId",
                table: "Troops",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Troops_PrepodId",
                table: "Troops",
                column: "PrepodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relatives");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Troops");

            migrationBuilder.DropTable(
                name: "Cycles");

            migrationBuilder.DropTable(
                name: "Prepods");
        }
    }
}
