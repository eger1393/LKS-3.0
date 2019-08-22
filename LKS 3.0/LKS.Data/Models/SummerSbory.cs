using System.ComponentModel.DataAnnotations;

namespace LKS.Data.Models
{
    public class SummerSbory
    {
        [Key]
        public string Id { get; set; }



        /// <summary>
        /// Номер приказа
        /// </summary>
        public string NumberofOrder { get; set; }

        /// <summary>
        /// Дата приказа
        /// </summary>
        public string DateOfOrder { get; set; }

        /// <summary>
        /// Текст приказа
        /// </summary>
        public string TextOrder { get; set; }

        /// <summary>
        /// Дата начала сборов
        /// </summary>
        public string DateBeginSbori { get; set; }

        /// <summary>
        /// Дата окончания сборов
        /// </summary>
        public string DateEndSbori { get; set; }

        /// <summary>
        /// Дата присяги
        /// </summary>
        public string DatePrisyaga { get; set; }

        /// <summary>
        /// Дата экзамена
        /// </summary>
        public string DateExamen { get; set; }

        /// <summary>
        /// Номер военной части
        /// </summary>
        public string NumberVK { get; set; }

        /// <summary>
        /// Расположение военной части
        /// </summary>
        public string LocationVK { get; set; }

        /// <summary>
        /// Название боевой машины краткое
        /// </summary>
        public string BmpKr { get; set; }

        /// <summary>
        /// Название боевой машины полное
        /// </summary>
        public string BmpFull { get; set; }
    }
}
