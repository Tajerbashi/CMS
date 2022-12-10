using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Models;

namespace DAL
{
    public class DbContexts:DbContext
    {
        public DbContexts():base("DB") {
            Database.SetInitializer<DbContexts>(new CreateDatabaseIfNotExists<DbContexts>());
            Database.Initialize(true);
        }
        public DbSet<User> Users { get; set; }
    }
}
