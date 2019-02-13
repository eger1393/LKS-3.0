using LKS.Data.Models;
using LKS.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LKS.Data.Repositories
{
	public interface IStudentRepository : IRepository<Student>
	{
		List<Student> GetStudents(Dictionary<string, string> filters, string selectTroop);
        Student GetStudent(string id);
        List<Student> GetTrainStudents();
		List<Student> GetForDeductionsStudents();
		List<Student> GetSuspendedStudents();
		Task SetStudentStatus(string id,StudentStatus status);
		Task SetStudentPosition(string id, StudentPosition position);
        List<string> GetInstGroupList();
        List<string> GetSpecInstList();
        List<string> GetRectalList();
        List<string> GetLanguagesList();

    }
}
