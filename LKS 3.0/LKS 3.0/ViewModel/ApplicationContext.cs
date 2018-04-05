using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LKS_3._0
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(MySql.Data.MySqlClient.MySqlConnection connect) : base(connect,true)
        {

		}

        public ApplicationContext(System.Data.SQLite.SQLiteConnection connect) : base(connect, true)
        {

        }
        public DbSet<Student> Students { get; set; }
		public DbSet<Relative> Relatives { get; set; }
		public DbSet<Prepod> Prepods { get; set; }
		public DbSet<Troop> Troops { get; set; }
		public DbSet<Model.Department> Departments { get; set;}
        public DbSet<Model.Summer> Summers { get; set; }
    
        public DbSet<Model.Admin> Admins { get; set; }
    }
}
