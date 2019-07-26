using System.Collections.Generic;
using LKS.Data.Models;

namespace LKS.Web.Models
{
    public class AddStudentModel
    {
        public List<Relative> Relatives { get; set; }
        public Student Student { get; set; }
      
    }
}
