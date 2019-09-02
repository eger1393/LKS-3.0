using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataBase.Models
{
	public class AirportInfo
	{
		[Key]
		public int airportInfoId { get; set; }

		public DateTime? valid_from { get; set; }

		public DateTime? valid_to { get; set; }

		public DateTime? created { get; set; }

		[MaxLength(255)]
		public string title { get; set; }

		[MaxLength(255)]
		public string infoType { get; set; }
		
		public string message { get; set; }

		public List<AirportInfoExternalLink> urls { get; set; }
	}

	public class AirportInfoExternalLink
	{
		[Key]
		public int airportInfoExternalLinkId { get; set; }

		[Required]
		[MaxLength(255)]
		public string url { get; set; }
	}
}
