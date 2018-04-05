using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace LKS_3._0
{
    public partial class Prepod
    {
        public static int _count;

        private int ID;
        private string signaturePath;


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
        public BindingList<Troop> Troops { get; set; }

        public Prepod()
        {
            FirstName = "";
            MiddleName = "";
            LastName = "";
            Coolness = "";
            Troops = new BindingList<Troop>();
        }

		public string initials()
		{
			return MiddleName + " " + FirstName[0] + ". " + LastName[0] + ".";
		}

		public string SignaturePath
		{
			get
			{
				return AppDomain.CurrentDomain.BaseDirectory + signaturePath;
			}
			set
			{
				signaturePath = value;
			}
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
        [RusName("Взвода")]
        public string TroopsInfo
        {
            get
            {
               return Info();
            }
        }
        [RusName("Дополнительно")]
        public string AdditionalInfo
        { get; set; }

        public override string ToString()
        {
            return Coolness + " " + MiddleName + " " + FirstName[0] + ". " + LastName[0]+ ". ";
        }

        public string Info()
        {
            string str = "";
            foreach (var item in Troops)
            {
                str += item.NumberTroop +  " взвод; ";
            }
            return str;
        }
    }
}

