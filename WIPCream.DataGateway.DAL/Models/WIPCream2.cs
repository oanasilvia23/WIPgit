using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WIPCream.DataGateway.DAL2.Models
{
    public class WIPCream2: DbContext
    {
        public WIPCream2() : base("WIPCream2Entities")
        {
        }

        public DbSet<Assignments> Assignments { get; set; }
        public DbSet<Disciplines> Disciplines { get; set; }
        public DbSet<UserDisciplines> UserDisciplines { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<Tests> Tests { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<destination> destinations { get; set; }
        public DbSet<Questions> Questions { get; set; }

        public System.Data.Entity.DbSet<WIPCream.DataGateway.DAL2.Models.Threads> Threads { get; set; }
        
    }
}
