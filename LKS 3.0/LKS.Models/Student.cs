using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace LKS.Models
{
	public enum Student_Rank
	{
		Командир_взвода = 1,
		Заместитель_КВ,
		КО1,
		КО2,
		КО3,
		Журналист,
		Заместитель_журналиста,
		Студент
	}

	public enum Assessment
	{
		неудовлетв = 2,
		удовлетв,
		хорошо,
		отлично
	}

	public class Student
	{
		public Student() // Конструктор по умолчанию
		{
			//Разве по умолчанию не false?
			// Skill1 = false;
			// Skill2 = false;
			// Skill3 = false;
			// Skill4 = false;
			// Skill5 = false;
			// Skill6 = false;
			// Exhortation = false;
			
			// Зачем???
			 Birthday = "";

			Zapas = true;
			ProjectOrder = true;
			Rank = Troop.Rank[0];

			//подумать где это должно быть
			WhoseOrder = "МО РФ";
			VO = "МВО";
			Fighting = "не участвовал";

			//Перенес в сущность "цикл"
			//VUS = "042600";
			// VuzName = "МОСКОВСКИЙ АВИАЦИОННЫЙ ИНСТИТУТ (национальный исследовательский университет)(МАИ)";
			// VkName = "Военная кафедра \"МОСКОВСКИЙ АВИАЦИОННЫЙ ИНСТИТУТ (национальный исследовательский университет)\"(МАИ)";
			//SpecialityName = "Боевое применение частей и подразделений войсковой ПВО";
		}

		public string Initials
		{
			get
			{
				return MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";
			}
		}
		[Key]
		public string Id { get; set; }
		public virtual List<Relative> Relatives { get; set; }
		[ForeignKey(nameof(Troop))]
		public string TroopId { get; set; }
		public Troop Troop { get; set; }
		[DisplayName("Звание")]
		public string Collness { get; set; }

		[DisplayName("Фамилия")]
		public string MiddleName { get; set; }

		[DisplayName("Имя")]
		public string FirstName { get; set; }

		[DisplayName("Отчество")]
		public string LastName { get; set; }

		[DisplayName("Взвод")]
		public string NumTroop { get; set; }

		[DisplayName("Должность")]
		public string Rank { get; set; }


		//public string SpecialityName { get; set; } // МБ убрать это из студента(она всеравно константна)
		//да, я убрал в цикл

		[DisplayName("Группа")]
		public string InstGroup { get; set; }

		[DisplayName("Курс")]
		public int Kurs { get; set; }

		[DisplayName("Факультет")]
		public string Faculty { get; set; }

		[DisplayName("Специальность в ВУЗе")]
		public string SpecInst { get; set; }

		[DisplayName("Условия обучения в ВУЗе")]
		public string ConditionsOfEducation { get; set; }

		[DisplayName("Средний балл в зач.книжке")]
		public string AvarageScore { get; set; }

		[DisplayName("Год поступления в МАИ")]
		public string YearOfAddMAI { get; set; }

		[DisplayName("Год окончания МАИ")]
		public string YearOfEndMAI { get; set; }

		[DisplayName("Год поступления на ВК")]
		public string YearOfAddVK { get; set; }

		[DisplayName("Год окончания ВК")]
		public string YearOfEndVK { get; set; }

		[DisplayName("№ приказа о приеме")]
		public string NumberOfOrder { get; set; }

		[DisplayName("Дата приказа")]
		public string DateOfOrder { get; set; }

		[DisplayName("Военкомат")]
		public string Rectal { get; set; }

		[DisplayName("Дата рождения")]
		public string Birthday { get; set; }

		[DisplayName("Место рождения")]
		public string PlaceBirthday { get; set; }

		[DisplayName("Национальность")]
		public string Nationality { get; set; }

		[DisplayName("Гражданство")]
		public string Citizenship { get; set; }

		[DisplayName("Дом.телефон")]
		public string HomePhone { get; set; }

		[DisplayName("Мобильный телефон")]
		public string MobilePhonec { get; set; }

		[DisplayName("Адрес проживания")]
		public string PlaceOfResidence { get; set; }

		[DisplayName("Адрес прописки")]
		public string PlaceOfRegestration { get; set; }

		[DisplayName("Служба в ВС")]
		public string Military { get; set; }

		[DisplayName("Семейное положение")]
		public string FamiliStatys { get; set; }

		public string School { get; set; }
		public string Two_MobilePhone { get; set; }
		public string Note { get; set; }

		public string ImagePath { get; set; }
		public bool Skill1
		{ get; set; }

		public bool Skill2
		{ get; set; }

		public bool Skill3
		{ get; set; }
		public bool Skill4
		{ get; set; }

		public bool Skill5
		{ get; set; }

		public bool Skill6
		{ get; set; }

		public bool Zapas
		{ get; set; }
		public bool Exhortation
		{ get; set; }
		public bool ProjectOrder
		{ get; set; }

		public string WhoseOrder
		{ get; set; }
		public string VO
		{ get; set; }
		// public string VuzName
		// { get; set; }
		// public string VkName
		// { get; set; } ПЕРЕНЕС В ЦИКЛ
		public string Fighting
		{ get; set; }

		// public string VUS // код специальности
		// { get; set; } ПЕРЕНЕС В ЦИКЛ
		public string BloodType
		{ get; set; }

		public string Growth
		{ get; set; }

		public string ClothihgSize
		{ get; set; }

		public string ShoeSize
		{ get; set; }
		public string CapSize
		{ get; set; }

		public string MaskSize
		{ get; set; }

		public string ForeignLanguage
		{ get; set; }

		public string LanguageRank
		{ get; set; }

		public string Status
		{ get; set; }

		public int AssessmentProtocolOneTheory
		{ get; set; }

		public int AssessmentProtocolOnePractice
		{ get; set; }
		public int AssessmentProtocolOneFinal
		{ get; set; }
		public int AssessmentCharacteristicMilitaryTechnicalTraining
		{ get; set; }

		public int AssessmentCharacteristicTacticalSpecialTraining
		{ get; set; }

		public int AssessmentCharacteristicMilitarySpeialTraining
		{ get; set; }

		public int AssessmentCharacteristicFinal
		{ get; set; }
	}
}
