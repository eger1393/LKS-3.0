using LKS.Data.Models.Enums;
using System.Collections.Generic;

namespace LKS.Data.Models
{
    public interface ITroop
    {

        string Id { get; set; }

        /// <summary>
        /// Командир взвода
        /// </summary>
        string PlatoonCommanderId { get; set; }
        /// <summary>
        /// Командир взвода
        /// </summary>
        Student PlatoonCommander { get; set; }

        /// <summary>
		/// Цикл обучения
		/// </summary>
        string CycleId { get; set; }
        /// <summary>
		/// Цикл обучения
		/// </summary>
        Cycle Cycle { get; set; }

        /// <summary>
		/// Ответственный преподаватель
		/// </summary>
		string PrepodId { get; set; }
        /// <summary>
		/// Ответственный преподаватель
		/// </summary>
		Prepod Prepod { get; set; }

        /// <summary>
		/// Студенты
		/// </summary>
		List<Student> Students { get; set; }

        /// <summary>
		/// Номер взвода
		/// </summary>
		string NumberTroop { get; set; }

        /// <summary>
        /// Личный состав (чел)
        /// </summary>
        int StaffCount { get; }

        /// <summary>
		/// Взвод для сборов?
		/// </summary>
        bool IsSboriTroop { get; set; }

        /// <summary>
        /// День прихода
        /// </summary>
        ArrivalDay ArrivalDay { get; set; }

        string GetArrivalDayValue
        {
            get;
        }
    }
}
