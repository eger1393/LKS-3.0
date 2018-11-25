using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.Web.SPA.Models
{
	public class GetStudentListDataModel
	{
		public Dictionary<string,string> Filters { get; set; }
		public string SelectTroop { get; set; }
	}
}
