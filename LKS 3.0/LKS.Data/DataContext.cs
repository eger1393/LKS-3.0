using LKS.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace LKS.Data
{
	public class DataContext : DbContext
	{

		#region Properties
		public DbSet<Student> Students { get; set; }
		public DbSet<Relative> Relatives { get; set; }
		public DbSet<Troop> Troops { get; set; }
		public DbSet<Prepod> Prepods { get; set; }
		public DbSet<Cycle> Cycles { get; set; }
		#endregion

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			Seed(builder);
		}

		private void Seed(ModelBuilder builder)
		{
			builder.Entity<Cycle>().HasData(new Cycle
			{
				Id = "1",
				Number = "3",
				SpecialityName = "Тор",
				VUS = "165000"
			});

			builder.Entity<Prepod>().HasData(new Prepod
			{
				Id = "1",
				FirstName = "Иван",
				MiddleName = "Иванов",
				LastName = "Иванович",
				Coolness = Coolness.Col,
				PrepodRank = "test"
			});
			builder.Entity<Troop>().HasData(new Troop
			{
				Id = "1",
				CucleId = "1",
				NumberTroop = "410",
				PrepodId = "1"
			});
			builder.Entity<Troop>().HasData(new Troop
			{
				Id = "2",
				CucleId = "1",
				NumberTroop = "520",
				PrepodId = "1"
			});

			for (int i = 0; i < 100; i++)
			{
				builder.Entity<Student>().HasData(new Student
				{
					Id = Guid.NewGuid().ToString(),
					TroopId = i >= 50 ? "1" : "2",
					FirstName = "Имя" + i,
					LastName = "Фамилия" + i,
					MiddleName = "Отчество" + i
				});
			}
		}
	}
}
