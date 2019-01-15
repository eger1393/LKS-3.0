using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace LKS.Data.Models
{
	public class Relative
	{
		[Key]
		public string Id { get; set; }

        [Required]
        [ForeignKey(nameof(Student))]
        public string StudentId { get; set; }
		public Student Student { get; set; }


		public string initials()
		{
            if (String.IsNullOrEmpty(MiddleName) || String.IsNullOrEmpty(FirstName) || String.IsNullOrEmpty(LastName))
            {
                MiddleName = "None";
                FirstName = "None";
                LastName = "None";
            }
            return MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";
        }

		[DisplayName("Фамилия")]
		public string MiddleName { get; set; }

		[DisplayName("Имя")]
		public string FirstName { get; set; }

		[DisplayName("Отчество")]
		public string LastName { get; set; }

		[DisplayName("Девичья фамилия")]
		public string MaidenName { get; set; }

		[DisplayName("Степень родства")]
		public string RelationDegree { get; set; }

		[DisplayName("Дата рождения")]
		public string Birthday { get; set; }

		[DisplayName("Мобильный телефон")]
		public string MobilePhone { get; set; }

		[DisplayName("Адрес проживания")]
		public string PlaceOfResidence { get; set; }

		[DisplayName("Адрес прописки")]
		public string PlaceOfRegestration { get; set; }

		[DisplayName("Состояние здоровья")]
		public string HealthStatus { get; set; }
	}

}
