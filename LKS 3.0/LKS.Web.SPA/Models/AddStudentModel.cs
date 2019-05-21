using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Models;
using LKS.Data.Models.Enums;

namespace LKS.Web.SPA.Models
{
    public class AddStudentModel
    {
        public List<Relative> Relatives { get; set; }
        public Student Student { get; set; }
      
    }
}
