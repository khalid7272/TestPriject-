using CrudOperation.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudOperation.Context
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options) { }

        public DbSet<Models.Teacher> Teacher { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);


                entity.Property(e => e.Skills)
                    .IsRequired()
                    .HasMaxLength(250);


                entity.Property(e => e.Salary)
                    .IsRequired()
                    .HasColumnType("money");

                entity.Property(e => e.AddedOn)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });
        }
    }
}