using LKS.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace LKS.Data.Models
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
		public Student()
		{
			//подумать где это должно быть
			WhoseOrder = "МО РФ";
			VO = "МВО";
			Fighting = "не участвовал";
		}

		public string Initials
		{
			get
			{
				return LastName + " " + FirstName[0] + ". " + MiddleName[0] + ".";
			}
		}
		[Key]
		public string Id { get; set; }
		public virtual List<Relative> Relatives { get; set; }

		[ForeignKey(nameof(Troop))]
        [DisplayName("Взвод")]
        public string TroopId { get; set; }
		public Troop Troop { get; set; }

		[DisplayName("Звание")]
		public string Collness { get; set; }

		[DisplayName("Фамилия")]
        public string LastName { get; set; }

		[DisplayName("Имя")]
        public string FirstName { get; set; }

		[DisplayName("Отчество")]
        public string MiddleName { get; set; }

		[DisplayName("Взвод")]
		public string NumTroop { get
			{
				return Troop?.NumberTroop ?? "none";
			}
		}

		[DisplayName("Должность")]
		public StudentPosition Position { get; set; }


		public string SpecialityName { get
			{
				return Troop?.Cycle?.SpecialityName ?? "none";
			}
		}


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
        public string MobilePhone { get; set; }

		[DisplayName("Адрес проживания")]
		public string PlaceOfResidence { get; set; }

		[DisplayName("Адрес прописки")]
		public string PlaceOfRegestration { get; set; }

		[DisplayName("Служба в ВС")]
		public string Military { get; set; }

		[DisplayName("Семейное положение")]
		public string FamiliStatys { get; set; }
        [DisplayName("Школа")]
        public string School { get; set; }
        [DisplayName("Доп. мобильный телефон")]
        public string Two_MobilePhone { get; set; }
		public string Note { get; set; }

		public string ImagePath { get; set; }
        [DisplayName("Языки программирования (С,С++,С#)")]
        public bool Skill1
		{ get; set; }
        [DisplayName("Microsoft Office")]
        public bool Skill2
		{ get; set; }
        [DisplayName("Adobe Photoshop")]
        public bool Skill3
		{ get; set; }
        [DisplayName("Электроника, электротехника")]
        public bool Skill4
		{ get; set; }
        [DisplayName("Настройка локальных сетей")]
        public bool Skill5
		{ get; set; }
        [DisplayName("Другие полезные навыки")]
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
        [DisplayName("Группа крови")]
        public string BloodType
		{ get; set; }
        [DisplayName("Рост")]
        public string Growth
		{ get; set; }
        [DisplayName("Размер одежды")]
        public string ClothihgSize
		{ get; set; }
        [DisplayName("Размер обуви")]
        public string ShoeSize
		{ get; set; }
        [DisplayName("Размер головного убора")]
        public string CapSize
		{ get; set; }
        [DisplayName("Размер противогаза")]
        public string MaskSize
		{ get; set; }


        [DisplayName("Иностранный язык")]
        public string ForeignLanguage
		{ get; set; }
        [DisplayName("Степень владения")]
        public string LanguageRank
		{ get; set; }

        public StudentStatus Status
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
