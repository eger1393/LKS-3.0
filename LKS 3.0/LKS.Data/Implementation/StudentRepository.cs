using LKS.Data.Helpers;
using LKS.Data.Models;
using LKS.Data.Models.Enums;
using LKS.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.Data.Implementation
{
	public class StudentRepository : IStudentRepository
	{
		private readonly DataContext _context;
		public StudentRepository(DataContext context)
		{
			_context = context;
		}
		public async Task Create(Student item)
		{
			await _context.Students.AddAsync(item);
			await _context.Relatives.AddRangeAsync(item.Relatives);
			_context.SaveChanges();
		}

		public void CreateStudent(Student student, List<Relative> relatives)
		{
			if (string.IsNullOrEmpty(student.Id))
			{
				_context.Students.Add(student);
				foreach (var item in relatives)
				{
					item.StudentId = student.Id;
				}
				_context.Relatives.AddRange(relatives);
			}
			else
			{
				_context.Students.Update(student);
				foreach (var item in relatives)
				{
					item.StudentId = student.Id;
				}
				_context.Relatives.UpdateRange(relatives);
			}
			_context.SaveChanges();
		}

		public async Task CreateRange(ICollection<Student> item)
		{
			await _context.Students.AddRangeAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Student item)
		{
			_context.Students.Remove(item);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteRange(ICollection<Student> item)
		{
			_context.Students.RemoveRange(item);
			await _context.SaveChangesAsync();
		}

		public async Task<Student> GetItem(string id)
		{
			var res = await _context.Students.FindAsync(id);
			return res;
		}

		public Student GetStudent(string id)
		{
			var res = _context.Students.Include(ob => ob.Relatives).FirstOrDefault(u => u.Id == id);
			return res;
		}

		public List<Student> GetStudents(Dictionary<string, string> filters, string selectTroop)
		{
			filters = filters.Where(x => !string.IsNullOrEmpty(x.Value)).ToDictionary(x => x.Key, x => x.Value);

			var res = _context.Students
				.Include(ob => ob.Troop)
				.AsQueryable().ToList(); // todo delete tolist
			if (!string.IsNullOrEmpty(selectTroop))
				res = res.Where(ob => ob.TroopId == selectTroop).ToList();
			if (filters.Any())
				FilterStudents(filters, ref res);

			return res.ToList();
		}

		public List<Student> GetStudents(List<string> ids)
		{
			return _context.Students
				.Include(x => x.Troop)
				.Include(x => x.Relatives)
				.Where(x => ids.Contains(x.Id))
				.ToList();
		}

		public List<Student> GetTrainStudents()
		{
			return _context.Students
				.Include(ob => ob.Troop)
				.Include(ob => ob.Relatives)
				.Where(ob => ob.Status == StudentStatus.train
					|| ob.Status == StudentStatus.trainingFees
					|| ob.Status == StudentStatus.completedFees
					).ToList();

		}

		public List<Student> GetForDeductionsStudents()
		{
			return _context.Students
				.Include(ob => ob.Troop)
				.Include(ob => ob.Relatives)
				.Where(ob => ob.Status == StudentStatus.forDeductions).ToList();

		}

		public List<Student> GetSuspendedStudents()
		{
			return _context.Students
				.Include(ob => ob.Troop)
				.Include(ob => ob.Relatives)
				.Where(ob => ob.Status == StudentStatus.suspended).ToList();

		}

		[SuppressMessage("ReSharper", "PossibleNullReferenceException")]
		public async Task SetStudentStatus(string id, StudentStatus status)
		{
			var student = _context.Students.FirstOrDefault(ob => ob.Id == id);
			Guard.Argument.IsNotNull(() => student);
			student.Status = status;
			await _context.SaveChangesAsync();
		}


		[SuppressMessage("ReSharper", "PossibleNullReferenceException")]
		public async Task SetStudentPosition(string id, StudentPosition position)
		{
			var student = _context.Students.Include(x => x.Troop).ThenInclude(x => x.PlatoonCommander).FirstOrDefault(ob => ob.Id == id);
			Guard.Argument.IsNotNull(() => student);
			if (position == StudentPosition.commander)
			{
				if (student.Troop?.PlatoonCommander != null)
					student.Troop.PlatoonCommander.Position = StudentPosition.none;
				if (student.Troop != null)
					student.Troop.PlatoonCommander = student;
			}
			student.Position = position;
			await _context.SaveChangesAsync();
		}

		public async Task Update(Student item)
		{
			foreach (var i in item.Relatives)
			{
				_context.Relatives.Update(i);
			}
			_context.Students.Update(item);

			await _context.SaveChangesAsync();
		}

		public async Task UpdateSboryTroopId(List<Student> students)
		{
			var dbStudents = _context.Students.ToList();
			foreach (var item in dbStudents)
			{
				var student = students.FirstOrDefault(x => x.Id == item.Id);
				if(student == null)
				{
					continue;
				}
				item.SboryTroopId = student.SboryTroopId;
			}
			_context.Students.UpdateRange(dbStudents);
			await _context.SaveChangesAsync();
		}

		private static void FilterStudents(Dictionary<string, string> filters, ref List<Student> res)//IQueryable<Student> res)
		{
			foreach (var (key, value) in filters)
			{
				switch (key)
				{
					case "firstName":
						res = res.Where(ob => ob.FirstName?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "lastName":
						res = res.Where(ob => ob.LastName?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "middleName":
						res = res.Where(ob => ob.MiddleName?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "collness":
						res = res.Where(ob => ob.Collness?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "numTroop":
						res = res.Where(ob => ob.Troop?.NumberTroop?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "instGroup":
						res = res.Where(ob => ob.InstGroup?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "mobilePhone":
						res = res.Where(ob => ob.MobilePhone?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "homePhone":
						res = res.Where(ob => ob.HomePhone?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "faculty":
						res = res.Where(ob => ob.Faculty?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "kurs":
						{
							if (int.TryParse(value, out int num))
								res = res.Where(ob => ob.Kurs == num).ToList();
							break;
						}
					case "specInst":
						res = res.Where(ob => ob.SpecInst?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "conditionsOfEducation":
						res = res.Where(ob => ob.ConditionsOfEducation?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "rectal":
						res = res.Where(ob => ob.Rectal?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "specialityName":
						res = res.Where(ob => ob.SpecialityName?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "birthday":
						res = res.Where(ob => ob.Birthday?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "placeBirthday":
						res = res.Where(ob => ob.PlaceBirthday?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "dateOfOrder":
						res = res.Where(ob => ob.DateOfOrder?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "numberOfOrder":
						res = res.Where(ob => ob.NumberOfOrder?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "citizenship":
						res = res.Where(ob => ob.Citizenship?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "nationality":
						res = res.Where(ob => ob.Nationality?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "familiStatys":
						res = res.Where(ob => ob.FamiliStatys?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "placeOfRegestration":
						res = res.Where(ob => ob.PlaceOfRegestration?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "placeOfResidence":
						res = res.Where(ob => ob.PlaceOfResidence?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "school":
						res = res.Where(ob => ob.School?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "yearOfAddMAI":
						res = res.Where(ob => ob.YearOfAddMAI?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "yearOfAddVK":
						res = res.Where(ob => ob.YearOfAddVK?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "yearOfEndMAI":
						res = res.Where(ob => ob.YearOfEndMAI?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "yearOfEndVK":
						res = res.Where(ob => ob.YearOfEndVK?.Contains(value, StringComparison.InvariantCultureIgnoreCase) ?? false).ToList();
						break;
					case "studentType":
						{
							if (value != "all"
								 && Enum.TryParse(value, true, out StudentStatus status)
								 && Enum.IsDefined(typeof(StudentStatus), status)
								)
							{
								res = res.Where(ob => ob.Status == status).ToList();
							}
							break;
						}
				}
			}
		}

		public List<string> GetInstGroupList()
		{
			var answer = _context.Students.Select(u => u.InstGroup).Distinct().ToList();
			answer.RemoveAll(string.IsNullOrWhiteSpace);
			return answer;

		}

		public List<string> GetSpecInstList()
		{
			var answer = _context.Students.Select(u => u.SpecInst).Distinct().ToList();
			answer.RemoveAll(string.IsNullOrWhiteSpace);
			return answer;

		}

		public List<string> GetRectalList()
		{
			var answer = _context.Students.Select(u => u.Rectal).Distinct().ToList();
			answer.RemoveAll(string.IsNullOrWhiteSpace);
			return answer;

		}

		public List<string> GetLanguagesList()
		{
			var answer = _context.Students.Select(u => u.ForeignLanguage).Distinct().ToList();
			answer.RemoveAll(string.IsNullOrWhiteSpace);
			return answer;
		}
	}
}
