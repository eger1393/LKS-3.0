using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS_3._0
{
    public partial class Prepod
    {
        public static int _count;

        private int ID;
       
        public int Id
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }

        public int? TroopId { get; set; }
        public Troop Troop { get; set; }

        public Prepod()
        {
            FirstName = "";
            MiddleName = "";
            LastName = "";
            Coolness = "";
        }

		public string initials()
		{
			return MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";
		}

		[RusName("Фамилия")]
        public string MiddleName
        { get; set; }

        [RusName("Имя")]
        public string FirstName
        { get; set; }

        [RusName("Отчество")]
        public string LastName
        { get; set; }

        [RusName("Звание")]
        public string Coolness
        { get; set; }

        [RusName("Должность")]
        public string PrepodRank
        { get; set; }

        [RusName("Дополнительно")]
        public string AdditionalInfo
        { get; set; }

        public override string ToString()
        {
            return Coolness + " " + MiddleName + " " + FirstName[0] + ". " + LastName[0]+ ". ";
        }
    }
}

