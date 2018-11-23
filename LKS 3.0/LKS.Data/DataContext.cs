using LKS.Data.Models;
using LKS.Data.Models.Enums;
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
			builder.Entity<Troop>().HasAlternateKey(x => x.NumberTroop);

			Seed(builder);
		}

		private void Seed(ModelBuilder builder)
		{
			Random rand = new Random();
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
				LastName = "Иванов",
				MiddleName = "Иванович",
				Coolness = Coolness.Col,
				PrepodRank = "test"
			});
			builder.Entity<Troop>().HasData(new Troop
			{
				Id = "1",
				CycleId = "1",
				NumberTroop = "410",
				PrepodId = "1"
			});
			builder.Entity<Troop>().HasData(new Troop
			{
				Id = "2",
				CycleId = "1",
				NumberTroop = "520",
				PrepodId = "1"
			});

			for (int i = 0; i < 1000; i++)
			{
				builder.Entity<Student>().HasData(new Student
				{
					Id = Guid.NewGuid().ToString(),
					TroopId = i >= 50 ? "1" : "2",
					FirstName = "Имя" + rand.Next(100),
					LastName = "Фамилия" + rand.Next(100),
					MiddleName = "Отчество" + rand.Next(100),
					Collness = "Студент",
					Position = (StudentPosition)rand.Next(0, 5),
					Kurs = 4,
					Status = (StudentStatus)rand.Next(0, 4)
				});
			}
		}
	}
}
