using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataBase.Models
{
	public class ServiceTable
	{
		[Key]
		public int serviceTableId { get; set; }

		[Required]
		[MaxLength(255)]
		public string title { get; set; }

		[Required]
		public int order { get; set; }

		[MaxLength(255)]
		public string headerText { get; set; }

		[MaxLength(255)]
		public string footerText { get; set; }

		[MaxLength(255)]
		public string position { get; set; }

		public List<ServiceTableRow> rows { get; set; }



	}

	public class ServiceTableRow
	{
		[Key]
		public int serviceTableRowId { get; set; }

		[Required]
		public string column1 { get; set; }

		[Required]
		public string column2 { get; set; }

	}
}
