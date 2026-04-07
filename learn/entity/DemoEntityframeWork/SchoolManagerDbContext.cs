using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DemoEntityframeWork.Program;

namespace DemoEntityframeWork
{
    public class SchoolManagerDbContext : DbContext
    {

        public SchoolManagerDbContext()
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(s => s.Id);

            modelBuilder.Entity<Student>()
                .Property(s => s.Name)
                .IsRequired().HasMaxLength(50);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Class)
                .WithMany(s => s.Students)
                .HasForeignKey(s => s.ClassId).OnDelete(DeleteBehavior.Cascade);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=.\\SQLEXPRESS;Database=SchoolDb;MultipleActiveResultSets=true;TrustServerCertificate=True;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        DbSet<Student> Students { get; set; }
        DbSet<Class> Class { get; set; }
    }
}
