using Microsoft.EntityFrameworkCore.Migrations;

namespace LKS.Data.Migrations
{
    public partial class init : Migration
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
                table: "Admins",
                columns: new[] { "Id", "Collness", "Command", "FirstName", "LastName", "MiddleName", "Rank" },
                values: new object[] { "1", "Полковник", "НАЧ-НАЧ", "Иван", "Иванович", "Иванов", "Начальник начальников" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[] { "1", "Testййцу", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[] { "2", "Test2", null });

            migrationBuilder.InsertData(
                table: "Cycles",
                columns: new[] { "Id", "Number", "SpecialityName", "VUS" },
                values: new object[] { "1", "4", "ТОР", "042600" });

            migrationBuilder.InsertData(
                table: "Prepods",
                columns: new[] { "Id", "AdditionalInfo", "Coolness", "FirstName", "LastName", "MiddleName", "PrepodRank" },
                values: new object[] { "1", null, 0, "Иван", "Иванов", "Иванович", "test" });

            migrationBuilder.InsertData(
                table: "Summers",
                columns: new[] { "Id", "BmpFull", "BmpKr", "DateBeginSbori", "DateEndSbori", "DateExamen", "DateOfOrder", "DatePrisyaga", "LocationVK", "NumberVK", "NumberofOrder", "TextOrder" },
                values: new object[] { "1", null, null, null, null, null, null, null, "Наро Фоминск", null, "12412", "ПРИКАЗЫВАЮ" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "Role", "TroopId" },
                values: new object[] { "6bf9811d-be8c-45d6-bb3d-48e67061258f", "Admin", "P@ssw0rdAdmin", "Admin", null });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "Role", "TroopId" },
                values: new object[] { "9ebcc47d-23de-4bd0-853d-da6a9c2efa40", "Troop410", "P@ssw0rdTroop410", "User", "1" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "Role", "TroopId" },
                values: new object[] { "745122e7-6c33-47a9-a5f6-298d1920264e", "Troop520", "P@ssw0rdTroop520", "User", "2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "Role", "TroopId" },
                values: new object[] { "495e1499-e3b4-49a5-99fd-58ec6e246af1", "Troop420", "P@ssw0rdTroop420", "User", "3" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Password", "Role", "TroopId" },
                values: new object[] { "cb117f42-d858-411f-85a3-74e44f008dc2", "Troop510", "P@ssw0rdTroop510", "User", "4" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[] { "3", "Test3", "1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[] { "4", "Test4", "1" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[] { "5", "Test5", "2" });

            migrationBuilder.InsertData(
                table: "Troops",
                columns: new[] { "Id", "ArrivalDay", "CycleId", "IsSboriTroop", "NumberTroop", "PlatoonCommanderId", "PrepodId" },
                values: new object[] { "1", 0, "1", false, "410", null, "1" });

            migrationBuilder.InsertData(
                table: "Troops",
                columns: new[] { "Id", "ArrivalDay", "CycleId", "IsSboriTroop", "NumberTroop", "PlatoonCommanderId", "PrepodId" },
                values: new object[] { "2", 0, "1", false, "520", null, "1" });

            migrationBuilder.InsertData(
                table: "Troops",
                columns: new[] { "Id", "ArrivalDay", "CycleId", "IsSboriTroop", "NumberTroop", "PlatoonCommanderId", "PrepodId" },
                values: new object[] { "3", 0, "1", false, "420", null, "1" });

            migrationBuilder.InsertData(
                table: "Troops",
                columns: new[] { "Id", "ArrivalDay", "CycleId", "IsSboriTroop", "NumberTroop", "PlatoonCommanderId", "PrepodId" },
                values: new object[] { "4", 0, "1", false, "510", null, "1" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "f6209b59-54ea-4b2e-b1f5-0f39dabb5ab2", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя1", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия28", null, "Отчество22", null, null, null, null, null, null, null, null, 0, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 2, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "13832", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя39", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия15", null, "Отчество3", null, null, null, null, null, null, null, null, 4, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 0, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "14014", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя74", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия82", null, "Отчество12", null, null, null, null, null, null, null, null, 2, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 2, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "14196", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя90", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия49", null, "Отчество11", null, null, null, null, null, null, null, null, 2, false, "Красногорский", null, null, null, false, false, false, false, false, false, "МАТ", 1, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "14378", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя40", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия38", null, "Отчество58", null, null, null, null, null, null, null, null, 0, false, "Московский", null, null, null, false, false, false, false, false, false, "ЕНА", 2, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "14560", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя31", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия29", null, "Отчество19", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "МАТ", 2, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "14742", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя4", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия1", null, "Отчество63", null, null, null, null, null, null, null, null, 1, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 3, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "14924", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя99", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия84", null, "Отчество25", null, null, null, null, null, null, null, null, 3, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 1, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "15106", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя66", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия65", null, "Отчество22", null, null, null, null, null, null, null, null, 3, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "БИ", 1, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "15288", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя69", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия38", null, "Отчество52", null, null, null, null, null, null, null, null, 1, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 3, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "15470", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя78", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия50", null, "Отчество44", null, null, null, null, null, null, null, null, 3, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 1, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "15652", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя9", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия82", null, "Отчество79", null, null, null, null, null, null, null, null, 2, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "БИ", 2, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "15834", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя53", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия79", null, "Отчество73", null, null, null, null, null, null, null, null, 1, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 3, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "16016", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя37", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия20", null, "Отчество20", null, null, null, null, null, null, null, null, 3, false, "Московский", null, null, null, false, false, false, false, false, false, "ИВТ", 3, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "16198", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя58", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия31", null, "Отчество32", null, null, null, null, null, null, null, null, 0, false, "Тульский", null, null, null, false, false, false, false, false, false, "БИ", 0, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "16380", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя90", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия95", null, "Отчество49", null, null, null, null, null, null, null, null, 1, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "МАТ", 2, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "16562", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя88", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия96", null, "Отчество45", null, null, null, null, null, null, null, null, 1, false, "Московский", null, null, null, false, false, false, false, false, false, "ИВТ", 2, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "16744", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя20", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия44", null, "Отчество66", null, null, null, null, null, null, null, null, 3, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 3, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "16926", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя2", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия87", null, "Отчество95", null, null, null, null, null, null, null, null, 1, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 3, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "17108", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя75", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия64", null, "Отчество85", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "17290", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя83", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия52", null, "Отчество34", null, null, null, null, null, null, null, null, 2, false, "Тульский", null, null, null, false, false, false, false, false, false, "БИ", 0, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "17472", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя11", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия66", null, "Отчество53", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "13650", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя91", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия47", null, "Отчество51", null, null, null, null, null, null, null, null, 1, false, "Московский", null, null, null, false, false, false, false, false, false, "ИВТ", 3, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "17654", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя27", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия69", null, "Отчество45", null, null, null, null, null, null, null, null, 4, false, "Тульский", null, null, null, false, false, false, false, false, false, "МАТ", 0, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "13468", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя49", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия89", null, "Отчество2", null, null, null, null, null, null, null, null, 4, false, "Красногорский", null, null, null, false, false, false, false, false, false, "МАТ", 2, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "13104", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя12", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия37", null, "Отчество96", null, null, null, null, null, null, null, null, 2, false, "Красногорский", null, null, null, false, false, false, false, false, false, "МАТ", 2, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "9282", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя15", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия14", null, "Отчество43", null, null, null, null, null, null, null, null, 4, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "МАТ", 1, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "9464", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя87", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия15", null, "Отчество6", null, null, null, null, null, null, null, null, 4, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "9646", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя43", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия82", null, "Отчество68", null, null, null, null, null, null, null, null, 1, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ЕНА", 2, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "9828", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя3", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия67", null, "Отчество69", null, null, null, null, null, null, null, null, 1, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ИВТ", 3, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "10010", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя38", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия24", null, "Отчество30", null, null, null, null, null, null, null, null, 2, false, "Тульский", null, null, null, false, false, false, false, false, false, "БИ", 0, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "10192", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя49", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия6", null, "Отчество37", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "МАТ", 1, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "10374", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя24", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия69", null, "Отчество57", null, null, null, null, null, null, null, null, 1, false, "Красногорский", null, null, null, false, false, false, false, false, false, "МАТ", 1, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "10556", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя93", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия85", null, "Отчество34", null, null, null, null, null, null, null, null, 0, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 3, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "10738", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя90", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия13", null, "Отчество51", null, null, null, null, null, null, null, null, 3, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ИВТ", 3, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "10920", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя37", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия50", null, "Отчество42", null, null, null, null, null, null, null, null, 1, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ЕНА", 0, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "11102", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя93", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия37", null, "Отчество78", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "МАТ", 1, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "11284", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя99", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия90", null, "Отчество75", null, null, null, null, null, null, null, null, 4, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ЕНА", 2, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "11466", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя87", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия45", null, "Отчество35", null, null, null, null, null, null, null, null, 2, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "11648", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя93", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия72", null, "Отчество10", null, null, null, null, null, null, null, null, 0, false, "Московский", null, null, null, false, false, false, false, false, false, "ЕНА", 3, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "11830", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя49", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия9", null, "Отчество75", null, null, null, null, null, null, null, null, 2, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ЕНА", 0, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "12012", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя52", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия5", null, "Отчество17", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ИВТ", 2, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "12194", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя63", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия88", null, "Отчество99", null, null, null, null, null, null, null, null, 4, false, "Московский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "12376", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя97", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия66", null, "Отчество49", null, null, null, null, null, null, null, null, 4, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 2, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "12558", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя89", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия77", null, "Отчество35", null, null, null, null, null, null, null, null, 1, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "12740", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя90", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия21", null, "Отчество55", null, null, null, null, null, null, null, null, 3, false, "Московский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "12922", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя12", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия49", null, "Отчество18", null, null, null, null, null, null, null, null, 1, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "БИ", 0, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "13286", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя9", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия55", null, "Отчество11", null, null, null, null, null, null, null, null, 2, false, "Московский", null, null, null, false, false, false, false, false, false, "БИ", 2, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "17836", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя69", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия64", null, "Отчество40", null, null, null, null, null, null, null, null, 0, false, "Московский", null, null, null, false, false, false, false, false, false, "БИ", 1, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "18018", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя70", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия38", null, "Отчество31", null, null, null, null, null, null, null, null, 4, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "0", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя4", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия24", null, "Отчество39", null, null, null, null, null, null, null, null, 4, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "МАТ", 1, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "4914", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя60", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия45", null, "Отчество46", null, null, null, null, null, null, null, null, 2, false, "Тульский", null, null, null, false, false, false, false, false, false, "ЕНА", 2, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "5096", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя69", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия29", null, "Отчество69", null, null, null, null, null, null, null, null, 4, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 2, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "5278", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя10", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия59", null, "Отчество36", null, null, null, null, null, null, null, null, 0, false, "Тульский", null, null, null, false, false, false, false, false, false, "БИ", 1, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "5460", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя68", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия47", null, "Отчество83", null, null, null, null, null, null, null, null, 2, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 2, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "5642", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя66", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия60", null, "Отчество52", null, null, null, null, null, null, null, null, 1, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 2, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "5824", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя14", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия37", null, "Отчество93", null, null, null, null, null, null, null, null, 1, false, "Московский", null, null, null, false, false, false, false, false, false, "ИВТ", 3, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "6006", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя44", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия7", null, "Отчество33", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ЕНА", 3, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "6188", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя31", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия13", null, "Отчество6", null, null, null, null, null, null, null, null, 0, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 3, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "6370", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя72", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия4", null, "Отчество14", null, null, null, null, null, null, null, null, 1, false, "Московский", null, null, null, false, false, false, false, false, false, "МАТ", 0, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "6552", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя39", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия78", null, "Отчество50", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ЕНА", 0, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "6734", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя15", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия84", null, "Отчество25", null, null, null, null, null, null, null, null, 0, false, "Тульский", null, null, null, false, false, false, false, false, false, "БИ", 2, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "6916", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя85", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия66", null, "Отчество24", null, null, null, null, null, null, null, null, 3, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 1, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "7098", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя25", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия4", null, "Отчество49", null, null, null, null, null, null, null, null, 1, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 0, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "7280", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя74", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия16", null, "Отчество53", null, null, null, null, null, null, null, null, 0, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "7462", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя51", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия84", null, "Отчество46", null, null, null, null, null, null, null, null, 2, false, "Тульский", null, null, null, false, false, false, false, false, false, "ЕНА", 0, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "7644", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя1", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия44", null, "Отчество53", null, null, null, null, null, null, null, null, 1, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ИВТ", 3, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "7826", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя99", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия21", null, "Отчество70", null, null, null, null, null, null, null, null, 4, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ЕНА", 0, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "8008", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя51", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия15", null, "Отчество77", null, null, null, null, null, null, null, null, 1, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "МАТ", 0, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "8190", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя60", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия84", null, "Отчество70", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ИВТ", 2, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "8372", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя60", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия41", null, "Отчество64", null, null, null, null, null, null, null, null, 0, false, "Московский", null, null, null, false, false, false, false, false, false, "ЕНА", 2, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "8554", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя86", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия72", null, "Отчество83", null, null, null, null, null, null, null, null, 4, false, "Московский", null, null, null, false, false, false, false, false, false, "ИВТ", 2, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "4732", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя17", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия35", null, "Отчество76", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "МАТ", 0, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "4550", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя19", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия69", null, "Отчество7", null, null, null, null, null, null, null, null, 1, false, "Московский", null, null, null, false, false, false, false, false, false, "БИ", 1, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "4368", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя62", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия27", null, "Отчество69", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ИВТ", 1, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "4186", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя74", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия97", null, "Отчество79", null, null, null, null, null, null, null, null, 1, false, "Московский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "182", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя68", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия16", null, "Отчество51", null, null, null, null, null, null, null, null, 3, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "МАТ", 2, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "364", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя22", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия99", null, "Отчество99", null, null, null, null, null, null, null, null, 3, false, "Тульский", null, null, null, false, false, false, false, false, false, "МАТ", 3, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "546", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя38", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия91", null, "Отчество36", null, null, null, null, null, null, null, null, 3, false, "Тульский", null, null, null, false, false, false, false, false, false, "МАТ", 2, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "728", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя8", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия52", null, "Отчество24", null, null, null, null, null, null, null, null, 0, false, "Красногорский", null, null, null, false, false, false, false, false, false, "МАТ", 2, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "910", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя79", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия77", null, "Отчество97", null, null, null, null, null, null, null, null, 0, false, "Красногорский", null, null, null, false, false, false, false, false, false, "МАТ", 1, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "1092", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя23", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия45", null, "Отчество38", null, null, null, null, null, null, null, null, 0, false, "Московский", null, null, null, false, false, false, false, false, false, "БИ", 1, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "1274", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя52", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия60", null, "Отчество6", null, null, null, null, null, null, null, null, 0, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "1456", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя41", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия79", null, "Отчество22", null, null, null, null, null, null, null, null, 4, false, "Московский", null, null, null, false, false, false, false, false, false, "БИ", 1, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "1638", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя84", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия33", null, "Отчество69", null, null, null, null, null, null, null, null, 3, false, "Московский", null, null, null, false, false, false, false, false, false, "ИВТ", 1, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "1820", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя85", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия97", null, "Отчество7", null, null, null, null, null, null, null, null, 3, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 2, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "9100", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя54", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия5", null, "Отчество15", null, null, null, null, null, null, null, null, 4, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "3", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "2002", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя46", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия86", null, "Отчество94", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "2366", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя58", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия3", null, "Отчество90", null, null, null, null, null, null, null, null, 3, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "БИ", 0, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "2548", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя93", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия67", null, "Отчество37", null, null, null, null, null, null, null, null, 4, false, "Московский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "2730", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя4", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия51", null, "Отчество18", null, null, null, null, null, null, null, null, 2, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 3, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "2912", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя54", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия47", null, "Отчество33", null, null, null, null, null, null, null, null, 3, false, "Московский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "3094", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя50", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия16", null, "Отчество21", null, null, null, null, null, null, null, null, 0, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ИВТ", 1, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "3276", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя17", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия82", null, "Отчество29", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ИВТ", 1, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "3458", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя1", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия48", null, "Отчество28", null, null, null, null, null, null, null, null, 2, false, "Московский", null, null, null, false, false, false, false, false, false, "МАТ", 3, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "3640", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя48", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия97", null, "Отчество9", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ИВТ", 2, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "3822", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя5", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия92", null, "Отчество39", null, null, null, null, null, null, null, null, 1, false, "Тульский", null, null, null, false, false, false, false, false, false, "МАТ", 3, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "4004", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя49", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия78", null, "Отчество88", null, null, null, null, null, null, null, null, 1, false, "Московский", null, null, null, false, false, false, false, false, false, "БИ", 2, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "2184", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя66", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия88", null, "Отчество90", null, null, null, null, null, null, null, null, 2, false, "Московский", null, null, null, false, false, false, false, false, false, "МАТ", 3, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "27eb1f91-9458-40ba-b403-676c1f25efa4", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя41", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия12", null, "Отчество86", null, null, null, null, null, null, null, null, 2, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "8918", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя19", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия46", null, "Отчество39", null, null, null, null, null, null, null, null, 3, false, "Московский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "c8374f8a-6204-4af6-99f0-8da188f3b434", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя9", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия40", null, "Отчество99", null, null, null, null, null, null, null, null, 4, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 1, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "ac4aecdf-36b8-444f-8627-ff0d8239f668", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя24", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия28", null, "Отчество69", null, null, null, null, null, null, null, null, 2, false, "Московский", null, null, null, false, false, false, false, false, false, "МАТ", 3, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "3184f34e-a7dc-438f-8902-82466a9fde86", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя87", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия51", null, "Отчество22", null, null, null, null, null, null, null, null, 4, false, "Московский", null, null, null, false, false, false, false, false, false, "МАТ", 1, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "e4789e2b-320a-48fb-a1eb-ccf826f2996e", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя11", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия38", null, "Отчество60", null, null, null, null, null, null, null, null, 2, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "БИ", 0, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "95841562-bcd2-456c-8fcf-7e4777eca99e", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя63", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия30", null, "Отчество87", null, null, null, null, null, null, null, null, 0, false, "Московский", null, null, null, false, false, false, false, false, false, "МАТ", 2, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "7c60029d-f008-4569-9ccd-fcd9575bdfb8", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя97", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия34", null, "Отчество65", null, null, null, null, null, null, null, null, 2, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ЕНА", 2, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "b4beb548-402d-4761-affb-0e6c5a890b8b", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя33", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия28", null, "Отчество93", null, null, null, null, null, null, null, null, 2, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "3511ec37-c146-4236-9792-e5172ca93e5e", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя6", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия62", null, "Отчество15", null, null, null, null, null, null, null, null, 0, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 0, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "2cb63272-b7fa-4fb4-98eb-e02a8eb040d3", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя70", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия69", null, "Отчество84", null, null, null, null, null, null, null, null, 0, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ИВТ", 2, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "67c62013-019a-4562-ad89-785ff482f187", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя50", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия47", null, "Отчество32", null, null, null, null, null, null, null, null, 4, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "98433c85-fa53-4185-8a17-d7520c3dccfa", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя86", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия88", null, "Отчество22", null, null, null, null, null, null, null, null, 1, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ИВТ", 2, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "78fba97a-47f6-4e9a-b60a-e52989c7be41", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя85", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия48", null, "Отчество18", null, null, null, null, null, null, null, null, 4, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ИВТ", 3, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "6752daae-cfc9-4d05-8990-f30220901ba2", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя15", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия58", null, "Отчество25", null, null, null, null, null, null, null, null, 1, false, "Московский", null, null, null, false, false, false, false, false, false, "ЕНА", 0, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "b6a435a4-6917-42d8-8e0b-0104b3ce47d9", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя15", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия31", null, "Отчество25", null, null, null, null, null, null, null, null, 3, false, "Московский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "c34b753e-089c-42ac-a7fb-7233776f7c69", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя67", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия99", null, "Отчество99", null, null, null, null, null, null, null, null, 4, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 3, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "1eda5584-1aaf-4583-843a-11b1fbfd60fb", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя35", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия27", null, "Отчество26", null, null, null, null, null, null, null, null, 2, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "e57d1f3f-9e10-4ea8-801b-e627d8949e61", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя53", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия53", null, "Отчество1", null, null, null, null, null, null, null, null, 0, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ИВТ", 1, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "c74c02c5-c911-4a43-a30e-a8ebcde0f1dc", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя61", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия6", null, "Отчество92", null, null, null, null, null, null, null, null, 4, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 2, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "01665892-cb28-42d7-876a-a847a2f74c69", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя79", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия4", null, "Отчество55", null, null, null, null, null, null, null, null, 4, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "8842fa26-183c-4a4d-a52a-67c099808f91", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя75", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия37", null, "Отчество44", null, null, null, null, null, null, null, null, 0, false, "Московский", null, null, null, false, false, false, false, false, false, "ЕНА", 0, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "88cdc77c-b616-4a50-a334-a91b79ad537c", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя78", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия89", null, "Отчество66", null, null, null, null, null, null, null, null, 2, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 2, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "dcba47e9-5af5-4476-9ba2-f30ec01cc21d", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя93", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия53", null, "Отчество29", null, null, null, null, null, null, null, null, 1, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ЕНА", 0, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "29db49f4-d444-4162-a05e-34192c899c46", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя76", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия95", null, "Отчество6", null, null, null, null, null, null, null, null, 3, false, "Московский", null, null, null, false, false, false, false, false, false, "МАТ", 2, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "c82b9f57-e17c-4351-aa9d-725306ffc549", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя43", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия69", null, "Отчество16", null, null, null, null, null, null, null, null, 1, false, "Московский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "ff756c52-9a01-4fa7-8ef3-4f4c21d31e78", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя3", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия75", null, "Отчество27", null, null, null, null, null, null, null, null, 1, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ЕНА", 3, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "c6901923-0a9f-4f03-85d5-d27b5fe42ef0", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя90", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия99", null, "Отчество26", null, null, null, null, null, null, null, null, 2, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 1, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "f81669b0-18f9-4c7a-936b-2a1c26bde626", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя53", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия35", null, "Отчество5", null, null, null, null, null, null, null, null, 2, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ИВТ", 1, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "48092858-bff5-4396-a6e4-882df81a5648", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя80", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия8", null, "Отчество69", null, null, null, null, null, null, null, null, 0, false, "Тульский", null, null, null, false, false, false, false, false, false, "БИ", 3, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "cf678616-fb0a-4964-9aed-bdea6941813e", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя26", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия13", null, "Отчество83", null, null, null, null, null, null, null, null, 1, false, "Красногорский", null, null, null, false, false, false, false, false, false, "МАТ", 2, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "4e50b56d-a049-486d-b57f-cdb9fb66c6e2", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя14", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия45", null, "Отчество57", null, null, null, null, null, null, null, null, 2, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "МАТ", 1, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "059c8932-e93b-4f8a-9469-743fef3d3bf3", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя85", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия80", null, "Отчество59", null, null, null, null, null, null, null, null, 1, false, "Тульский", null, null, null, false, false, false, false, false, false, "БИ", 3, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "803ae126-8a5a-4617-800b-59c97bfb7096", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя73", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия82", null, "Отчество26", null, null, null, null, null, null, null, null, 1, false, "Московский", null, null, null, false, false, false, false, false, false, "МАТ", 2, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "f8889019-1744-4e6d-91a6-de051a8eb211", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя99", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия91", null, "Отчество96", null, null, null, null, null, null, null, null, 0, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ИВТ", 2, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "9ddb8e5d-89cf-41f9-812b-4356c98af678", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя12", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия52", null, "Отчество95", null, null, null, null, null, null, null, null, 4, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "БИ", 2, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "46dbb99a-968d-4874-b233-7f83ccebca61", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя59", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия31", null, "Отчество81", null, null, null, null, null, null, null, null, 2, false, "Тульский", null, null, null, false, false, false, false, false, false, "БИ", 2, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "89e600b4-2fb1-4461-9ff4-092124e318b4", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя76", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия94", null, "Отчество60", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "МАТ", 3, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "2f402a76-dd4e-4ab1-b184-f52b9c8d4cc4", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя14", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия90", null, "Отчество44", null, null, null, null, null, null, null, null, 2, false, "Московский", null, null, null, false, false, false, false, false, false, "БИ", 2, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "497efcec-e65c-42bb-b23f-4d513c1ce91d", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя76", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия4", null, "Отчество43", null, null, null, null, null, null, null, null, 1, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ИВТ", 2, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "7af860ab-be17-45df-b0aa-ae21a6ec9412", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя93", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия53", null, "Отчество71", null, null, null, null, null, null, null, null, 2, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 1, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "4552d147-930e-444c-8712-c4abc49756f8", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя50", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия41", null, "Отчество45", null, null, null, null, null, null, null, null, 4, false, "Тульский", null, null, null, false, false, false, false, false, false, "ЕНА", 0, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "edbf7d1e-6d13-477a-a98b-a5d684c225e4", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя89", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия15", null, "Отчество37", null, null, null, null, null, null, null, null, 3, false, "Московский", null, null, null, false, false, false, false, false, false, "БИ", 1, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "874d5141-28f1-4f03-b8fe-c6717d816625", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя81", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия17", null, "Отчество76", null, null, null, null, null, null, null, null, 3, false, "Московский", null, null, null, false, false, false, false, false, false, "ИВТ", 3, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "4b57d9a8-8603-4a12-b1e8-00f196bca813", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя61", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия98", null, "Отчество39", null, null, null, null, null, null, null, null, 1, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ИВТ", 1, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "7e509527-289a-425f-8c6b-59df242c3b1a", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя38", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия3", null, "Отчество8", null, null, null, null, null, null, null, null, 0, false, "Тульский", null, null, null, false, false, false, false, false, false, "БИ", 0, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "e343aac8-54f2-45ab-ba81-0ebc694962d0", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя20", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия23", null, "Отчество13", null, null, null, null, null, null, null, null, 4, false, "Тульский", null, null, null, false, false, false, false, false, false, "БИ", 2, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "55cc0ed3-0e37-41fd-abb3-c6ad62ca3080", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя91", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия39", null, "Отчество76", null, null, null, null, null, null, null, null, 1, false, "Московский", null, null, null, false, false, false, false, false, false, "МАТ", 0, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "ecfe09a2-57fd-40f2-b70d-d0ed15744fe4", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя62", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия54", null, "Отчество31", null, null, null, null, null, null, null, null, 4, false, "Тульский", null, null, null, false, false, false, false, false, false, "БИ", 3, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "ee48ca23-6313-4581-b981-4642704dcf32", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя14", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия70", null, "Отчество90", null, null, null, null, null, null, null, null, 2, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 3, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "8736", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя95", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия22", null, "Отчество43", null, null, null, null, null, null, null, null, 4, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "МАТ", 3, "4", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "e5be1d01-7bac-4557-bd1e-04c4def1a990", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя68", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия96", null, "Отчество37", null, null, null, null, null, null, null, null, 1, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "МАТ", 1, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "f8b85a14-cba3-4d44-9c97-b9aa7c5b983b", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя57", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия3", null, "Отчество16", null, null, null, null, null, null, null, null, 4, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 3, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "4053d405-cdc9-4af5-bf08-d20f6817e729", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя10", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия37", null, "Отчество77", null, null, null, null, null, null, null, null, 2, false, "Московский", null, null, null, false, false, false, false, false, false, "МАТ", 2, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "561c3f50-9d52-4da5-b126-32413898ffea", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя45", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия23", null, "Отчество85", null, null, null, null, null, null, null, null, 3, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 3, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "e656aa36-f714-452f-99e6-b470ccd2098a", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя51", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия18", null, "Отчество34", null, null, null, null, null, null, null, null, 1, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 1, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "a2cdd84a-ae71-4e81-b217-777dd6280d35", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя7", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия42", null, "Отчество92", null, null, null, null, null, null, null, null, 2, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 0, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "b18afa71-54bb-4f5d-a88f-094dea892c58", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя55", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия69", null, "Отчество14", null, null, null, null, null, null, null, null, 2, false, "Тульский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "a69a7f0d-cc3e-4cd4-a80f-81e196f4dbed", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя12", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия80", null, "Отчество78", null, null, null, null, null, null, null, null, 1, false, "Тульский", null, null, null, false, false, false, false, false, false, "ЕНА", 3, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "58f85f02-b324-402f-b23c-58b5bd018ca1", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя14", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия89", null, "Отчество33", null, null, null, null, null, null, null, null, 4, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ИВТ", 2, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "a506db17-b243-401f-b31a-6b8db19958b2", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя8", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия44", null, "Отчество22", null, null, null, null, null, null, null, null, 4, false, "Тульский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "a3cc3dad-a844-42c8-89a6-0b187a227135", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя64", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия64", null, "Отчество53", null, null, null, null, null, null, null, null, 4, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ИВТ", 3, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "4accbaa7-50d7-4ec6-9f62-38d3eb2b8b50", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя76", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия90", null, "Отчество87", null, null, null, null, null, null, null, null, 3, false, "Московский", null, null, null, false, false, false, false, false, false, "ИВТ", 2, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "8d284907-fa64-41c0-9ec0-4e02265b804f", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя18", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия95", null, "Отчество82", null, null, null, null, null, null, null, null, 1, false, "Тульский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "1f16417d-eb68-479d-981e-68794c08930f", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя83", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия57", null, "Отчество72", null, null, null, null, null, null, null, null, 4, false, "Тульский", null, null, null, false, false, false, false, false, false, "БИ", 2, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "8417a8fd-1b85-4e4a-8dad-3f1dc8daf91d", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя95", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия33", null, "Отчество16", null, null, null, null, null, null, null, null, 1, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 0, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "c9fe2a7c-522c-4114-9a2f-01a97fe30fef", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя95", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия50", null, "Отчество27", null, null, null, null, null, null, null, null, 4, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 2, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "c96a20f9-fa55-413e-b39a-c36798c2b3ef", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя68", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия66", null, "Отчество57", null, null, null, null, null, null, null, null, 3, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 0, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "2aa74cff-66ed-4052-a248-f88b219ca77d", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя44", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия13", null, "Отчество39", null, null, null, null, null, null, null, null, 1, false, "Московский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "6605181b-8b87-43e7-801e-3aca5e175d3f", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя99", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия28", null, "Отчество17", null, null, null, null, null, null, null, null, 2, false, "Красногорский", null, null, null, false, false, false, false, false, false, "МАТ", 0, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "ce2aa5aa-1e3d-4de9-bc6f-0629ce83caac", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя57", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия58", null, "Отчество99", null, null, null, null, null, null, null, null, 0, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "04ba968d-c678-4016-be74-069d1d59b33c", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя77", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия11", null, "Отчество92", null, null, null, null, null, null, null, null, 4, false, "Московский", null, null, null, false, false, false, false, false, false, "ЕНА", 0, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "ad9fcc5a-e2cc-4a48-a148-3e0e735842d8", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя56", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия7", null, "Отчество48", null, null, null, null, null, null, null, null, 0, false, "Московский", null, null, null, false, false, false, false, false, false, "ЕНА", 2, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "5aa82985-31bc-4be1-ba0a-32e5f9c3f31c", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя11", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия17", null, "Отчество11", null, null, null, null, null, null, null, null, 1, false, "Московский", null, null, null, false, false, false, false, false, false, "ЕНА", 3, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "f1a346a9-1ec0-42bc-a0e2-7a625711bf6d", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя69", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия85", null, "Отчество88", null, null, null, null, null, null, null, null, 0, false, "Московский", null, null, null, false, false, false, false, false, false, "ЕНА", 3, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "0760384a-f2b5-4a59-b7a3-414d82863379", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя89", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия68", null, "Отчество13", null, null, null, null, null, null, null, null, 1, false, "Тульский", null, null, null, false, false, false, false, false, false, "БИ", 0, "1", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "b8c59ccd-a2b8-4864-a455-8c7bc60712e8", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя90", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия63", null, "Отчество49", null, null, null, null, null, null, null, null, 3, false, "Московский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "81c0ad45-2fe1-4921-88b5-33b75f13e2ae", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя75", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия67", null, "Отчество59", null, null, null, null, null, null, null, null, 4, false, "Тульский", null, null, null, false, false, false, false, false, false, "БИ", 3, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "0db60437-d4f1-4c46-bfd9-46f1b2333f6d", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя9", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия45", null, "Отчество55", null, null, null, null, null, null, null, null, 2, false, "Тульский", null, null, null, false, false, false, false, false, false, "МАТ", 1, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "ec7458d4-0f30-43b3-b364-7c484c684f1c", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя6", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия99", null, "Отчество40", null, null, null, null, null, null, null, null, 1, false, "Тульский", null, null, null, false, false, false, false, false, false, "МАТ", 1, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "a25b7ab0-cd33-49a0-8969-e29250b0ba68", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя92", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия18", null, "Отчество71", null, null, null, null, null, null, null, null, 4, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 2, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "1d022344-f810-44cf-afde-5fd33e74ed80", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя78", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия89", null, "Отчество4", null, null, null, null, null, null, null, null, 2, false, "Красногорский", null, null, null, false, false, false, false, false, false, "ЕНА", 3, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "cdeb8ebd-dfb3-42d2-88e8-8c2fb7712f9b", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя21", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия2", null, "Отчество88", null, null, null, null, null, null, null, null, 1, false, "Тульский", null, null, null, false, false, false, false, false, false, "МАТ", 2, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "a3c6c117-4225-4341-b106-983045351936", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя46", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия86", null, "Отчество63", null, null, null, null, null, null, null, null, 4, false, "Московский", null, null, null, false, false, false, false, false, false, "БИ", 2, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "3c6b850a-e2b3-4397-beea-82a0ae90be95", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя47", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия98", null, "Отчество19", null, null, null, null, null, null, null, null, 1, false, "Тульский", null, null, null, false, false, false, false, false, false, "БИ", 1, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "bd0035d7-166e-49ac-ab36-967c2d6313f7", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя46", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия84", null, "Отчество68", null, null, null, null, null, null, null, null, 2, false, "Тульский", null, null, null, false, false, false, false, false, false, "МАТ", 0, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "4f05ca4e-6446-47fb-8756-6b56014dff03", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя41", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия46", null, "Отчество13", null, null, null, null, null, null, null, null, 0, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "be54b121-7650-4976-8330-ef7bbdecc710", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя97", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия2", null, "Отчество5", null, null, null, null, null, null, null, null, 0, false, "Московский", null, null, null, false, false, false, false, false, false, "ЕНА", 2, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "3ec2141b-7691-495e-a644-3353d585416a", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя58", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия71", null, "Отчество46", null, null, null, null, null, null, null, null, 4, false, "Красногорский", null, null, null, false, false, false, false, false, false, "МАТ", 2, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "48bb7e7d-7605-436a-a7ad-0a2982055a2b", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя0", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия32", null, "Отчество37", null, null, null, null, null, null, null, null, 0, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 2, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "75f8ba66-6d0a-428f-933d-6a5c74c576ba", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя41", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия53", null, "Отчество21", null, null, null, null, null, null, null, null, 4, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ИВТ", 1, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "e3c93335-b1fa-41c0-8065-27ada765bb80", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя88", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия85", null, "Отчество52", null, null, null, null, null, null, null, null, 0, false, "Московский", null, null, null, false, false, false, false, false, false, "ЕНА", 0, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "fc1c79bc-d380-4584-b1f7-7c5fd6b5eabf", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя78", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия18", null, "Отчество42", null, null, null, null, null, null, null, null, 1, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 1, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "ff26ab18-9af7-4b6c-bc06-d6481543deac", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя45", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия62", null, "Отчество8", null, null, null, null, null, null, null, null, 2, false, "Тульский", null, null, null, false, false, false, false, false, false, "ИВТ", 0, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "e8db3bf5-905b-483f-86a4-f57f2b5ba86b", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя83", null, null, null, null, "3ВТИ-039", 4, null, "Фамилия20", null, "Отчество52", null, null, null, null, null, null, null, null, 1, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 3, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "15309aeb-d9a8-4efd-a353-efdebc871f9a", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя38", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия98", null, "Отчество96", null, null, null, null, null, null, null, null, 4, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "ЕНА", 1, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "0d3feab4-d664-4343-8bb6-368521e50a73", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя56", null, null, null, null, "3ВТИ-037", 4, null, "Фамилия67", null, "Отчество74", null, null, null, null, null, null, null, null, 3, false, "Одинцовский", null, null, null, false, false, false, false, false, false, "БИ", 3, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "4cccb703-3013-4593-a1af-b34ae0b4d673", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя19", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия88", null, "Отчество71", null, null, null, null, null, null, null, null, 0, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 1, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "a9bbc1c8-d8ff-4296-8b84-32bcf7da6f38", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя41", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия31", null, "Отчество6", null, null, null, null, null, null, null, null, 4, false, "Московский", null, null, null, false, false, false, false, false, false, "МАТ", 3, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "491eaa15-e413-49ef-b78c-0840d7fd303e", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя82", null, null, null, null, "3ВТИ-042", 4, null, "Фамилия48", null, "Отчество78", null, null, null, null, null, null, null, null, 3, false, "Московский", null, null, null, false, false, false, false, false, false, "МАТ", 1, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "AssesmentId", "AvarageScore", "Birthday", "BloodType", "CapSize", "Citizenship", "ClothihgSize", "Collness", "ConditionsOfEducation", "DateOfOrder", "Exhortation", "Faculty", "FamiliStatys", "Fighting", "FirstName", "ForeignLanguage", "Growth", "HomePhone", "ImagePath", "InstGroup", "Kurs", "LanguageRank", "LastName", "MaskSize", "MiddleName", "Military", "MobilePhone", "Nationality", "Note", "NumberOfOrder", "PlaceBirthday", "PlaceOfRegestration", "PlaceOfResidence", "Position", "ProjectOrder", "Rectal", "SboryTroopId", "School", "ShoeSize", "Skill1", "Skill2", "Skill3", "Skill4", "Skill5", "Skill6", "SpecInst", "Status", "TroopId", "Two_MobilePhone", "VO", "WhoseOrder", "YearOfAddMAI", "YearOfAddVK", "YearOfEndMAI", "YearOfEndVK", "Zapas" },
                values: new object[] { "c543d22d-83ee-48cd-a1b0-997392f0a338", null, null, null, null, null, null, null, "Студент", null, null, false, null, null, "не участвовал", "Имя74", null, null, null, null, "3ВТИ-040", 4, null, "Фамилия62", null, "Отчество78", null, null, null, null, null, null, null, null, 0, false, "Красногорский", null, null, null, false, false, false, false, false, false, "БИ", 3, "2", null, "МВО", "МО РФ", null, null, null, null, false });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "CategoryId", "Name", "Type", "URI" },
                values: new object[] { "2", "5", "Шаблон 2", 1, "templates\\Справка о командировке.docx" });

            migrationBuilder.InsertData(
                table: "Templates",
                columns: new[] { "Id", "CategoryId", "Name", "Type", "URI" },
                values: new object[] { "1", "3", "Шаблон 1", 0, "templates\\Характеристика.docx" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "f78e827e-13df-4a46-87b4-0df3e4cdd5be", null, "Имя15", null, "Фамилия39", null, "Отчество13", null, null, null, null, "9100" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "82f636ef-5c57-4d46-a81c-8c71217cdc33", null, "Имя20", null, "Фамилия29", null, "Отчество26", null, null, null, null, "4004" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "1caaf16c-6999-408f-ab56-0dcd35deaa9a", null, "Имя8", null, "Фамилия24", null, "Отчество25", null, null, null, null, "3822" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "531dd6d4-77d4-40f4-833a-14bfe43dd799", null, "Имя24", null, "Фамилия8", null, "Отчество30", null, null, null, null, "3640" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "8f7f11e2-9aaa-4713-aa61-7a8954d3ad40", null, "Имя92", null, "Фамилия38", null, "Отчество8", null, null, null, null, "3458" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "a941b1f5-ff7e-4865-8bff-5790d9321f0f", null, "Имя17", null, "Фамилия42", null, "Отчество44", null, null, null, null, "3276" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "37b89227-fb78-4c51-9382-243a6c9b1cb6", null, "Имя96", null, "Фамилия8", null, "Отчество75", null, null, null, null, "3094" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "a1b593bb-ad16-4ad7-9939-9ddb904a086c", null, "Имя25", null, "Фамилия10", null, "Отчество31", null, null, null, null, "2912" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "c893b807-5476-4b78-9b22-68f3a46884c8", null, "Имя8", null, "Фамилия2", null, "Отчество34", null, null, null, null, "2730" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "5d8b3fb3-d53f-47d1-ba04-b9f9ab972fcd", null, "Имя76", null, "Фамилия18", null, "Отчество91", null, null, null, null, "2548" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "8c3e5a6d-46f1-4aa0-8912-401d1a3a39d1", null, "Имя29", null, "Фамилия89", null, "Отчество53", null, null, null, null, "2366" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "7741c52f-73b7-46be-9dc4-254fb538fe75", null, "Имя0", null, "Фамилия96", null, "Отчество89", null, null, null, null, "2184" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "3b830bf5-5786-4184-add8-74e2bb9c3d33", null, "Имя5", null, "Фамилия8", null, "Отчество26", null, null, null, null, "2002" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "c5921b68-98f1-4deb-8b1f-62834ac98074", null, "Имя21", null, "Фамилия24", null, "Отчество73", null, null, null, null, "1820" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "084ddb6b-607c-4a01-b678-fcd360f9a13d", null, "Имя67", null, "Фамилия57", null, "Отчество85", null, null, null, null, "1638" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "478539e5-0e81-4550-a867-f708afcbf24d", null, "Имя63", null, "Фамилия14", null, "Отчество15", null, null, null, null, "1456" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "b08ef647-1400-4479-a849-80eb365d3b5f", null, "Имя87", null, "Фамилия43", null, "Отчество69", null, null, null, null, "1274" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "41edc6d3-59bd-4fcb-8ca8-434038aeabec", null, "Имя94", null, "Фамилия19", null, "Отчество22", null, null, null, null, "1092" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "0cb75d50-7211-455d-8bb5-1bdf7b53bbaf", null, "Имя20", null, "Фамилия53", null, "Отчество21", null, null, null, null, "910" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "4036aad2-e658-4c34-8745-6d39d4ecb0d0", null, "Имя35", null, "Фамилия35", null, "Отчество13", null, null, null, null, "728" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "86f5cc13-b797-42a0-b5fa-50d4615fa24a", null, "Имя46", null, "Фамилия50", null, "Отчество93", null, null, null, null, "546" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "ca0cec07-4e69-4bd5-8990-3a8e0f114ac1", null, "Имя75", null, "Фамилия87", null, "Отчество93", null, null, null, null, "364" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "ccda3ce1-0b9d-498d-b1bf-913ef8fde47d", null, "Имя86", null, "Фамилия20", null, "Отчество57", null, null, null, null, "4186" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "1ac63e3c-b9d9-4907-9a32-49be00eff586", null, "Имя2", null, "Фамилия23", null, "Отчество40", null, null, null, null, "182" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "edbcd078-710a-496f-af04-1ba8aebf0abc", null, "Имя32", null, "Фамилия64", null, "Отчество29", null, null, null, null, "4368" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "4b525e5c-43f4-4d30-8db5-f1f610768566", null, "Имя78", null, "Фамилия55", null, "Отчество11", null, null, null, null, "4732" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "738fbd93-d7e6-437f-9401-24a78d54478c", null, "Имя71", null, "Фамилия51", null, "Отчество41", null, null, null, null, "8554" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "ac354430-e1c2-49e4-ad53-e7d791ee48a3", null, "Имя56", null, "Фамилия79", null, "Отчество61", null, null, null, null, "8372" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "88a78922-3811-4b4c-8cb3-2ea845f5410e", null, "Имя38", null, "Фамилия73", null, "Отчество2", null, null, null, null, "8190" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "411f8e35-477a-46c8-a543-d40d94a84761", null, "Имя31", null, "Фамилия12", null, "Отчество66", null, null, null, null, "8008" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "fd577220-e0bc-498b-b44e-03a45bc2633a", null, "Имя47", null, "Фамилия46", null, "Отчество41", null, null, null, null, "7826" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "5eeae9e6-77b8-4c1f-94a7-eeff0b4c040b", null, "Имя99", null, "Фамилия51", null, "Отчество59", null, null, null, null, "7644" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "86fcccf3-9ead-4bf5-b3a0-30b8e0589522", null, "Имя60", null, "Фамилия3", null, "Отчество11", null, null, null, null, "7462" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "d341055d-9345-4807-b31a-53570d9c271d", null, "Имя9", null, "Фамилия21", null, "Отчество40", null, null, null, null, "7280" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "62c14d27-1a76-45d7-aa31-abc379d81d98", null, "Имя83", null, "Фамилия54", null, "Отчество99", null, null, null, null, "7098" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "39e97fdb-23ff-405d-a7a9-8b9e4b976555", null, "Имя97", null, "Фамилия42", null, "Отчество66", null, null, null, null, "6916" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "07e7b7fd-d820-4ec0-b97f-4da69be20b22", null, "Имя19", null, "Фамилия14", null, "Отчество83", null, null, null, null, "6734" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "408fd0e0-4dcb-4cd4-b89a-6811cbe30fd6", null, "Имя46", null, "Фамилия47", null, "Отчество32", null, null, null, null, "6552" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "ced691f3-4a56-47d4-9dcc-25cc5e00a69b", null, "Имя74", null, "Фамилия63", null, "Отчество43", null, null, null, null, "6370" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "fbf93aa4-9a2f-4493-830c-23682a46134d", null, "Имя7", null, "Фамилия38", null, "Отчество90", null, null, null, null, "6188" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "0e808f53-2565-461f-93e3-17038fb698f1", null, "Имя65", null, "Фамилия88", null, "Отчество73", null, null, null, null, "6006" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "15d4cf4d-c47f-4bb0-8973-341cd92c220f", null, "Имя22", null, "Фамилия68", null, "Отчество93", null, null, null, null, "5824" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "94d373ff-0a0f-4ded-9d8e-019468729d53", null, "Имя80", null, "Фамилия5", null, "Отчество81", null, null, null, null, "5642" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "d99120c5-a5ed-49e5-af79-4a74f45a6ece", null, "Имя82", null, "Фамилия8", null, "Отчество57", null, null, null, null, "5460" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "3b29f506-98c2-4c7f-a49a-c0d115f31cfc", null, "Имя98", null, "Фамилия88", null, "Отчество65", null, null, null, null, "5278" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "48d8de11-50c9-421c-b834-a43178fa0112", null, "Имя53", null, "Фамилия25", null, "Отчество15", null, null, null, null, "5096" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "e26b3de8-2565-4be3-b81b-d14ad240cfed", null, "Имя81", null, "Фамилия41", null, "Отчество46", null, null, null, null, "4914" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "719d5a82-cacf-4d55-897a-ec866d3454d6", null, "Имя69", null, "Фамилия10", null, "Отчество24", null, null, null, null, "4550" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "2e80b77d-1148-40a0-b5df-1223200d8a5c", null, "Имя29", null, "Фамилия87", null, "Отчество62", null, null, null, null, "0" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "98f1369e-91ad-44e4-b8e4-79bf908de79e", null, "Имя17", null, "Фамилия69", null, "Отчество22", null, null, null, null, "18018" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "13d40d00-2fdb-490d-b3df-310ff1226dfc", null, "Имя23", null, "Фамилия32", null, "Отчество19", null, null, null, null, "17836" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "34ef9832-bb8d-4b5a-80f3-c8618a6b057f", null, "Имя95", null, "Фамилия61", null, "Отчество49", null, null, null, null, "12922" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "269fb225-e5d1-4791-aa4e-ea28000626ea", null, "Имя96", null, "Фамилия32", null, "Отчество19", null, null, null, null, "12740" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "854d8005-3b16-4f11-b095-176e4d751776", null, "Имя39", null, "Фамилия55", null, "Отчество18", null, null, null, null, "12558" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "aa9a529c-8e18-4a91-a079-4bdf6ec07bea", null, "Имя92", null, "Фамилия52", null, "Отчество12", null, null, null, null, "12376" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "b48022ce-5b4c-48f1-977d-f572d60aada8", null, "Имя92", null, "Фамилия57", null, "Отчество24", null, null, null, null, "12194" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "deefaa79-e0c7-4d2a-98ab-835b3e205a0a", null, "Имя40", null, "Фамилия42", null, "Отчество76", null, null, null, null, "12012" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "bd45f0e7-f706-4c57-ad3e-3da5a92782c8", null, "Имя48", null, "Фамилия87", null, "Отчество53", null, null, null, null, "11830" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "ebda5deb-6904-4c6b-821d-b04ef69e002e", null, "Имя67", null, "Фамилия77", null, "Отчество5", null, null, null, null, "11648" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "f0ef09a3-b75e-42b3-9601-14e1dfb35625", null, "Имя99", null, "Фамилия6", null, "Отчество26", null, null, null, null, "11466" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "eb2c2c3b-c809-418a-9f6a-19363c5d8236", null, "Имя28", null, "Фамилия37", null, "Отчество56", null, null, null, null, "11284" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "4c18876a-c322-4660-aed6-2addbdb8ade5", null, "Имя97", null, "Фамилия32", null, "Отчество7", null, null, null, null, "11102" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "2574f647-e76a-4e2c-91ed-9ea1e5aca0dd", null, "Имя17", null, "Фамилия25", null, "Отчество67", null, null, null, null, "10920" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "4aeab196-1d01-445a-b6e7-19c4608e1d35", null, "Имя99", null, "Фамилия27", null, "Отчество39", null, null, null, null, "10738" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "1fdf20b5-8891-4aec-90e7-8954bfa2cbfb", null, "Имя38", null, "Фамилия37", null, "Отчество70", null, null, null, null, "10556" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "9d345a36-ffef-4d9e-b592-50bbebb6e397", null, "Имя63", null, "Фамилия27", null, "Отчество74", null, null, null, null, "10374" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "24a9e3b9-7ed3-4f88-894d-896f4ec4d8f3", null, "Имя17", null, "Фамилия58", null, "Отчество69", null, null, null, null, "10192" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "a90b0e50-bd94-41cd-a1cd-41c070bd198e", null, "Имя90", null, "Фамилия87", null, "Отчество1", null, null, null, null, "10010" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "be1478b0-86a4-4ba1-a391-f531820584cf", null, "Имя84", null, "Фамилия98", null, "Отчество1", null, null, null, null, "9828" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "b78d2cc9-01fc-438e-ac10-1a012c6cfb70", null, "Имя78", null, "Фамилия74", null, "Отчество12", null, null, null, null, "9646" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "4fe900bd-f8f5-4c8d-b495-f8ccfd0d108c", null, "Имя32", null, "Фамилия46", null, "Отчество35", null, null, null, null, "9464" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "e4ab4f18-81e8-42be-bca8-153d8bf7fad6", null, "Имя93", null, "Фамилия56", null, "Отчество66", null, null, null, null, "9282" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "8ae26445-cb0f-41b4-a895-d973f4993f7b", null, "Имя44", null, "Фамилия87", null, "Отчество65", null, null, null, null, "13104" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "754c8773-56ff-469b-9206-23106962e614", null, "Имя93", null, "Фамилия62", null, "Отчество49", null, null, null, null, "13286" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "005b7083-9339-4051-91aa-575354fb5860", null, "Имя45", null, "Фамилия17", null, "Отчество52", null, null, null, null, "13468" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "e58fd70e-9bdc-4858-96b7-3a71fdc6f35d", null, "Имя43", null, "Фамилия95", null, "Отчество49", null, null, null, null, "13650" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "b38ebdff-60eb-4bce-bb91-fbda88f207cd", null, "Имя28", null, "Фамилия70", null, "Отчество54", null, null, null, null, "17654" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "5d0d7069-c1ac-4ef2-ba17-50e103c4c290", null, "Имя4", null, "Фамилия37", null, "Отчество77", null, null, null, null, "17472" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "0a64e74c-d4b2-4c2c-8ef9-38d9b63ca59a", null, "Имя49", null, "Фамилия28", null, "Отчество12", null, null, null, null, "17290" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "4d27877d-2927-4a3d-83b8-7b79d3d5e522", null, "Имя33", null, "Фамилия13", null, "Отчество86", null, null, null, null, "17108" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "ee332295-c568-472e-9bbe-b9f3dec3536a", null, "Имя78", null, "Фамилия36", null, "Отчество23", null, null, null, null, "16926" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "bb3762e5-2d68-476e-8a32-f1a9a9ae60f3", null, "Имя67", null, "Фамилия8", null, "Отчество15", null, null, null, null, "16744" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "4f2b7a13-f266-4832-b5a0-592179852084", null, "Имя85", null, "Фамилия98", null, "Отчество73", null, null, null, null, "16562" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "23d1df9c-620c-436b-a949-41c81fa9af50", null, "Имя81", null, "Фамилия1", null, "Отчество82", null, null, null, null, "16380" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "2545d0e7-e6a2-46d9-bbfe-4d26a777755b", null, "Имя34", null, "Фамилия31", null, "Отчество36", null, null, null, null, "16198" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "e24ddabe-74f4-4dc9-a047-0be224d1b1f3", null, "Имя68", null, "Фамилия80", null, "Отчество73", null, null, null, null, "16016" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "c83aa1f1-8fbf-4554-8725-c768018490a1", null, "Имя33", null, "Фамилия63", null, "Отчество94", null, null, null, null, "8736" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "6605f89e-e3c2-45ff-a2dc-a0d30c621fb6", null, "Имя62", null, "Фамилия69", null, "Отчество64", null, null, null, null, "15834" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "4f690d88-bb0f-4821-8e61-8e8c1d2699d7", null, "Имя26", null, "Фамилия46", null, "Отчество39", null, null, null, null, "15470" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "edff371f-c2db-4913-baf1-2c8f03662001", null, "Имя87", null, "Фамилия46", null, "Отчество80", null, null, null, null, "15288" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "9cd8c48c-3ae2-441d-a220-debdc6d48414", null, "Имя55", null, "Фамилия3", null, "Отчество0", null, null, null, null, "15106" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "4ab58fa1-895c-42f0-953c-c52f2cce86a7", null, "Имя7", null, "Фамилия72", null, "Отчество16", null, null, null, null, "14924" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "03dcc99e-e42d-43f8-a57a-70ef087d507b", null, "Имя37", null, "Фамилия2", null, "Отчество73", null, null, null, null, "14742" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "9b11a7e1-3685-434d-b190-1707fe526598", null, "Имя94", null, "Фамилия88", null, "Отчество82", null, null, null, null, "14560" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "9179f9ed-33f3-4d75-9322-f39cf6c19680", null, "Имя43", null, "Фамилия4", null, "Отчество80", null, null, null, null, "14378" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "7c86c7f4-3883-44e2-af18-c0ce815432dc", null, "Имя63", null, "Фамилия24", null, "Отчество68", null, null, null, null, "14196" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "89c95ba5-208b-43b9-95cc-b97e30f9d2fd", null, "Имя16", null, "Фамилия59", null, "Отчество84", null, null, null, null, "14014" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "ee80ea62-96d9-49b6-be72-c0b659068192", null, "Имя69", null, "Фамилия90", null, "Отчество50", null, null, null, null, "13832" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "16e74178-1e0f-437d-b2fc-ed56bf9b81e8", null, "Имя72", null, "Фамилия49", null, "Отчество56", null, null, null, null, "15652" });

            migrationBuilder.InsertData(
                table: "Relatives",
                columns: new[] { "Id", "Birthday", "FirstName", "HealthStatus", "LastName", "MaidenName", "MiddleName", "MobilePhone", "PlaceOfRegestration", "PlaceOfResidence", "RelationDegree", "StudentId" },
                values: new object[] { "938b4d26-955f-42ac-a727-20d213754fda", null, "Имя74", null, "Фамилия83", null, "Отчество62", null, null, null, null, "8918" });

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
