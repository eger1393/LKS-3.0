using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LKS.Models
{
	public partial class Prepod
	{
		[Key]
		public string Id { get; set; }
		public virtual List<Troop> Troops { get; set; }
		public string Initials
		{
			get
			{
				return MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";
			}
		}
		[DisplayName("Фамилия")]
		public string MiddleName { get; set; }
		[DisplayName("Имя")]
		public string FirstName { get; set; }
		[DisplayName("Отчество")]
		public string LastName { get; set; }
		[DisplayName("Звание")]
		public string Coolness { get; set; }
		[DisplayName("Должность")]
		public string PrepodRank { get; set; }
		[DisplayName("Дополнительно")]
		public string AdditionalInfo { get; set; }
	}
}