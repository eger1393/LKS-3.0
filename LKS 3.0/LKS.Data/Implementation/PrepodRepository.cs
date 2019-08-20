using LKS.Data.Models;
using LKS.Data.Providers;
using LKS.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LKS.Data.Implementation
{
    public class PrepodRepository : IPrepodRepository

    {
        private readonly DataContext _context;
        private readonly IPasswordProvider _passwordProvider;

        public PrepodRepository(DataContext context, IPasswordProvider passwordProvider)
        {
            _passwordProvider = passwordProvider;
            _context = context;
        }
        public async Task<string> Create(Prepod item, string login)
        {
            await _context.Prepods.AddAsync(item);
            string password = _passwordProvider.GetHash(_passwordProvider.GetRandomPassword(8), login);
            await _context.Users.AddAsync(new User
            {
                Login = login,
                Role = "Admin",
                TroopId = string.Empty,
                Password = password
            });
            _context.SaveChanges();
            return password;
        }

        public Task Create(Prepod item)
        {
            throw new NotImplementedException();
        }

        public async Task CreateRange(ICollection<Prepod> item)
        {
            await _context.Prepods.AddRangeAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Prepod item)
        {
            var prepod = _context.Prepods.Include(x => x.Troops).FirstOrDefault(x => x.Id == item.Id);
            if (prepod?.Troops != null)
            {
                foreach (var troop in prepod?.Troops)
                {
                    troop.Prepod = null;
                    troop.PrepodId = null;
                }
            }

            _context.Prepods.Remove(prepod ?? throw new InvalidOperationException());
            _context.SaveChanges();
            return;
        }

        public async Task DeleteRange(ICollection<Prepod> item)
        {
            _context.Prepods.RemoveRange(item);
            _context.SaveChanges();
        }

        public async Task<Prepod> GetItem(string id)
        {
            var res = await _context.Prepods.FindAsync(id);
            return res;
        }

        public IEnumerable<Prepod> GetItems()
        {
            return _context.Prepods.ToList();
        }
        public async Task Update(Prepod item)
        {
            _context.Prepods.Update(item);
            _context.SaveChanges();
        }
    }
}
