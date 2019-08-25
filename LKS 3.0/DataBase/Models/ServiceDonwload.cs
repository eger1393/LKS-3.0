using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
	public class ServiceDonwload
	{
		[Key]
		public int serviceDonwloadID { get; set; }
		public string type { get; set; }
		public string format { get; set; }

	}
}
