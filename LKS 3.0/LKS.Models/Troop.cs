using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LKS.Models
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
		[JsonIgnore]
		public Student PlatoonCommander;

		[ForeignKey(nameof(Cycle))]
		public string CycleId { get; set; }
		[JsonIgnore]
		public Cycle Cycle { get; set; }

		[ForeignKey(nameof(Prepod))]
		public string PrepodId { get; set; }
		[JsonIgnore]
		public Prepod Prepod { get; set; }

		[JsonIgnore]
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
