﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using LKS.Data.Models.Enums;

namespace LKS.Data.Models
{
	public class Prepod
	{
		[Key]
		public string Id { get; set; }

		public virtual List<Troop> Troops { get; set; }
		public string Initials => MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";

        [DisplayName("Фамилия")]
		public string MiddleName { get; set; }
		[DisplayName("Имя")]
		public string FirstName { get; set; }
		[DisplayName("Отчество")]
		public string LastName { get; set; }
		[DisplayName("Звание")]
		public Coolness Coolness { get; set; }
		[DisplayName("Должность")]
		public string PrepodRank { get; set; }
		[DisplayName("Дополнительно")]
		public string AdditionalInfo { get; set; }

		public string GetCoolnessValue { get
			{
				switch (Coolness)
				{
					case Coolness.Col:
						return "ПК";
					case Coolness.LtCol:
						return "ППК";
					case Coolness.Maj:
						return "Мр";
					case Coolness.Capt:
						return "Кп";
					default:
						return string.Empty;
				}
			}
		}
	}
}