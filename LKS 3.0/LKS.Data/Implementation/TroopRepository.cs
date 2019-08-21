using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Helpers;
using LKS.Data.Models;
using LKS.Data.Providers;
using LKS.Data.Repositories;

namespace LKS.Data.Implementation
{
	public class TroopRepository : ITroopRepository
	{
		private readonly DataContext _context;
		private readonly IUserRepository _userRepository;
		private readonly IPasswordProvider _passwordProvider;
		public TroopRepository(DataContext context, IUserRepository userRepository, IPasswordProvider passwordProvider)
		{
			_context = context;
			_userRepository = userRepository;
			_passwordProvider = passwordProvider;
		}
		public async Task Create(Troop item)
		{
			await _context.Troops.AddAsync(item);
			await _userRepository.Create(new User
			{
				Login = "Troop" + item.NumberTroop,
				Role = "User",
				TroopId = item.Id,
				Password = _passwordProvider.GetHash(_passwordProvider.GetRandomPassword(8), "Troop" + item.NumberTroop)
			});
			_context.SaveChanges();
        }

		public async Task CreateRange(ICollection<Troop> item)
		{
			await _context.Troops.AddRangeAsync(item);
			await _context.SaveChangesAsync();
        }

		public async Task Delete(Troop item)
		{
			var troop = _context.Troops.Include(x => x.SboryStudents).Include(x => x.UniversityStudents).FirstOrDefault(x => x.Id == item.Id);
            Guard.Argument.IsNotNull(() => troop);
			var user = _context.Users.FirstOrDefault(x => x.TroopId == troop.Id);
			if (user != null)
				_context.Users.Remove(user);
            // ReSharper disable once PossibleNullReferenceException
            _context.RemoveRange(troop.Students);
			_context.Troops.Remove(troop);
            await _context.SaveChangesAsync();
        }

		public async Task DeleteRange(ICollection<Troop> item)
		{
			_context.Troops.RemoveRange(item);
			await _context.SaveChangesAsync();
        }

		public async Task<Troop> GetItem(string id)
		{
			return await _context.Troops
				.Include(ob => ob.UniversityStudents)
				.Include(ob => ob.SboryStudents)
				.Include(ob => ob.Prepod)
				.Include(ob => ob.PlatoonCommander)
				.FirstOrDefaultAsync(ob => ob.Id == id);
		}

		public List<Troop> GetTroops()
		{
			return _context.Troops
				.Include(ob => ob.Cycle)
				.Include(ob => ob.Prepod)
				.Include(ob => ob.UniversityStudents)
				.Include(ob => ob.SboryStudents)
				.Include(ob => ob.PlatoonCommander)
				.ToList();
		}

		public Troop GetBuNum(string num)
		{
			return _context.Troops
				.Include(ob => ob.UniversityStudents)
				.Include(ob => ob.SboryStudents)
				.Include(ob => ob.Prepod)
				//.Include(ob=>ob.PlatoonCommander)
				.FirstOrDefault(ob => ob.NumberTroop == num);
		}

		[SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        public async Task Update(Troop item)
		{
			var troop = _context.Troops.FirstOrDefault(x => x.Id == item.Id);
            Guard.Argument.IsNotNull(() => troop);
            troop.NumberTroop = item.NumberTroop;
			troop.PrepodId = item.PrepodId;
			troop.CycleId = item.CycleId;
			troop.ArrivalDay = item.ArrivalDay;
			var user = _context.Users.FirstOrDefault(x => x.TroopId == troop.Id);
            Guard.Argument.IsNotNull(() => user);
            user.Login = "Troop" + troop.NumberTroop;
            await _context.SaveChangesAsync();
        }
    }
}
