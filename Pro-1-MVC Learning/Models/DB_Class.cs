using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Pro_1_MVC_Learning.Models
{
    public class DB_Class:DbContext
    {
        public DB_Class():base("DB") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(Models.Files.Map());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Files> Files { get; set; }
    }
}