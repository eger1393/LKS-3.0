using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LKS.Data.Models
{
	public class Troop
	{
		public static List<string> Ranks = new List<string>() {
			" ",
			"КВ",
			"КО1",
			"КО2",
			"КО3",
			"Старший_секретчик",
			"Секретчик",
			"Журналист"
		};
		[Key]
		public string Id { get; set; }
		[ForeignKey(nameof(PlatoonCommander))]
		public string PlatoonCommanderId { get; set; }

		/// <summary>
		/// Командир взвода
		/// </summary>
		public Student PlatoonCommander;

		[ForeignKey(nameof(Cycle))]
		public string CucleId { get; set; }

		public Cycle Cycle { get; set; }

		[ForeignKey(nameof(Prepod))]
		public string PrepodId { get; set; }

		public Prepod Prepod { get; set; }

		public virtual List<Student> Students { get; set; }

		[DisplayName("Номер взвода")]
		public string NumberTroop { get; set; }
		[DisplayName("Личный состав (чел.)")]
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
		[DisplayName("День прихода")]
		public string Day { get; set; }
	}
}
