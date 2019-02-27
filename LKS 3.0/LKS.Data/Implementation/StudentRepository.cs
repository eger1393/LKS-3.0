using LKS.Data.Repositories;
using LKS.Data.Models;
using LKS.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS.Data.Implementation
{
	public class StudentRepository : IStudentRepository
	{
		private DataContext context;
		public StudentRepository(DataContext context)
		{
			this.context = context;	
		}
		public async Task Create(Student item)
		{
			await context.Students.AddAsync(item);
            await context.Relatives.AddRangeAsync(item.Relatives);
            context.SaveChanges();
			return;
		}

		public void CreateStudent(Student student, List<Relative> relatives)
		{
			if (string.IsNullOrEmpty(student.Id))
			{
				context.Students.Add(student);
				foreach (var item in relatives)
				{
					item.StudentId = student.Id;
				}
				context.Relatives.AddRange(relatives);
			}
			else
			{
				context.Students.Update(student);
				foreach (var item in relatives)
				{
					item.StudentId = student.Id;
				}
				context.Relatives.UpdateRange(relatives);
			}
			context.SaveChanges();
		}

		public async Task CreateRange(ICollection<Student> item)
		{
			await context.Students.AddRangeAsync(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task Delete(Student item)
		{
			context.Students.Remove(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task DeleteRange(ICollection<Student> item)
		{
			context.Students.RemoveRange(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task<Student> GetItem(string id)
		{
			var res = await context.Students.FindAsync(id);
			return res;
		}

        public Student GetStudent(string id)
        {
            var res = context.Students.Include(ob => ob.Relatives).FirstOrDefault(u => u.Id == id);
            return res;
        }

        public List<Student> GetStudents(Dictionary<string, string> filters, string selectTroop)
        {
            filters = filters.Where(x => !String.IsNullOrEmpty(x.Value)).ToDictionary(x => x.Key, x => x.Value);

            var res = context.Students
                .Include(ob => ob.Troop)
                .AsQueryable().ToList(); // todo delete tolist
            if (!String.IsNullOrEmpty(selectTroop))
                res = res.Where(ob => ob.TroopId == selectTroop).ToList();
            if (filters != null)
                filterStudents(filters, ref res);

            return res.ToList();
        }
        public List<Student> GetTrainStudents()
		{
			return context.Students
				.Include(ob => ob.Troop)
				.Include(ob => ob.Relatives)
				.Where(ob => ob.Status == StudentStatus.train
					|| ob.Status == StudentStatus.trainingFees
					|| ob.Status == StudentStatus.completedFees
					).ToList();

		}

		public List<Student> GetForDeductionsStudents()
		{
			return context.Students
				.Include(ob => ob.Troop)
				.Include(ob => ob.Relatives)
				.Where(ob => ob.Status == StudentStatus.forDeductions).ToList();

		}

		public List<Student> GetSuspendedStudents()
		{
			return context.Students
				.Include(ob => ob.Troop)
				.Include(ob => ob.Relatives)
				.Where(ob => ob.Status == StudentStatus.suspended).ToList();

		}

		public async Task SetStudentStatus(string id, StudentStatus status)
		{
			Student student = context.Students.FirstOrDefault(ob => ob.Id == id);
			student.Status = status;
			context.SaveChanges();
		}


        public async Task SetStudentPosition(string id, StudentPosition position)
        {
            Student student = context.Students.Include(x => x.Troop).ThenInclude(x => x.PlatoonCommander).FirstOrDefault(ob => ob.Id == id);
            if (position == StudentPosition.commander)
            {
                if (student.Troop?.PlatoonCommander != null)
                    student.Troop.PlatoonCommander.Position = StudentPosition.none;
                if (student.Troop != null)
                    student.Troop.PlatoonCommander = student;
            }
            student.Position = position;
            context.SaveChanges();
        }

        public async Task Update(Student item)
		{
            foreach (var i in item.Relatives)
            {
                context.Relatives.Update(i);
            }
            context.Students.Update(item);

			await context.SaveChangesAsync();
			return;
		}

		private void filterStudents(Dictionary<string, string> filters, ref List<Student> res)//IQueryable<Student> res)
		{
			foreach (var item in filters)
			{
				switch (item.Key)
				{
					case "firstName":
						res = res.Where(ob => ob.FirstName != null ? ob.FirstName.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "lastName":
						res = res.Where(ob => ob.LastName != null ? ob.LastName.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "middleName":
						res = res.Where(ob => ob.MiddleName != null ? ob.MiddleName.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "collness":
						res = res.Where(ob => ob.Collness != null ? ob.Collness.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "numTroop":
						res = res.Where(ob => ob.Troop?.NumberTroop != null ? ob.Troop.NumberTroop.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "instGroup":
						res = res.Where(ob => ob.InstGroup != null ? ob.InstGroup.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "mobilePhone":
						res = res.Where(ob => ob.MobilePhone != null ? ob.MobilePhone.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "homePhone":
						res = res.Where(ob => ob.HomePhone != null ? ob.HomePhone.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "faculty":
						res = res.Where(ob => ob.Faculty != null ? ob.Faculty.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "kurs":
						{
							if (Int32.TryParse(item.Value, out int num))
								res = res.Where(ob => ob.Kurs == num).ToList();
							break;
						}
					case "specInst":
						res = res.Where(ob => ob.SpecInst != null ? ob.SpecInst.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "conditionsOfEducation":
						res = res.Where(ob => ob.ConditionsOfEducation != null ? ob.ConditionsOfEducation.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "rectal":
						res = res.Where(ob => ob.Rectal != null ? ob.Rectal.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "specialityName":
						res = res.Where(ob => ob.SpecialityName != null ? ob.SpecialityName.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "birthday":
						res = res.Where(ob => ob.Birthday != null ? ob.Birthday.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "placeBirthday":
						res = res.Where(ob => ob.PlaceBirthday != null ? ob.PlaceBirthday.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "dateOfOrder":
						res = res.Where(ob => ob.DateOfOrder != null ? ob.DateOfOrder.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "numberOfOrder":
						res = res.Where(ob => ob.NumberOfOrder != null ? ob.NumberOfOrder.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "citizenship":
						res = res.Where(ob => ob.Citizenship != null ? ob.Citizenship.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "nationality":
						res = res.Where(ob => ob.Nationality != null ? ob.Nationality.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "familiStatys":
						res = res.Where(ob => ob.FamiliStatys != null ? ob.FamiliStatys.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "placeOfRegestration":
						res = res.Where(ob => ob.PlaceOfRegestration != null ? ob.PlaceOfRegestration.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "placeOfResidence":
						res = res.Where(ob => ob.PlaceOfResidence != null ? ob.PlaceOfResidence.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "school":
						res = res.Where(ob => ob.School != null ? ob.School.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "yearOfAddMAI":
						res = res.Where(ob => ob.YearOfAddMAI != null ? ob.YearOfAddMAI.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "yearOfAddVK":
						res = res.Where(ob => ob.YearOfAddVK != null ? ob.YearOfAddVK.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "yearOfEndMAI":
						res = res.Where(ob => ob.YearOfEndMAI != null ? ob.YearOfEndMAI.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
					case "yearOfEndVK":
						res = res.Where(ob => ob.YearOfEndVK != null ? ob.YearOfEndVK.Contains(item.Value, StringComparison.InvariantCultureIgnoreCase) : false).ToList();
						break;
                    case "studentType":
                        {
                            if (item.Value != "all"
                                 && Enum.TryParse(item.Value, true, out StudentStatus status)
                                 && Enum.IsDefined(typeof(StudentStatus), status)
                                )
                            {
                                res = res.Where(ob => ob.Status == status).ToList();
                            }
                            break;
                        }
                    default:
						break;
				}
			}
		}

		public List<string> GetInstGroupList()
		{
			var answer = context.Students.Select(u => u.InstGroup).Distinct().ToList();
			answer.RemoveAll(string.IsNullOrWhiteSpace);
			return answer;
       
		}

		public List<string> GetSpecInstList()
		{
			var answer = context.Students.Select(u => u.SpecInst).Distinct().ToList();
			answer.RemoveAll(string.IsNullOrWhiteSpace);
			return answer;
    
		}

        public List<string> GetRectalList()
        {
            var answer = context.Students.Select(u => u.Rectal).Distinct().ToList();
            answer.RemoveAll(string.IsNullOrWhiteSpace);
            return answer;
           
        }

        public List<string> GetLanguagesList()
        {
            var answer = context.Students.Select(u => u.ForeignLanguage).Distinct().ToList();
            answer.RemoveAll(string.IsNullOrWhiteSpace);
            return answer;
        }
    }
}
