using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Pro_1_MVC_Learning.Models
{
    public class Files
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public string FielLength { get; set; }
        public string FileHash { get; set; }
        public DateTime UploadData { get; set; }

        public static EntityTypeConfiguration<Files> Map()
        {
            var map= new EntityTypeConfiguration<Files>();

            map.Property(m => m.FileName).HasMaxLength(200).IsRequired();
            map.Property(m => m.ContentType).HasMaxLength(200);
            map.Property(m => m.FileHash).IsUnicode(false).HasMaxLength(32);
            map.HasIndex(m => m.FileHash).IsUnique();

            return map;
        }

    }
}