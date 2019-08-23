using LKS.Data.Models;
using LKS.Data.Models.Enums;
using LKS.Data.Providers;
using Microsoft.EntityFrameworkCore;
using System;

namespace LKS.Data
{
    public sealed class DataContext : DbContext
    {
        private readonly IPasswordProvider _passwordProvider;

        #region Properties
        public DbSet<Student> Students { get; set; }
        public DbSet<Relative> Relatives { get; set; }
        public DbSet<Troop> Troops { get; set; }
        public DbSet<Prepod> Prepods { get; set; }
        public DbSet<Cycle> Cycles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<SummerSbory> Summers { get; set; }
		public DbSet<Assessment> Assessments { get; set; }
        #endregion

        public DataContext(DbContextOptions options, IPasswordProvider passwordProvider) : base(options)
        {
            _passwordProvider = passwordProvider;
            //Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Troop>().HasIndex(x => x.NumberTroop).IsUnique();
            builder.Entity<Troop>().HasOne(x => x.PlatoonCommander);
            builder.Entity<Student>().HasOne(x => x.Troop).WithMany(x => x.UniversityStudents);
			builder.Entity<Student>().HasOne(x => x.SboryTroop).WithMany(x => x.SboryStudents);
			builder.Entity<Relative>().HasOne(x => x.Student).WithMany(x => x.Relatives).HasForeignKey(p => p.StudentId);
            builder.Entity<User>().HasIndex(x => x.TroopId).IsUnique();
            builder.Entity<Category>().HasMany(x => x.Subcategories).WithOne().HasForeignKey(x => x.ParentCategoryId);
            builder.Entity<Template>().HasOne(x => x.Category);

            Seed(builder);
        }

        private void Seed(ModelBuilder builder)
        {
            string[] SpecInstList = { "ИВТ", "МАТ", "БИ", "ЕНА" };
            string[] InstGroupList = { "3ВТИ-039", "3ВТИ-037", "3ВТИ-042", "3ВТИ-040" };
            string[] RectalList = { "Одинцовский", "Московский", "Тульский", "Красногорский" };
            var rand = new Random();

            builder.Entity<SummerSbory>().HasData(new SummerSbory
            {
                Id = "1",
                NumberofOrder = "12412",
                TextOrder = "ПРИКАЗЫВАЮ",
                LocationVK = "Наро Фоминск"
            });

            builder.Entity<Admin>().HasData(new Admin
            {
                Id = "1",
                Command = "НАЧ-НАЧ",
                Collness = "Полковник",
                FirstName = "Иван",
                LastName = "Иванович",
                MiddleName = "Иванов",
                Rank = "Начальник начальников"
            });

            var categoryOneTemplate = new Category()
            {
                Id = "3",
                Name = "Test3",
                ParentCategoryId = "1"
            };
            var categoryTwoTemplate = new Category()
            {
                Id = "5",
                Name = "Test5",
                ParentCategoryId = "2"
            };

            builder.Entity<Category>().HasData(new Category()
            {
                Id = "1",
                Name = "Testййцу",
                ParentCategoryId = null
            });
            builder.Entity<Category>().HasData(new Category()
            {
                Id = "2",
                Name = "Test2",
                ParentCategoryId = null
            });
            builder.Entity<Category>().HasData(categoryOneTemplate);
            builder.Entity<Category>().HasData(new Category()
            {
                Id = "4",
                Name = "Test4",
                ParentCategoryId = "1"
            });
            builder.Entity<Category>().HasData(categoryTwoTemplate);
            builder.Entity<Template>().HasData(new Template()
            {
                Id = "1",
                CategoryId = "3",
                Name = "Шаблон 1",
                Type = TemplateTypes.singleStudent,
                URI = "templates\\Характеристика.docx"
            });
            builder.Entity<Template>().HasData(new Template()
            {
                Id = "2",
                CategoryId = "5",
                Name = "Шаблон 2",
                Type = TemplateTypes.manyStudents,
                URI = "templates\\Справка о командировке.docx"
            });


            builder.Entity<Cycle>().HasData(new Cycle
			{
				Id = "1",
				Number = "4",
				SpecialityName = "ТОР",
				VUS = "042600"
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
