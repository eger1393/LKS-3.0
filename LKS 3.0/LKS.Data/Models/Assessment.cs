using System;
using System.Collections.Generic;
using System.Text;

namespace LKS.Data.Models
{
	public class Assessment
	{
		public string Id { get; set; }
        /// <summary>
        /// Теоретические знания
        /// </summary>
        public int ProtocolOneTheory { get; set; }
        /// <summary>
        /// Практичесикие умения
        /// </summary>
        public int ProtocolOnePractice { get; set; }
        /// <summary>
        /// Общая оценка
        /// </summary>
        public int ProtocolOneFinal { get; set; }
        /// <summary>
        /// Оценка за ФИЗО
        /// </summary>
        public int SportLevel { get; set; }
        /// <summary>
        /// Методический уровень
        /// </summary>
        public int MethodologicalLevel { get; set; }


        //public int AssessmentCharacteristicMilitaryTechnicalTraining { get; set; }
        //public int AssessmentCharacteristicTacticalSpecialTraining { get; set; }
        //public int AssessmentCharacteristicMilitarySpeialTraining { get; set; }
        //public int AssessmentCharacteristicFinal { get; set; }
    }
}
