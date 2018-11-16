using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LKS.Data.Models
{


	public partial class Troop
    {
		

        public static List<string> Ranks = new List<string>() { " ","КВ",
        "КО1",
        "КО2",
        "КО3",
        "Старший_секретчик",
        "Секретчик",
        "Журналист", };
		[Key]
        public string Id { get; set; }
		[ForeignKey(nameof(PlatoonCommander))]
		public string PlatoonCommanderId { get; set; }

		public Student PlatoonCommander;

		[ForeignKey(nameof(Cycle))]
		public Cycle Cycle { get; set; }

		[ForeignKey(nameof(Prepod))]
		public string PrepodId { get; set; }

		public Prepod Prepod { get; set; }

		public virtual List<Student> Students { get; set; }

		[DisplayName("Номер взвода")]
        public string NumberTroop { get; set; }
		[DisplayName("Личный состав (чел.)")]
        public int StaffCount { get
			{
				return Students?.Count ?? 0;
			}
		}
		[DisplayName("Взвод для сборов?")]
        public bool SboriTroop { get; set; }
		[DisplayName("День прихода")]
        public string Day { get; set; }
    }
}
