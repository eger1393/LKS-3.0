using LKS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LKS.DAL.Concrete
{
	public class LKSDbContext : DbContext
	{
		public LKSDbContext(DbContextOptions<LKSDbContext> options) : base(options) { }
		public DbSet<Student> Students { get; set; }
		public DbSet<Relative> Relatives { get; set; }
		public DbSet<Troop> Troops { get; set; }
		public DbSet<Cycle> Cycles { get; set; }
		public DbSet<Cycle> Cycles { get; set; }
	}
}
