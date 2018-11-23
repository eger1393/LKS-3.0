using LKS.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LKS.Data.Abstract
{
	public interface IStudentRepository : IRepository<Student>
	{
		List<Student> GetStudents(Dictionary<string, string> filters, string selectTroop);
	}
}
