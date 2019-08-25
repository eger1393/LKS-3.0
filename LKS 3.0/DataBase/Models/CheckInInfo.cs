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
		public string additionalInfo { get; set; }
		public DateTime? checkInBeginTime { get; set; }
		public DateTime? checkInEndTime { get; set; }
		public string checkInLocation { get; set; }
	}
}
