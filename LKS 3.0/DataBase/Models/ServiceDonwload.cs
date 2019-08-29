using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
	public class ServiceDonwload
	{
		[Key]
		public int serviceDonwloadID { get; set; }
        [MaxLength(255)]
        public string type { get; set; }
        [MaxLength(255)]
        public string format { get; set; }

	}
}
