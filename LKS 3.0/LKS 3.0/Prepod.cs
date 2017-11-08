using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS_3._0
{
    public partial class Prepod
    {
        public Prepod()
        {
            FirstName = "";
            MiddleName = "";
            LastName = "";
            Coolness = "";
        }
       
        public int ID
        { get; set; }

        [RusName("Фамилия")]
        public string FirstName
        { get; set; }

        [RusName("Имя")]
        public string MiddleName
        { get; set; }

        [RusName("Отчество")]
        public string LastName
        { get; set; }

        [RusName("Звание")]
        public string Coolness
        { get; set; }

        [RusName("Дополнительно")]
        public string AdditionalInfo
        { get; set; }

        public override string ToString()
        {
            var ranks = new Dictionary<string, string>()
            {
                { "полковник", "п-к" },
                { "подполковник", "п/п-к" },
                { "капитан", "к-н" },
                { "лейтенант", "л-т" },
            };

            return String.Format("{0} {1} {2}.{3}.",
                ranks[Coolness], LastName, FirstName[0], MiddleName[0]);
        }
    }
}

