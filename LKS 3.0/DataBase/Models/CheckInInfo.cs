using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class CheckInInfo
	{
		[Key]
		public int checkInInfoID { get; set; }
        [MaxLength(300)]
        public string additionalInfo { get; set; }
		public DateTime? checkInBeginTime { get; set; }
		public DateTime? checkInEndTime { get; set; }
        [MaxLength(255)]
        public string checkInLocation { get; set; }
	}
}
