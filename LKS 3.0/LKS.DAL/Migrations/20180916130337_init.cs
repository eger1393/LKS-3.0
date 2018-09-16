﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace LKS.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Collness = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    NumTroop = table.Column<string>(nullable: true),
                    Rank = table.Column<string>(nullable: true),
                    SpecialityName = table.Column<string>(nullable: true),
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
                    MobilePhonec = table.Column<string>(nullable: true),
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
                    VuzName = table.Column<string>(nullable: true),
                    VkName = table.Column<string>(nullable: true),
                    Fighting = table.Column<string>(nullable: true),
                    VUS = table.Column<string>(nullable: true),
                    BloodType = table.Column<string>(nullable: true),
                    Growth = table.Column<string>(nullable: true),
                    ClothihgSize = table.Column<string>(nullable: true),
                    ShoeSize = table.Column<string>(nullable: true),
                    CapSize = table.Column<string>(nullable: true),
                    MaskSize = table.Column<string>(nullable: true),
                    ForeignLanguage = table.Column<string>(nullable: true),
                    LanguageRank = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Relatives");

            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
