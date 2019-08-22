using System;
using System.Collections.Generic;
using System.Text;

namespace LKS.Data.Models
{
	public class Assessment
	{
		public string Id { get; set; }
		public int ProtocolOneTheory { get; set; }
		public int ProtocolOnePractice { get; set; }
		public int ProtocolOneFinal { get; set; }
		public int CharacteristicMilitaryTechnicalTraining { get; set; }
		public int CharacteristicTacticalSpecialTraining { get; set; }
		public int CharacteristicMilitarySpeialTraining { get; set; }
		public int CharacteristicFinal { get; set; }
	}
}
