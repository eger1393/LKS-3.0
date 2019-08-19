using LKS.Data.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LKS.Data.Models
{
    public class Troop
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey(nameof(PlatoonCommander))]
        /// <summary>
        /// Командир взвода
        /// </summary>
        public string PlatoonCommanderId { get; set; }
        /// <summary>
        /// Командир взвода
        /// </summary>
        public Student PlatoonCommander { get; set; }

        [Required]
        [ForeignKey(nameof(Cycle))]
        /// <summary>
		/// Цикл обучения
		/// </summary>
        public string CycleId { get; set; }
        /// <summary>
		/// Цикл обучения
		/// </summary>
        public Cycle Cycle { get; set; }

        [ForeignKey(nameof(Prepod))]
        /// <summary>
		/// Ответственный преподаватель
		/// </summary>
		public string PrepodId { get; set; }
        /// <summary>
		/// Ответственный преподаватель
		/// </summary>
		public Prepod Prepod { get; set; }

        /// <summary>
		/// Студенты
		/// </summary>
		public virtual List<Student> Students { get; set; }

        [Required]
        /// <summary>
		/// Номер взвода
		/// </summary>
		public string NumberTroop { get; set; }

        /// <summary>
        /// Личный состав (чел)
        /// </summary>
        public int StaffCount => Students?.Count ?? 0;

        /// <summary>
		/// Взвод для сборов?
		/// </summary>
		[DisplayName("Взвод для сборов?")]
        public bool SboriTroop { get; set; }

        /// <summary>
        /// День прихода
        /// </summary>
        [Required]
        public ArrivalDay ArrivalDay { get; set; }

        public string GetArrivalDayValue
        {
            get
            {
                switch (ArrivalDay)
                {
                    case ArrivalDay.Monday:
                        return "Пн";
                    case ArrivalDay.Tuesday:
                        return "Вт";
                    case ArrivalDay.Wednesday:
                        return "Ср";
                    case ArrivalDay.Thursday:
                        return "Чт";
                    case ArrivalDay.Friday:
                        return "Пт";
                    case ArrivalDay.Saturday:
                        return "Сб";
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
