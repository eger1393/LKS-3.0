using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DataBinding
{
	public class ValidationNumRule:ValidationRule
	{
		public int min
		{
			get;
			set;
		}
		public int max
		{
			get;
			set;
		}
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			double year = 0;
			try
			{
				year = double.Parse((string)value);
			}
			catch
			{
				return new ValidationResult(false, "Недопустимые символы."); // если было введено не число то сообщаем об этом
			}
			if(!(year <= max && year >= min)) // если введеный год лежит вне диапазонов то сообщаем об эом
			{
				return new ValidationResult(false, "Введено недопустимое значение.");
			}
			else
			{
				return new ValidationResult(true, ""); // все хорошо
			}
		}
	}

	public class ValidationAssessmentRule : ValidationRule
	{
		public override ValidationResult Validate(object value, CultureInfo cultureInfo)
		{
			if (new[] { "", "2", "3", "4", "5" }.Contains(value))
			{
				return ValidationResult.ValidResult;
			}
			else
			{
				return new ValidationResult(false, "Введено недопустимое значение.");
			}
		}
	}
}
