using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBContextsModels:DbContext
    {
        public DbSet<Page> Pages { get; set; }
        public DbSet<PageGroup> PageGroups { get; set; }
        public DbSet<PageComment> PageComments { get; set; }
    }
}
