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
		public string PlatoonCommanderId { get; set; }

		/// <summary>
		/// Командир взвода
		/// </summary>
		public Student PlatoonCommander { get; set; }

		[Required]
		[ForeignKey(nameof(Cycle))]
		public string CycleId { get; set; }
		public Cycle Cycle { get; set; }

		[ForeignKey(nameof(Prepod))]
		public string PrepodId { get; set; }
		public Prepod Prepod { get; set; }

		public virtual List<Student> Students { get; set; }

		[Required]
		public string NumberTroop { get; set; }

		/// <summary>
		/// Личный состав (чел)
		/// </summary>
		public int StaffCount
		{
			get
			{
				return Students?.Count ?? 0;
			}
		}
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
	}
}
