using System;
using System.Linq;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LKS_3._0
{
    /// <summary>
    /// Данные о студенте
    /// </summary>
    public class Student : INotifyPropertyChanged
    {
        private BindingList<Relative> relatives;
        public BindingList<Troop> Troop { get; set; }
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
        static private string[] assessmentEnum = { //TODO
			"неудовлетв",
            "удовлетв",
            "хорошо",
            "отлично"
        };

    
        public override string ToString()
        {
            try
            {
                return String.Format("{0} {1}. {2}.",
              MiddleName, FirstName[0], LastName[0]);
            }
            catch (NullReferenceException)
            {
                 System.Windows.MessageBox.Show("Не заполнено ФИО! Могут отсутстовать данные!\n");
                return "-1";
            }
           
        }

        public string str_FIO
        {
            get
            {
                return ToString();
            }
        }

        public string Initials
        {
            get
            {
                if (String.IsNullOrEmpty(MiddleName) || String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName))
                {
                    throw new Exception("Не заполнено ФИО! Могут отсутстовать данные!\n");
                }
                return MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";
            }
        }
        public void UpdateIdRelatives() // TODO
        {
            //foreach (var item in Relatives)
            //{
            //    item.StudentId = this.Id;
            //}
        }
        public int Id { get; set; }

        [RusName("Звание")]
        public string Collness { get; set; }

        [RusName("Фамилия")]
        public string MiddleName { get; set; }

        [RusName("Имя")]
        public string FirstName { get; set; }

        [RusName("Отчество")]
        public string LastName { get; set; }

        [RusName("Взвод")]
        public string NumTroop
        {
            get
            {
                var temp_troop = Troop.FirstOrDefault(u => u.SboriTroop == false);
                if (temp_troop != null)
                {
                    return temp_troop.NumberTroop;
                }
                else
                {
                    return "None";
                }
            }
        }

        [RusName("Должность")]
        public string Rank { get; set; }

        public bool IsSuspended { get; set; }

        [RusName("Название специальности")]
        public string SpecialityName { get; set; }

        [RusName("Группа")]
        public string InstGroup { get; set; }

        [RusName("Курс")]
        public int Kurs { get; set; }

        [RusName("Факультет")]
        public string Faculty { get; set; }

        [RusName("Специальность в ВУЗе")]
        public string SpecInst { get; set; }

        [RusName("Условия обучения в ВУЗе")]
        public string ConditionsOfEducation { get; set; }

        [RusName("Средний балл в зач.книжке")]
        public string AvarageScore { get; set; }

        [RusName("Год поступления в МАИ")]
        public string YearOfAddMAI { get; set; }

        [RusName("Год окончания МАИ")]
        public string YearOfEndMAI { get; set; }

        [RusName("Год поступления на ВК")]
        public string YearOfAddVK { get; set; }

        [RusName("Год окончания ВК")]
        public string YearOfEndVK { get; set; }

        [RusName("№ приказа о приеме")]
        public string NumberOfOrder { get; set; }

        [RusName("Дата приказа")]
        public string DateOfOrder { get; set; }

        [RusName("Военкомат")]
        public string Rectal { get; set; }

        [RusName("Дата рождения")]
        public string Birthday { get; set; }

        [RusName("Место рождения")]
        public string PlaceBirthday { get; set; }

        [RusName("Национальность")]
        public string Nationality { get; set; }

        [RusName("Гражданство")]
        public string Citizenship { get; set; }

        [RusName("Дом.телефон")]
        public string HomePhone { get; set; }

        [RusName("Мобильный телефон")]
        public string MobilePhone { get; set; }

        [RusName("Адрес проживания")]
        public string PlaceOfResidence { get; set; }

        [RusName("Адрес прописки")]
        public string PlaceOfRegestration { get; set; }
        [RusName("Служба в ВС")]
        public string Military { get; set; }

        [RusName("Семейное положение")]
        public string FamiliStatys { get; set; }

        public string School { get; set; }

        public string Two_MobilePhone { get; set; }

        public string Note { get; set; }
        /// <summary>
        /// Полный путь к файлу фотографии
        /// </summary>
        public string FullImagePath
        {
            get
            {
                return AppDomain.CurrentDomain.BaseDirectory + ImagePath;
            }
        }
        /// <summary>
        /// Относительный путь к файлу фотографии
        /// </summary>
        public string ImagePath { get; set; }
        public bool Skill1 { get; set; }

        public bool Skill2 { get; set; }

        public bool Skill3 { get; set; }
        public bool Skill4 { get; set; }

        public bool Skill5 { get; set; }

        public bool Skill6 { get; set; }

        public bool Zapas { get; set; }
        public bool Exhortation { get; set; }
        public bool ProjectOrder { get; set; }

        public string WhoseOrder { get; set; }
        public string VO { get; set; }
        public string VuzName { get; set; }
        public string VkName { get; set; }
        public string Fighting { get; set; }

        /// <summary>
        /// Код специальности
        /// </summary>
        public string VUS { get; set; }
        public string BloodType { get; set; }

        public string Growth { get; set; }

        public string ClothihgSize { get; set; }

        public string ShoeSize { get; set; }
        public string CapSize { get; set; }

        public string MaskSize { get; set; }

        public string ForeignLanguage { get; set; }

        public string LanguageRank { get; set; }

        public string Status { get; set; }

        public int AssessmentProtocolOneTheory { get; set; }

        public int AssessmentProtocolOnePractice { get; set; }
        public int AssessmentProtocolOneFinal { get; set; }
        public int AssessmentCharacteristicMilitaryTechnicalTraining { get; set; }
        public int AssessmentCharacteristicTacticalSpecialTraining { get; set; }
        public int AssessmentCharacteristicMilitarySpeialTraining { get; set; }
        public int AssessmentCharacteristicFinal { get; set; }
        public virtual BindingList<Relative> Relatives
        {
            get
            {
                return relatives;
            }

            set
            {
                relatives = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
