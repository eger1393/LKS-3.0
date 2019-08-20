using LKS.Data.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LKS.Data.Models
{
    public class Student
    {
        public Student()
        {
            //подумать где это должно быть
            WhoseOrder = "МО РФ";
            VO = "МВО";
            Fighting = "не участвовал";
            Collness = "Курсант";

        }

        public string Initials =>
        MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";

        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Родственники
        /// </summary>
        public virtual List<Relative> Relatives { get; set; }


        public string TroopId { get; set; }
        /// <summary>
        /// Взвод
        /// </summary>
        public Troop Troop { get; set; }


        public string SboriTroopId { get; set; }
        /// <summary>
        /// Взвод
        /// </summary>
        public Troop SboriTroop { get; set; }


        /// <summary>
        /// Должность
        /// </summary>
        public string Collness { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// Номер взвода
        /// </summary>
        public string NumTroop => Troop?.NumberTroop ?? "none";

        /// <summary>
        /// Должность
        /// </summary>
        public StudentPosition Position { get; set; }

        /// <summary>
        /// Статус обучения
        /// </summary>
        public StudentStatus Status
        { get; set; }

        /// <summary>
        /// Название специальности
        /// </summary>
        public string SpecialityName => Troop?.Cycle?.SpecialityName ?? "none";


        /// <summary>
        /// Группа
        /// </summary>
        public string InstGroup { get; set; }

        /// <summary>
        /// Курс
        /// </summary>
        public int Kurs { get; set; }

        /// <summary>
        /// Факультет
        /// </summary>
        public string Faculty { get; set; }

        /// <summary>
        /// Специальность в ВУЗе
        /// </summary>
        public string SpecInst { get; set; }

        /// <summary>
        /// Условия обучения в ВУЗе
        /// </summary>
        public string ConditionsOfEducation { get; set; }

        /// <summary>
        /// Средний балл зачетной книжки
        /// </summary>
        public string AvarageScore { get; set; }

        /// <summary>
        /// Год поступления в МАИ
        /// </summary>
        public string YearOfAddMAI { get; set; }

        /// <summary>
        /// Год окончания в МАИ
        /// </summary>
        public string YearOfEndMAI { get; set; }

        /// <summary>
        /// Год поступления на ВК
        /// </summary>
        public string YearOfAddVK { get; set; }

        /// <summary>
        /// Год окончания на ВК
        /// </summary>
        public string YearOfEndVK { get; set; }

        /// <summary>
        /// № приказа о приеме
        /// </summary>
        public string NumberOfOrder { get; set; }

        /// <summary>
        /// Дата приказа
        /// </summary>
        public string DateOfOrder { get; set; }

        /// <summary>
        /// Военкомат
        /// </summary>
        public string Rectal { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public string Birthday { get; set; }

        /// <summary>
        /// Место рождения
        /// </summary>
        public string PlaceBirthday { get; set; }

        /// <summary>
        /// Национальность
        /// </summary>
        public string Nationality { get; set; }

        /// <summary>
        /// Гражданство
        /// </summary>
        public string Citizenship { get; set; }

        /// <summary>
        /// Дом. телефон
        /// </summary>
        public string HomePhone { get; set; }

        /// <summary>
        /// Мобильный телефон
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Адрес проживания
        /// </summary>
        public string PlaceOfResidence { get; set; }

        /// <summary>
        /// Адрес прописки
        /// </summary>
        public string PlaceOfRegestration { get; set; }

        /// <summary>
        /// Служба в ВС
        /// </summary>
        public string Military { get; set; }

        /// <summary>
        /// Семейное положение
        /// </summary>
        public string FamiliStatys { get; set; }
        /// <summary>
        /// Школа
        /// </summary>
        public string School { get; set; }
        /// <summary>
        ///Доп. мобильный телефон
        /// </summary>
        public string Two_MobilePhone { get; set; }
        /// <summary>
        /// Заметка
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        /// Путь к фото
        /// </summary>
        public string ImagePath { get; set; }
        /// <summary>
        /// Языки программирования
        /// </summary>
        public bool Skill1
        { get; set; }
        /// <summary>
        /// Microsoft Office
        /// </summary>
        public bool Skill2
        { get; set; }
        /// <summary>
        /// Adobe Photoshop
        /// </summary>
        public bool Skill3
        { get; set; }
        /// <summary>
        /// Электроника, электротехника
        /// </summary>
        public bool Skill4
        { get; set; }
        /// <summary>
        /// Настройка локальных сетей
        /// </summary>
        public bool Skill5
        { get; set; }
        /// <summary>
        /// Другие полезные навыки
        /// </summary>
        public bool Skill6
        { get; set; }
        /// <summary>
        /// В запасе
        /// </summary>
        public bool Zapas
        { get; set; }
        /// <summary>
        /// Призыв
        /// </summary>
        public bool Exhortation
        { get; set; }
        /// <summary>
        /// Проект приказа
        /// </summary>
        public bool ProjectOrder
        { get; set; }
        /// <summary>
        /// Чей приказ
        /// </summary>
        public string WhoseOrder
        { get; set; }
        /// <summary>
        /// ???
        /// </summary>
        public string VO
        { get; set; }
        /// <summary>
        /// Военная служба
        /// </summary>
        public string Fighting
        { get; set; }
        /// <summary>
        /// Группа крови
        /// </summary>
        public string BloodType
        { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public string Growth
        { get; set; }
        /// <summary>
        /// Размер одежды
        /// </summary>
        public string ClothihgSize
        { get; set; }
        /// <summary>
        /// Размер обуви
        /// </summary>
        public string ShoeSize
        { get; set; }
        /// <summary>
        /// Размер головного убора
        /// </summary>
        public string CapSize
        { get; set; }
        /// <summary>
        /// Размер противогаза
        /// </summary>
        public string MaskSize
        { get; set; }
        /// <summary>
        /// Иностранный язык
        /// </summary>
        public string ForeignLanguage
        { get; set; }
        /// <summary>
        /// Степень владения
        /// </summary>
        public string LanguageRank
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

        public string GetPositionValue
        {
            get
            {
                switch (Position)
                {
                    case StudentPosition.commander:
                        return "КВ";
                    case StudentPosition.firstSquadCommander:
                        return "КО1";
                    case StudentPosition.secondSquadCommander:
                        return "КО2";
                    case StudentPosition.thirdSquadCommander:
                        return "КО3";
                    case StudentPosition.journalist:
                        return "Ж";
                    case StudentPosition.secretary:
                        return "С";
                    case StudentPosition.none:
                        return string.Empty;
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
