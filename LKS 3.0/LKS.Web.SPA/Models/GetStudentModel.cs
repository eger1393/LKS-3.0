using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace LKS.Web.SPA.Models
{
    public class GetStudentModel
    {
        [Required]
        public string id { get; set; }
    }
}
