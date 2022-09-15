using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace WpfApp1.Models
{
    public partial class PRN221_FirstExContext : DbContext
    {
        public PRN221_FirstExContext()
        {
        }

        public PRN221_FirstExContext(DbContextOptions<PRN221_FirstExContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //{
            //    optionsBuilder.UseSqlServer("server=(local);database=PRN221_FirstEx;uid=sa;pwd=123456;");
            //}
         
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = builder.Build();



            
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("PRN221_FirstEx"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Major)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("major");

                entity.Property(e => e.Male).HasColumnName("male");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
