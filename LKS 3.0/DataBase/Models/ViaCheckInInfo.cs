using System;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
	public class ViaCheckInInfo
	{
		[Key]
		public string viaCheckInInfoID { get; set; }
		public string additionalInfo { get; set; }
		public DateTime checkInBeginTime { get; set; }
		public DateTime checkInEndTime { get; set; }
		public string checkInLocation { get; set; }
	}
}