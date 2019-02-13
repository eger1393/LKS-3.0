using LKS.Data.Repositories;
using LKS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LKS.Data.Providers;

namespace LKS.Data.Implementation
{
	public class TroopRepository : ITroopRepository
	{
		private DataContext context;
		private readonly IUserRepository _userRepository;
		private readonly IPasswordProvider _passwordProvider;
		public TroopRepository(DataContext context, IUserRepository userRepository, IPasswordProvider passwordProvider)
		{
			this.context = context;
			_userRepository = userRepository;
			_passwordProvider = passwordProvider;
		}
		public async Task Create(Troop item)
		{
			await context.Troops.AddAsync(item);
			await _userRepository.Create(new User
			{
				Login = "Troop" + item.NumberTroop,
				Role = "User",
				TroopId = item.Id,
				Password = _passwordProvider.GetHash(_passwordProvider.GetRandomPassword(8), "Troop" + item.NumberTroop)
			});
			context.SaveChanges();
			//return;
		}

		public async Task CreateRange(ICollection<Troop> item)
		{
			await context.Troops.AddRangeAsync(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task Delete(Troop item)
		{
			Troop troop = context.Troops.Include(x => x.Students).FirstOrDefault(x => x.Id == item.Id);
			User user = context.Users.FirstOrDefault(x => x.TroopId == troop.Id);
			if (user != null)
				context.Users.Remove(user);
			context.RemoveRange(troop.Students);
			context.Troops.Remove(troop);
			context.SaveChanges();
			return;
		}

		public async Task DeleteRange(ICollection<Troop> item)
		{
			context.Troops.RemoveRange(item);
			await context.SaveChangesAsync();
			return;
		}

		public async Task<Troop> GetItem(string id)
		{
			return await context.Troops
				.Include(ob => ob.Students)
				.Include(ob => ob.Prepod)
				.Include(ob => ob.PlatoonCommander)
				.FirstOrDefaultAsync(ob => ob.Id == id);
		}

		public List<Troop> GetTroops()
		{
			return context.Troops
				.Include(ob => ob.Cycle)
				.Include(ob => ob.Prepod)
				.Include(ob => ob.Students)
				.Include(ob => ob.PlatoonCommander)
				.ToList();
		}

		public Troop GetBuNum(string num)
		{
			return context.Troops
				.Include(ob => ob.Students)
				.Include(ob => ob.Prepod)
				//.Include(ob=>ob.PlatoonCommander)
				.FirstOrDefault(ob => ob.NumberTroop == num);
		}

		public async Task Update(Troop item)
		{
			var troop = context.Troops.FirstOrDefault(x => x.Id == item.Id);
			troop.NumberTroop = item.NumberTroop;
			troop.PrepodId = item.PrepodId;
			troop.CycleId = item.CycleId;
			troop.ArrivalDay = item.ArrivalDay;
			var user = context.Users.FirstOrDefault(x => x.TroopId == troop.Id);
			user.Login = "Troop" + troop.NumberTroop;
			context.SaveChanges();
			return;
		}
    }
}
