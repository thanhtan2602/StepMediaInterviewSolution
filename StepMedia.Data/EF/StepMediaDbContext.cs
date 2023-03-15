using Microsoft.EntityFrameworkCore;
using StepMedia.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StepMedia.Data.EF
{
    public class StepMediaDbContext : DbContext
    {
        public StepMediaDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Students)
                .WithOne(s => s.Teacher)
                .HasForeignKey(s => s.TeacherId);

            modelBuilder.Entity<Student>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Teacher)
                .WithMany(t => t.Students)
                .HasForeignKey(s => s.TeacherId);
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
    }
}
