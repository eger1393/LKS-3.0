﻿using LKS.Data.Models;
using LKS.Data.Models.Enums;
using LKS.Data.Providers;
using Microsoft.EntityFrameworkCore;
using System;

namespace LKS.Data
{
	public class DataContext : DbContext
	{
		private readonly IPasswordProvider _passwordProvider;

		#region Properties
		public DbSet<Student> Students { get; set; }
		public DbSet<Relative> Relatives { get; set; }
		public DbSet<Troop> Troops { get; set; }
		public DbSet<Prepod> Prepods { get; set; }
		public DbSet<Cycle> Cycles { get; set; }
		public DbSet<User> Users { get; set; }
		#endregion

		public DataContext(DbContextOptions<DataContext> options, IPasswordProvider passwordProvider) : base(options)
		{
			_passwordProvider = passwordProvider;
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Troop>().HasIndex(x => x.NumberTroop).IsUnique();
			builder.Entity<Troop>().HasOne(x => x.PlatoonCommander);
			builder.Entity<Student>().HasOne(x => x.Troop).WithMany(x => x.Students);
            builder.Entity<Relative>().HasOne(x => x.Student).WithMany(x => x.Relatives).HasForeignKey(p => p.StudentId);
			builder.Entity<User>().HasIndex(x => x.TroopId).IsUnique();

            Seed(builder);
		}

		private void Seed(ModelBuilder builder)
		{
            string[] SpecInstList = { "ИВТ", "МАТ", "БИ", "ЕНА" };
            string[] InstGroupList = { "3ВТИ-039", "3ВТИ-037", "3ВТИ-042", "3ВТИ-040" };
            string[] RectalList = { "Одинцовский", "Московский", "Тульский", "Красногорский" };
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
			builder.Entity<Troop>().HasData(new Troop
			{
				Id = "3",
				CycleId = "1",
				NumberTroop = "420",
				PrepodId = "1"
			});
			builder.Entity<Troop>().HasData(new Troop
			{
				Id = "4",
				CycleId = "1",
				NumberTroop = "510",
				PrepodId = "1"
			});

			builder.Entity<User>().HasData(new User
			{
				Id = Guid.NewGuid().ToString(),
				Login = "Admin",
				Password = _passwordProvider.GetHash("P@ssw0rd", "Admin"),
				Role = "Admin"
			});

			builder.Entity<User>().HasData(new User
			{
				Id = Guid.NewGuid().ToString(),
				Login = "Troop410",
				Password = _passwordProvider.GetHash("P@ssw0rd", "Troop410"),
				Role = "User",
				TroopId = "1"
			});

			builder.Entity<User>().HasData(new User
			{
				Id = Guid.NewGuid().ToString(),
				Login = "Troop520",
				Password = _passwordProvider.GetHash("P@ssw0rd", "Troop520"),
				Role = "User",
				TroopId = "2"
			});

			builder.Entity<User>().HasData(new User
			{
				Id = Guid.NewGuid().ToString(),
				Login = "Troop420",
				Password = _passwordProvider.GetHash("P@ssw0rd", "Troop420"),
				Role = "User",
				TroopId = "3"
			});

			builder.Entity<User>().HasData(new User
			{
				Id = Guid.NewGuid().ToString(),
				Login = "Troop510",
				Password = _passwordProvider.GetHash("P@ssw0rd", "Troop510"),
				Role = "User",
				TroopId = "4"
			});

			for (int i = 0; i < 100; i++)
			{
                builder.Entity<Student>().HasData(new Student
                {
                    Id = Guid.NewGuid().ToString(),
                    TroopId = i >= 50 ? "1" : "2",
                    FirstName = "Имя" + rand.Next(100),
                    LastName = "Фамилия" + rand.Next(100),
                    MiddleName = "Отчество" + rand.Next(100),
                    Collness = "Студент",
                    SpecInst = SpecInstList[rand.Next(0, 4)],
                    InstGroup = InstGroupList[rand.Next(0, 4)],
                    Rectal = RectalList[rand.Next(0, 4)],
                    Position = (StudentPosition)rand.Next(0, 5),
                    Kurs = 4,
                    Status = (StudentStatus)rand.Next(0, 4),
				});
			}
			for (int i = 0; i < 100; i++)
			{
                builder.Entity<Student>().HasData(new Student
                {
                    Id = (i * 182).ToString(),
					TroopId = i >= 50 ? "3" : "4",
					FirstName = "Имя" + rand.Next(100),
					LastName = "Фамилия" + rand.Next(100),
					MiddleName = "Отчество" + rand.Next(100),
					Collness = "Студент",
					SpecInst = SpecInstList[rand.Next(0, 4)],
					InstGroup = InstGroupList[rand.Next(0, 4)],
					Rectal = RectalList[rand.Next(0, 4)],
					Position = (StudentPosition)rand.Next(0, 5),
					Kurs = 4,
					Status = (StudentStatus)rand.Next(0, 4)
				});
			}
            for (int i = 0; i < 100; i++)
            {
                builder.Entity<Relative>().HasData(new Relative
                {
                    Id = Guid.NewGuid().ToString(),
                    StudentId = (i * 182).ToString(),
                    FirstName = "Имя" + rand.Next(100),
                    LastName = "Фамилия" + rand.Next(100),
                    MiddleName = "Отчество" + rand.Next(100),
                });
            }
        }
	}
}
