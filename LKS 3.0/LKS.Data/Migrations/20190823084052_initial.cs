using Microsoft.EntityFrameworkCore.Migrations;

namespace LKS.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Command = table.Column<string>(nullable: true),
                    Rank = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Collness = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assessments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ProtocolOneTheory = table.Column<int>(nullable: false),
                    ProtocolOnePractice = table.Column<int>(nullable: false),
                    ProtocolOneFinal = table.Column<int>(nullable: false),
                    SportLevel = table.Column<int>(nullable: false),
                    MethodologicalLevel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ParentCategoryId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    Coolness = table.Column<int>(nullable: false),
                    PrepodRank = table.Column<string>(nullable: true),
                    AdditionalInfo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prepods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Summers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    NumberofOrder = table.Column<string>(nullable: true),
                    DateOfOrder = table.Column<string>(nullable: true),
                    TextOrder = table.Column<string>(nullable: true),
                    DateBeginSbori = table.Column<string>(nullable: true),
                    DateEndSbori = table.Column<string>(nullable: true),
                    DatePrisyaga = table.Column<string>(nullable: true),
                    DateExamen = table.Column<string>(nullable: true),
                    NumberVK = table.Column<string>(nullable: true),
                    LocationVK = table.Column<string>(nullable: true),
                    BmpKr = table.Column<string>(nullable: true),
                    BmpFull = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Summers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    TroopId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CategoryId = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    URI = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Templates_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TroopId = table.Column<string>(nullable: true),
                    SboryTroopId = table.Column<string>(nullable: true),
                    Collness = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    InstGroup = table.Column<string>(nullable: true),
                    Kurs = table.Column<int>(nullable: false),
                    Faculty = table.Column<string>(nullable: true),
                    SpecInst = table.Column<string>(nullable: true),
                    ConditionsOfEducation = table.Column<string>(nullable: true),
                    AvarageScore = table.Column<string>(nullable: true),
                    YearOfAddMAI = table.Column<string>(nullable: true),
                    YearOfEndMAI = table.Column<string>(nullable: true),
                    YearOfAddVK = table.Column<string>(nullable: true),
                    YearOfEndVK = table.Column<string>(nullable: true),
                    NumberOfOrder = table.Column<string>(nullable: true),
                    DateOfOrder = table.Column<string>(nullable: true),
                    Rectal = table.Column<string>(nullable: true),
                    Birthday = table.Column<string>(nullable: true),
                    PlaceBirthday = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Citizenship = table.Column<string>(nullable: true),
                    HomePhone = table.Column<string>(nullable: true),
                    MobilePhone = table.Column<string>(nullable: true),
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
                    AssesmentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Assessments_AssesmentId",
                        column: x => x.AssesmentId,
                        principalTable: "Assessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "Troops",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    PlatoonCommanderId = table.Column<string>(nullable: true),
                    CycleId = table.Column<string>(nullable: false),
                    PrepodId = table.Column<string>(nullable: true),
                    NumberTroop = table.Column<string>(nullable: false),
                    IsSboriTroop = table.Column<bool>(nullable: false),
                    ArrivalDay = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Troops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Troops_Cycles_CycleId",
                        column: x => x.CycleId,
                        principalTable: "Cycles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Troops_Students_PlatoonCommanderId",
                        column: x => x.PlatoonCommanderId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Troops_Prepods_PrepodId",
                        column: x => x.PrepodId,
                        principalTable: "Prepods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Number", "SpecialityName", "VUS" },
                values: new object[] { "1", "4", "ТОР", "042600" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "Role", "TroopId" },
                values: new object[] { "557dd927-fa3a-4245-a952-9820194c05c7", "Admin", "P@ssw0rdAdmin", "Admin", null });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryId",
                table: "Categories",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Relatives_StudentId",
                table: "Relatives",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AssesmentId",
                table: "Students",
                column: "AssesmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SboryTroopId",
                table: "Students",
                column: "SboryTroopId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_TroopId",
                table: "Students",
                column: "TroopId");

            migrationBuilder.CreateIndex(
                name: "IX_Templates_CategoryId",
                table: "Templates",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Troops_CycleId",
                table: "Troops",
                column: "CycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Troops_NumberTroop",
                table: "Troops",
                column: "NumberTroop",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Troops_PlatoonCommanderId",
                table: "Troops",
                column: "PlatoonCommanderId");

            migrationBuilder.CreateIndex(
                name: "IX_Troops_PrepodId",
                table: "Troops",
                column: "PrepodId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TroopId",
                table: "Users",
                column: "TroopId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Troops_SboryTroopId",
                table: "Students",
                column: "SboryTroopId",
                principalTable: "Troops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Troops_Students_PlatoonCommanderId",
                table: "Troops");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Relatives");

            migrationBuilder.DropTable(
                name: "Summers");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Assessments");

            migrationBuilder.DropTable(
                name: "Troops");

            migrationBuilder.DropTable(
                name: "Cycles");

            migrationBuilder.DropTable(
                name: "Prepods");
        }
    }
}
