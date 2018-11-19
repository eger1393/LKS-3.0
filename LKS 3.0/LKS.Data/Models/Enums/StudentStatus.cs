using System;
using System.Collections.Generic;
using System.Text;

namespace LKS.Data.Models.Enums
{
	public enum StudentStatus
	{
		/// <summary>
		/// Обучается
		/// </summary>
		train,

		/// <summary>
		/// На отчисление
		/// </summary>
		forDeductions,

		/// <summary>
		/// Отстранен
		/// </summary>
		suspended,

		/// <summary>
		/// На сборах
		/// </summary>
		trainingFees,

		/// <summary>
		/// Прошел сборы
		/// </summary>
		completedFees
	}
}
