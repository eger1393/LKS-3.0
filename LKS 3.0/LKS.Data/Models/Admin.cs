using System.ComponentModel.DataAnnotations;

namespace LKS.Data.Models
{
    public class Admin
    {

        public Admin()
        {
        }

        [Key]
        public string Id { get; set; }

        /// <summary>
        /// Комманда в шаблонах
        /// </summary>
        public string Command
        { get; set; }

        public string Initials => FirstName[0] + ". " + MiddleName;


        [Required]
        /// <summary>
        /// Должность
        /// </summary>
        public string Rank { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Звание
        /// </summary>
        public string Collness
        { get; set; }
               
    }
}
