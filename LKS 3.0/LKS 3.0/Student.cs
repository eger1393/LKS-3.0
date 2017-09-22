using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS_3._0
{
	/// <summary>
	/// класс хранящий данные о студентах
	/// </summary>
	class Student
	{
		public Student() // Конструктор по умолчанию
		{
			FirstName = "";
			MidleName = "";
			LastName = "";
			MobilePhone = "";
			HomePhone = "";
			Group = "";
			SpecialityName = "";
			Rank = 0;
			Nationality = 0;
			Citizenship = "";
		}


		bool CheckFillingFields() // ПРоверка на заполнение обязательных полей класса (проверка на правильность заполнения поля производится на форме)
		{
			if (
				FirstName != "" && FirstName != "" && MidleName != "" &&
				LastName != "" && MobilePhone != "" && HomePhone != "" &&
				Group != "" && SpecialityName != "" && Rank != 0 &&
				Nationality != 0 && Citizenship != ""
				)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		string FirstName // Имя
		{ get; set; }

		string MidleName // Фамилия
		{ get; set; }

		string LastName // Отчество
		{ get; set; }

		string MobilePhone // Номер моильного телефона
		{ get; set; }

		string HomePhone // Номер домашнего телефона
		{ get; set; }

		string Group
		{ get; set; } // Группа студента

		// TODO добавить перечесление специальностей после уточнения(?), перечисление званий, национальностей

		// возможно извенить поле на целочисленное и исспользовать перечисление
		string SpecialityName
		{ get; set; } // Название специальности

		ushort Rank // Звание студента (перечисление)
		{ get; set; }

		ushort Nationality // Национальность (перечисление)
		{ get; set; }

		string Citizenship // Гражданство
		{ get; set; }



	}
}
