using System.Collections.Generic;

namespace LKS.Web.Models
{
	public class CreateTemplateModel
	{
		public string templateId { get; set; }
		public List<string> studentIds { get; set; }
		public List<string> troopIds { get; set; }
	}

	public class SetTemplateData
	{
		public string json { get; set; }
	}
}
