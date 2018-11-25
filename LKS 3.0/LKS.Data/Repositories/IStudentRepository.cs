using LKS.Data.Models;
using LKS.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LKS.Data.Abstract
{
	public interface IStudentRepository : IRepository<Student>
	{
		List<Student> GetStudents(Dictionary<string, string> filters, string selectTroop);
		Task SetStudentStatus(string id,StudentStatus status);
		Task SetStudentPosition(string id, StudentPosition position);
	}
		List<Student> GetStudents(Dictionary<string, string> filters);

        List<string> GetInstGroupList();

    }
}
