using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LKS_3._0
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

	public class Student : INotifyPropertyChanged
	{
		private BindingList<Relative> relatives;
		public BindingList<Troop> Troop { get; set; } // Тоха какого хуя в студенте есть список взводов?
													  // Вот сейчас по моему всякая логика модели сдохла нахер, это вообще не нормально.

		public static int _count;

		private string imagePath;

		static private string[] assessmentEnum = { // Перевод оценок из цифр в обозначения
			"неудовлетв",
			"удовлетв",
			"хорошо",
			"отлично"
		};
		//private string assessmentProtocolOneTheory, assessmentProtocolOnePractice, assessmentProtocolOneFinal,
		//	assessmentCharacteristicMilitaryTechnicalTraining,
		//	assessmentCharacteristicTacticalSpecialTraining,
		//	assessmentCharacteristicMilitarySpeialTraining,
		//	assessmentCharacteristicFinal;

		public string Initials
		{
			get
			{
				return MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";
			}
		}

        public override string ToString()
        {
            return String.Format("{0} {1}. {2}.",
               MiddleName, FirstName[0], LastName[0]);
        }

         public string str_FIO
        {
            get
            {
                return ToString();
            }
        }


        public void Update_IdRelatives()
        {
            foreach (var item in Relatives)
            {
                item.StudentId = this.Id;
            }
        }

        public string NumberTroop()
        {
            var temp_troop = Troop.FirstOrDefault(u => u.SboriTroop == false);
            if (temp_troop != null)
            {
                return temp_troop.NumberTroop;
            }
            else
            {
                return "None";
                //return Troop.FirstOrDefault(u => u.SboriTroop == true).NumberTroop;
            }
        }

        public Student() // Конструктор по умолчанию
        {
            Skill1 = false;
            Skill2 = false;
            Skill3 = false;
            Skill4 = false;
            Skill5 = false;
            Skill6 = false;
            Zapas = true;
            Exhortation = false;
            ProjectOrder = true;
            Birthday = "";
            VUS = "042600";
            WhoseOrder = "МО РФ";
            VO = "МВО";
            Rank = " ";
            VuzName = "МОСКОВСКИЙ АВИАЦИОННЫЙ ИНСТИТУТ (национальный исследовательский университет)(МАИ)";
            VkName = "Военная кафедра \"МОСКОВСКИЙ АВИАЦИОННЫЙ ИНСТИТУТ (национальный исследовательский университет)\"(МАИ)";
            Fighting = "не участвовал";
            SpecialityName = "Боевое применение частей и подразделений войсковой ПВО";
            Troop = new BindingList<Troop>();
        }
        public Student(Troop troop) // Конструктор с выбранным взводом
        {
            Troop = new BindingList<Troop>();
            Relatives = new BindingList<Relative>();
            Troop.Add(troop);
            Rank = " ";
            Status = "Обучается";
            BloodType = "Не знаю";
            Kurs = 2;
            Birthday = "";
            Skill1 = false;
            Skill2 = false;
            Skill3 = false;
            Skill4 = false;
            Skill5 = false;
            Skill6 = false;
            Zapas = true;
            Exhortation = false;
            ProjectOrder = true;
            VUS = "042600";
            WhoseOrder = "МО РФ";
            VO = "МВО";
            VuzName = "МОСКОВСКИЙ АВИАЦИОННЫЙ ИНСТИТУТ (национальный исследовательский университет)(МАИ)";
            VkName = "Военная кафедра \"МОСКОВСКИЙ АВИАЦИОННЫЙ ИНСТИТУТ (национальный исследовательский университет)\"(МАИ)";
            SpecialityName = "Боевое применение частей и подразделений войсковой ПВО";
            Fighting = "не участвовал";
        }
		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string prop = "")
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(prop));
		}

		public int Id
        { get; set; }
        [RusName("Звание")]
        public string Collness
        { get; set; }
        [RusName("Фамилия")]
        public string MiddleName // Фамилия
        { get; set; }
        [RusName("Имя")]
        public string FirstName // Имя
        { get; set; }
        [RusName("Отчество")]
        public string LastName // Отчество
        { get; set; }
        [RusName("Взвод")]
        public string NumTroop
        {
            get
            {
                return NumberTroop();
            }
        }
        [RusName("Должность")]
        public string Rank // Звание студента (перечисление)
        { get; set; }
        public string SpecialityName // Название специальности
        { get; set; }
        [RusName("Группа")]
        public string InstGroup
        { get; set; }
        [RusName("Курс")]
        public int Kurs // факультет
        { get; set; }
        [RusName("Факультет")]
        public string Faculty // факультет
        { get; set; }

        [RusName("Специальность в ВУЗе")]
        public string SpecInst
        { get; set; }
        [RusName("Условия обучения в ВУЗе")]
        public string ConditionsOfEducation // условия обучения
        { get; set; }
        [RusName("Средний балл в зач.книжке")]
        public string AvarageScore // средний балл
        { get; set; }
        [RusName("Год поступления в МАИ")]
        public string YearOfAddMAI
        { get; set; }
        [RusName("Год окончания МАИ")]
        public string YearOfEndMAI
        { get; set; }
        [RusName("Год поступления на ВК")]
        public string YearOfAddVK
        { get; set; }
        [RusName("Год окончания ВК")]
        public string YearOfEndVK
        { get; set; }
        [RusName("№ приказа о приеме")]
        public string NumberOfOrder // номер приказа
        { get; set; }
        [RusName("Дата приказа")]
        public string DateOfOrder
        { get; set; }
        [RusName("Военкомат")]
        public string Rectal
        { get; set; }
        [RusName("Дата рождения")]
        public string Birthday // Номер мобильного телефона
        { get; set; }
        [RusName("Место рождения")]
        public string PlaceBirthday // место рождения
        { get; set; }
        [RusName("Национальность")]
        public string Nationality // национальность (перечисление)
        { get; set; }
        [RusName("Гражданство")]
        public string Citizenship // Гражданство
        { get; set; }
        [RusName("Дом.телефон")]
        public string HomePhone // Номер домашнего телефона
        { get; set; }
        [RusName("Мобильный телефон")]
        public string MobilePhone
        { get; set; }
        [RusName("Адрес проживания")]
        public string PlaceOfResidence
        { get; set; }
        [RusName("Адрес прописки")]
        public string PlaceOfRegestration
        { get; set; }
        [RusName("Служба в ВС")]
		public string Military
        { get; set; }
        [RusName("Семейное положение")]
		public string FamiliStatys
        { get; set; }
        public string School
        { get; set; }
        public string Two_MobilePhone
        { get; set; }
        public string Note
        { get; set; }
		public string FullImagePath
		{
			get
			{
				return AppDomain.CurrentDomain.BaseDirectory + ImagePath;
			}
		}
        public string ImagePath
        {
			get
			{
				return imagePath;
			}
			set
			{
				imagePath = value;
			}
		}
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
        public string VuzName
        { get; set; }
        public string VkName
        { get; set; }
        public string Fighting
        { get; set; }

        public string VUS // код специальности
        { get; set; }
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
		//{
		//	get
		//	{
		//		if (assessmentCharacteristicMilitaryTechnicalTraining.Length == 1)
		//			return assessmentEnum[Convert.ToInt32(assessmentCharacteristicMilitaryTechnicalTraining) - 2];
		//		else
		//			return "Отсутствует";
		//	}
		//	set
		//	{
		//		if (new[] { "", "2", "3", "4", "5" }.Contains(value))
		//			assessmentCharacteristicMilitaryTechnicalTraining = value;
		//		else
		//		{
		//			assessmentCharacteristicMilitaryTechnicalTraining = "";
		//			//throw new ArgumentOutOfRangeException(value, "Оценка должна быть 2, 3, 4 или 5");
		//		}
		//	}
		//}

		public int AssessmentCharacteristicTacticalSpecialTraining
		{ get; set; }

		public int AssessmentCharacteristicMilitarySpeialTraining
		{ get; set; }

		public int AssessmentCharacteristicFinal
		{ get; set; }


		public virtual BindingList<Relative> Relatives
        {
            get
            {
                return relatives;
            }

            set
            {
                relatives = value;
            }
        }

        
    }
}
